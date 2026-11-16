using UnityEngine;

public class AudioFeedback : MonoBehaviour
{
    public Health health;
    public EnemyHealth enemyHealth;
    public AudioSource audioSource;
    public AudioClip damageClip;
    public AudioClip deathClip;

    void OnEnable()
    {
        if (health != null)
            health.OnHealthChanged += OnHealthChanged;

        if (enemyHealth != null)
            enemyHealth.OnHealthChanged += OnHealthChanged;
    }

    void OnDisable()
    {
        if (health != null)
            health.OnHealthChanged -= OnHealthChanged;

        if (enemyHealth != null)
            enemyHealth.OnHealthChanged -= OnHealthChanged;
    }

    void OnHealthChanged(int currentHealth)
    {
        if (currentHealth > 0)
        {
            audioSource.PlayOneShot(damageClip);
        }
        else
        {
            audioSource.PlayOneShot(deathClip);
        }
    }
}