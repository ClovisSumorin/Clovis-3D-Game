using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    public int maxHealth = 100;
    public int currentHealth;

    public Transform respawnTransform;

    public Image healthfillbar;

    public AudioSource playerDeath;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }


    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        UpdateHealth();
        if (currentHealth <= 0)
        {
            PlayerDie();
        }
    }

    void UpdateHealth()
    {
        healthfillbar.fillAmount = currentHealth / maxHealth;
    }

    void PlayerDie()
    {
       playerDeath.Play();

       gameObject.transform.position = respawnTransform.transform.position;
       currentHealth = maxHealth;
       UpdateHealth();

        
    }
}