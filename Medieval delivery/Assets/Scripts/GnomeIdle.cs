using UnityEngine;

public class GnomeIdle : MonoBehaviour
{
    public float rotateSpeed = 8f;
    public float scaleSpeed = 2f;
    public float scaleAmount = 0.02f;

    private Vector3 startScale;

    void Start()
    {
        startScale = transform.localScale;
    }

    void Update()
    {
        transform.localRotation = Quaternion.Euler(
            0f,
            Mathf.Sin(Time.time) * rotateSpeed,
            0f
        );

        float scaleOffset = 1f + Mathf.Sin(Time.time * scaleSpeed) * scaleAmount;

        transform.localScale = new Vector3(
            startScale.x * scaleOffset,
            startScale.y * scaleOffset,
            startScale.z * scaleOffset
        );
    }
}
