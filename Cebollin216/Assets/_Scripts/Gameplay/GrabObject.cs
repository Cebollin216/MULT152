using UnityEngine;


public class GrabObject : MonoBehaviour
{
    [Header("Item Infromation")]
    public string itemName = "New Item";
    
    [Header("Object Weight")]
     public float weight = 10f;

     [Header("Attack Setting")]
     public bool canBeThrown = false;

     [HideInInspector]
    public bool PlayerInRange = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerInRange = true;
            Debug.Log("Press E to pick up the object");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
        PlayerInRange = false;
        Debug.Log("Player Dropped Object");
        }
    }   
}