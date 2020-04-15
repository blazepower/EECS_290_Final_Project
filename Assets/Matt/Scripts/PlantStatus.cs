using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlantStatus : MonoBehaviour
{
    public GameObject plant;
    public Transform healthBar;
    public Slider healthFill;

    public int maxHealth = 40;
    public int currentHealth;

    public SpriteRenderer spriteRenderer;
    public Sprite goodHealthSprite;
    public Sprite nearDeathSprite;

    public bool interactable = false;
    public bool isWatering = false;
    private BoxCollider2D clickBox;


    void Start()
    {
        healthFill.maxValue = maxHealth;
        currentHealth = maxHealth;
        StartCoroutine("decay");
        clickBox = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth > 20)
        {
            spriteRenderer.sprite = goodHealthSprite;
        } 
        else if (currentHealth <= 20)
        {
            spriteRenderer.sprite = nearDeathSprite;
        }
        healthFill.value = currentHealth;
        if (currentHealth == 0)
            clickBox.enabled = false;
    }

    public IEnumerator decay()
    {
        while (currentHealth > 0 && isWatering == false)
        {
            yield return new WaitForSeconds(1.0f);
            if (isWatering == false)
                currentHealth--;
        }
    }

    public IEnumerator watering()
    {
        while (currentHealth <= 40 && isWatering == true && currentHealth != 0)
        {
            if (CanStatus.isEmpty() == true || currentHealth == 40)
            {
                isWatering = false;
                StartCoroutine("decay");
            } 
            else
            {
                yield return new WaitForSeconds(0.33f);
                currentHealth++;
                CanStatus.Subtract();
            }

        }
    }

    public int spamPrevent = 0;
    void OnMouseDown()
    {
        if(interactable == true)
            spamPrevent = 0;
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
            StopCoroutine("decay");
            StartCoroutine("decay");
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
        Debug.Log("FALSE");
    }

}
