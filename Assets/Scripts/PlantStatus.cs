using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlantStatus : MonoBehaviour
{
    public GameObject plant;
    public Transform healthBar;
    public Slider healthFill;
    public ParticleSystem system;

    public int maxHealth = 40;
    public int currentHealth;

    public SpriteRenderer spriteRenderer;
    public Sprite bloomingSprite;
    public Sprite goodHealthSprite;
    public Sprite nearDeathSprite;
    public Sprite deadSprite;

    public bool interactable = false;
    public bool isWatering = false;
    private bool canBloom = true, isBloomed = false;
    private BoxCollider2D clickBox;
    //public Collider2D florist;
    private bool deductGate = true;

    public AudioSource wateringSound;

    void Start()
    {
        healthFill.maxValue = maxHealth;
        currentHealth = 30;
        StartCoroutine("decay");
        clickBox = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth > (maxHealth / 2))
        {
            spriteRenderer.sprite = goodHealthSprite;
        }
        else if (currentHealth <= (maxHealth / 2))
        {
            spriteRenderer.sprite = nearDeathSprite;
        }

        //Plant stays dead if health is 0
        healthFill.value = currentHealth;
        if (currentHealth == 0)
        {
            isWatering = false;
            wateringSound.Stop();
            clickBox.enabled = false;
            spriteRenderer.sprite = deadSprite;
            Global.plantsReady--;
        }

        if (currentHealth == 0 && deductGate == true)
        {
            Global.plantDeadDeduction();
            CareerStats.moneyPlantDied();
            CareerStats.addPlantsDead();
            deductGate = false;
        }

        //Plant blooms if health is full
        if (currentHealth > maxHealth - 1 && canBloom){
            clickBox.enabled = false;
            spriteRenderer.sprite = bloomingSprite;
            stopDecay();
            if (!isBloomed){
                Global.plantBloomed();
                CareerStats.addPlantsBloomed();
                isBloomed = true;
            }
            
        }

        if (CanStatus.isEmpty() == true)
        {
            isWatering = false;
        }

        /*if (isWatering) {
            if (!wateringSound.isPlaying)
                wateringSound.Play(0);
        }*/
    }

    public IEnumerator decay()
    {
        wateringSound.Stop();
        while (currentHealth > 0 && isWatering == false)
        {
            yield return new WaitForSeconds(1.0f);

            if (isWatering == false)
                currentHealth--;
        }

        canBloom = true;
    }

    //Plant stays healthy when in bloom
    void stopDecay()
    {
        if(canBloom)
        {
            StopCoroutine("decay");
        }
    }

    public IEnumerator watering()
    {

        while (currentHealth <= maxHealth && isWatering == true && currentHealth != 0)
        {
            
            if (CanStatus.isEmpty() == true || currentHealth == maxHealth)
            {
                wateringSound.Stop();
                isWatering = false;
                StartCoroutine("decay");
            } 
            else
            {
                yield return new WaitForSeconds(0.33f);
                currentHealth++;
                CanStatus.Subtract();
                system.Play();
            }

        }
    }

    public int spamPrevent = 0;
    void OnMouseDown()
    {
        if(interactable == true)
        {
            spamPrevent = 0;
            wateringSound.Play();
        }
        
    }

    void OnMouseDrag()
    {
        if (interactable == true)
        {
            spamPrevent++;
            if (CanStatus.isEmpty() == false)
                isWatering = true;
            else
                isWatering = false;

            if (spamPrevent == 1 && isWatering == true)
            {
                StartCoroutine("watering");
                StopCoroutine("decay");
            }
        }
    }

    void OnMouseUp()
    {
        if (interactable == true)
        {
            StartCoroutine("prevent");
            isWatering = false;
            StopCoroutine("watering");
            system.Stop();
            StopCoroutine("decay");
            StartCoroutine("decay");
            wateringSound.Stop();
        }
    }

    public IEnumerator prevent()
    {
        clickBox.enabled = false;
        yield return new WaitForSeconds(0.33f);
        clickBox.enabled = true;
        spamPrevent = 0;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        interactable = true;
        Debug.Log("TRUE");
    }
    private void OnTriggerStay2d(Collider2D other)
    {
        interactable = true;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        interactable = false;
        isWatering = false;
        wateringSound.Stop();
        StopCoroutine("decay");
        StartCoroutine("decay");
        Debug.Log("FALSE");
    }

}
