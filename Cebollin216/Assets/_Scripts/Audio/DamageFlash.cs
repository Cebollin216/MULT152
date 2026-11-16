using System.Collections;
using UnityEngine;

public class DamageFlash : MonoBehaviour
{
    public Health health;
    public EnemyHealth enemyHealth;
    public Renderer targetRenderer;
    public Color flashColor = Color.red;
    public float flashDuration = 0.1f;

    private Color originalColor;
    private Coroutine flashRoutine;

    void OnEnable()
    {
        if (health != null)
            health.OnHealthChanged += Flash;

        if (enemyHealth != null)
            enemyHealth.OnHealthChanged += Flash;
    }

    void OnDisable()
    {
        if (health != null)
            health.OnHealthChanged -= Flash;

        if (enemyHealth != null)
            enemyHealth.OnHealthChanged -= Flash;

        if (flashRoutine != null)
        {
            StopCoroutine(flashRoutine);
            targetRenderer.material.color = originalColor;
            flashRoutine = null;
        }
    }

    void Flash(int currentHealth)
    {
        if (currentHealth <= 0 || targetRenderer == null)
            return;

        if (flashRoutine == null)
        {
            originalColor = targetRenderer.material.color;
        }
        else
        {
            StopCoroutine(flashRoutine);
        }

        flashRoutine = StartCoroutine(FlashRoutine());
    }

    IEnumerator FlashRoutine()
    {
        targetRenderer.material.color = flashColor;
        yield return new WaitForSeconds(flashDuration);
        targetRenderer.material.color = originalColor;
        flashRoutine = null;
    }
}