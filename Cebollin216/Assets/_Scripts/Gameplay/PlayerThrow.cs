using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerThrow : MonoBehaviour
{
    public InputActionReference throwAction;

    public PlayerGrab playerGrab;

    public float thtrowForce = 20f;

    void Update()
    {
        if (throwAction.action.triggered)
        {
            ThrowObject();
        }
    }

    void ThrowObject()
    {
        if (playerGrab.HeldObject == null) return;

        GrabObject item = playerGrab.HeldObject.GetComponent<GrabObject>();

        if (!item.canBeThrown) return;

        Rigidbody rb = playerGrab.HeldObject.GetComponent<Rigidbody>();

        playerGrab.ReleaseHeldObject();

        if (rb = null) return;

        rb.isKinematic = false;

        Vector3 throwDirection;

        throwDirection = transform.forward;

        rb.AddForce(throwDirection* thtrowForce, ForceMode.Impulse);
    }
}