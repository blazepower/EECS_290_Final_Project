using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlantStatus : MonoBehaviour
{
    public Transform healthBar;
    public Slider healthFill;

    public int maxHealth = 40;
    public int currentHealth;

    public SpriteRenderer spriteRenderer;
    public Sprite goodHealthSprite;
    public Sprite nearDeathSprite;

    public bool isWatering = false;

    void Start()
    {
        healthFill.maxValue = maxHealth;
        currentHealth = maxHealth;
        StartCoroutine("decay");
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth > 20)
        {
            healthySprite();
        } 
        else if (currentHealth <= 20)
        {
            dyingSprite();
        }
        healthFill.value = currentHealth;
    }

    public IEnumerator decay()
    {
        if (currentHealth > 0)
        {
            yield return new WaitForSeconds(1.0f);
            if (isWatering == false)
            {
                currentHealth--;
                StartCoroutine("decay");
            }
        }
    }

    void OnMouseDown()
    {
        isWatering = true;
        StopCoroutine("decay");
        StartCoroutine("watering");
    }

    public IEnumerator watering()
    {
        if (currentHealth < 40)
        {
            yield return new WaitForSeconds(0.25f);
            currentHealth++;
            if (isWatering == true)
                StartCoroutine("watering");
        }
    }

    void OnMouseUp()
    {
        isWatering = false;
        StartCoroutine("decay");
        StopCoroutine("watering");
    }


    public void healthySprite()
    {
        spriteRenderer.sprite = goodHealthSprite;
    }

    public void dyingSprite()
    {
        spriteRenderer.sprite = nearDeathSprite;
    }
}
