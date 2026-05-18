using UnityEngine;

// Allows for objects to be picked up, held, and thrown

// pickUp - whether the object is being held or not
// Transform handTransform - transform of the hand/controller holding the object
// throwMultiplier - used to increase/decrease the throwing force

// Start() - gets the Rigidbody and ensures physics behave normally when loading in
// Update() - Reads for right hand trigger input (0 = not pressed, 1 = pressed). If the object is being held then follow the hand and lock it's position/rotation to the hand. If the triger is released then the object is dropped.
// OnTriggerStay(Collider other) - Reads trigger input and colliders when an object is picked up
// PickUp(Transform hand) - Handles picking up the actual object, disables object physics while being held, and clears any existing movement
// DropObject() - Handles dropping and throwing the object by re-enabling physics when dropped and getting controller velocity to determine throwing force

public class Throwable : MonoBehaviour
{
    private Rigidbody rb;

    private bool pickedUp = false;
    private Transform handTransform;

    public float throwMultiplier = 1.5f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        rb.useGravity = true;
        rb.isKinematic = false;
    }

    void Update()
    {
        float triggerRight = OVRInput.Get(OVRInput.RawAxis1D.RIndexTrigger);

        if (pickedUp)
        {
            transform.position = handTransform.position;
            transform.rotation = handTransform.rotation;

            if (triggerRight < 0.1f)
            {
                DropObject();
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        float triggerRight = OVRInput.Get(OVRInput.RawAxis1D.RIndexTrigger);

        if (!pickedUp && other.CompareTag("hand") && triggerRight > 0.9f)
        {
            PickUp(other.transform);
        }
    }

    void PickUp(Transform hand)
    {
        pickedUp = true;
        handTransform = hand;

        rb.isKinematic = true;
        rb.useGravity = false;

        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

    void DropObject()
    {
        pickedUp = false;

        rb.isKinematic = false;
        rb.useGravity = true;

        Vector3 throwVelocity =
            OVRInput.GetLocalControllerVelocity(OVRInput.Controller.RTouch);

        rb.linearVelocity = throwVelocity * throwMultiplier;
    }
}