using UnityEngine;

public class CreditsScroll : MonoBehaviour
{
    public float speed = 50f;

    public float startY = -170;

    public float endY = 10000;

    void Start()
    {
        Vector3 pos = transform.localPosition;
        pos.y = startY;
        transform.localPosition = pos;
    }

    void Update()
    {
        Vector3 pos = transform.localPosition;

        pos.y += speed * Time.deltaTime;

        if (pos.y > endY)
            pos.y = endY;

        transform.localPosition = pos;
    }
}
