using UnityEngine;

public class EnemySpawnPoint : MonoBehaviour
{
    private void OnDrawGizmoz()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 1f);
    }
}