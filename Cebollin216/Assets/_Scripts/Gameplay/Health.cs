using UnityEngine.UI;
using UnityEngine;

public class Health : MonoBehaviour
{
    public Slider healthSlider;
    public int maxHealth = 100;
    public int currentHealth;


    void Start()
    {
        currentHealth = maxHealth; 
        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthSlider.value = currentHealth;
    
        if (currentHealth <= 0)
        {
            Death();
        }
    }

    void Death()
    {
        Destroy(gameObject);
        Debug.Log(gameObject.name + " died");
    }
}