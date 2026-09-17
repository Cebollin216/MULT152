using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerGrab : MonoBehaviour
{
    public InputActionReference grabAction;

    public Transform holdpoint;

    public float carriedWeight = 0f;

    private GameObject heldObject;

    void Update()
    {
        if (grabAction.action.triggered)
        {
            if (heldObject == null)
            {
                TryGrab();
            }
            else
            {
                DropObject();
            }
        }
    }

    void TryGrab()
    {
        Collider[] nearbyObjects = Physics.OverlapSphere(transform.position, 2f);

        foreach (Collider col in nearbyObjects)
        {
            GrabObject grabObject = col.GetComponent<GrabObject>();

            if (grabObject != null)
            {
                heldObject = col.gameObject;

                grabObject grabData = heldObject.GetComponent<grabObject>();
                carriedWeight = grabData.Weight;

                Rigidbody rb = heldObject.GetComponent<Rigidbody>();

                if (rb != null)
                {
                    rb.isKinematic = true;
                }

                heldObject.transform.SetParent(holdpoint);
                heldObject.transform.localPosition = Vector3.zero;

                return;
            }
        }
    }

    void DropObject()
    {
        Rigidbody rb = heldObject.GetComponent<Rigidbody>();

        heldObject.transform.SetParent(null);

        if (rb != null)
        {
            rb.isKinematic = false;
        }

        carriedWeight = 0f;
        heldObject = null;
    }
}