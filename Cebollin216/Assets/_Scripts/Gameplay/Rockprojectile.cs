using JetBrains.Annotations;
using UnityEngine;

public class Rockprojectile : MonoBehaviour
{
    public int damage = 10;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            EnemyHealth enemy = other.gameObject.GetComponent<EnemyHealth>();

            if (enemy != null)
            {
                enemy.TakeDamage(damage);
                Debug.Log(other.gameObject.name + " took damage, health: " + enemy.health);
            }
        }
    }
}