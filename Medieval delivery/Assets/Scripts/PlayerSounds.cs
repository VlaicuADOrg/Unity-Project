using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayerSounds : MonoBehaviour
{
    public AudioClip footstep;
    public AudioClip jump;

    public float stepDelay = 0.5f;
    private float stepTimer;

    AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        stepTimer = stepDelay;
    }

    void Update()
    {
        bool isMoving =
            Input.GetKey(KeyCode.W) ||
            Input.GetKey(KeyCode.A) ||
            Input.GetKey(KeyCode.S) ||
            Input.GetKey(KeyCode.D) ||
            Input.GetKey(KeyCode.UpArrow) ||
            Input.GetKey(KeyCode.DownArrow) ||
            Input.GetKey(KeyCode.LeftArrow) ||
            Input.GetKey(KeyCode.RightArrow);

        if (isMoving)
        {
            stepTimer -= Time.deltaTime;

            if (stepTimer <= 0f && footstep != null)
            {
                audioSource.PlayOneShot(footstep);
                stepTimer = stepDelay;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && jump != null)
        {
            audioSource.PlayOneShot(jump);
        }
    }
}
