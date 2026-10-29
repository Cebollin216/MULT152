using UnityEngine;
using UnityEngine.InputSystem;

public class Pickup : MonoBehaviour
{
    public Transform pickupPoint;

    private bool playerNearby = false;
    private bool isCarrying = false;

    void Update()
    {
        if (playerNearby && Keyboard.current.eKey.wasPressedThisFrame)
        {
            if (!isCarrying)
            {
                PickUp();
            }
            else
            {
                Drop();
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = true;
            Debug.Log("Press E to pick up the box");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = false;
            Debug.Log("Player left box");
        }
    }

    void PickUp()
    {
        isCarrying = true;

        transform.SetParent(pickupPoint);

        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;

        Rigidbody rb = GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.isKinematic = true;
        }

        Debug.Log("Box picked up!");
    }

    void Drop()
    {
        isCarrying = false;

        transform.SetParent(null);

        Rigidbody rb = GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.isKinematic = false;
        }

        Debug.Log("Box dropped!");
    }
}