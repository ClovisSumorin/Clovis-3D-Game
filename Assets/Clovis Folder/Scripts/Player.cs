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

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            PlayerDie();
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        UpdateHealth();
    }

    void UpdateHealth()
    {
        healthfillbar.fillAmount = currentHealth / maxHealth;
    }

    void PlayerDie()
    {
       gameObject.transform.position = respawnTransform.transform.position;
       currentHealth = maxHealth;
       UpdateHealth();
    }
}