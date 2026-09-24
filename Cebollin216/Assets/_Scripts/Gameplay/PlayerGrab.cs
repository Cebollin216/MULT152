using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerGrab : MonoBehaviour
{
    public InputActionReference grabAction;

    public Transform holdpoint;

    private GameObject heldObject;

    [HideInInspector]

    public string carriedItemName = "Nothing";

    [HideInInspector]

    public float carriedWeight = 0f;

    

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

                GrabObject grabData = heldObject.GetComponent<GrabObject>();
                carriedItemName = grabObject.itemName;
                carriedWeight = grabData.weight;

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

        heldObject = null;
        carriedItemName = "Nothing";
        carriedWeight = 0f;
    }
}