using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [Header("Health")]
    public int maxHealth = 100;
    public int health;
    public event System.Action<int> OnHealthChanged;

    [Header("UI")]
    public Slider healthSlider;

    [Header("Damage Text")]
    public GameObject damageTextPrefab;
    public Transform damageTextSpawnPoint;

    [Header("Death")]
    public GameObject deathEffect;
    public float destroyDelay = 2f;

    private bool isDead;

    private void Start()
    {
        health = maxHealth;

        if (healthSlider != null)
        {
            healthSlider.maxValue = maxHealth;
            healthSlider.value = health;
        }
    }

    public void TakeDamage(int damage)
    {
        if (isDead)
            return;

        health -= damage;

        if (health < 0)
            health = 0;

        if (healthSlider != null)
        {
            healthSlider.value = health;
        }

        ShowDamageText(damage);
        OnHealthChanged?.Invoke(health);

        if (health <= 0)
        {
            Die();
        }
    }

    private void ShowDamageText(int damage)
    {
        if (damageTextPrefab == null || damageTextSpawnPoint == null)
            return;

        GameObject textObj = Instantiate(
            damageTextPrefab,
            damageTextSpawnPoint.position,
            Quaternion.identity);

        FloatingDamageText damageTextScript =
            textObj.GetComponent<FloatingDamageText>();

        if (damageTextScript != null)
        {
            damageTextScript.SetDamage(damage);
        }
    }

    private void Die()
    {
        isDead = true;

        EnemyAI ai = GetComponent<EnemyAI>();

        if (ai != null)
        {
            ai.currentState = EnemyState.Dead;
        }

        if (deathEffect != null)
        {
            Instantiate(
                deathEffect,
                transform.position,
                Quaternion.identity);
        }

        Destroy(gameObject, destroyDelay);
    }
}