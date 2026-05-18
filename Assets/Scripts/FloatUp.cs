using UnityEngine;

public class FloatUp : MonoBehaviour
{
    [SerializeField] float floatUpSpeed = 1.2f;
    [SerializeField] float maxHeight = 25f;

    private bool floatUpToggle = false;

    private Rigidbody rb;

    private Vector3 startPosition;
    private Quaternion startRotation;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        startPosition = transform.position;
        startRotation = transform.rotation;
    }

    void Update()
    {
        if (floatUpToggle)
        {
            FloatLanternUp();

            if (transform.position.y >= maxHeight)
            {
                ResetLantern();
            }
        }
    }

    public void StartFloating()
    {
        floatUpToggle = true;

        rb.useGravity = false;
    }

    public void StopFloating()
    {
        floatUpToggle = false;

        rb.useGravity = true;

        rb.linearVelocity = Vector3.zero;
    }

    void FloatLanternUp()
    {
        Vector3 drift = new Vector3(
            Mathf.Sin(Time.time * 0.5f) * 0.2f,
            1f,
            Mathf.Cos(Time.time * 0.4f) * 0.2f
        );

        drift.Normalize();

        rb.linearVelocity = drift * floatUpSpeed;

        transform.Rotate(
            0,
            10f * Time.deltaTime,
            0
        );
    }

    void ResetLantern()
    {
        floatUpToggle = false;

        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        rb.useGravity = true;

        transform.position = startPosition;
        transform.rotation = startRotation;
    }
}
