using UnityEngine;

namespace Assets.Lab9Assets.Scripts
{
    public class GamePlayer : MonoBehaviour
    {
        [Header("Movement")]
        [SerializeField] private float _MovementSpeed = 5f;
        [SerializeField] private float _SprintMultiplier = 3f;

        [Header("Jump & Gravity")]
        [SerializeField] private float _JumpHeight = 1.2f;     // pune 1.0–1.5 dupa gust
        [SerializeField] private float _Gravity = 25f;         // 20–35 (mai mare = cade mai “snappy”)
        [SerializeField] private float _AirControl = 1f;       // 1 = control complet in aer
        [SerializeField] private float _GroundStickForce = 2f; // cat de tare “lipeste” de sol (1–4)

        [Header("Jump Feel (optional, recommended)")]
        [SerializeField] private float _CoyoteTime = 0.08f;    // poti sari putin dupa ce ai parasit solul
        [SerializeField] private float _JumpBuffer = 0.10f;    // daca apesi putin inainte de sol, sare cand atingi

        [Header("Look")]
        [SerializeField] private float _SteeringSpeed = 120f;
        [SerializeField] private Camera _Camera;
        [SerializeField] private float _MinPitch = -80f;
        [SerializeField] private float _MaxPitch = 80f;

        private CharacterController _cc;
        private float _verticalVelocity;
        private float _pitch;

        private float _coyoteTimer;
        private float _jumpBufferTimer;

        private void Awake()
        {
            _cc = GetComponent<CharacterController>();
            if (_Camera == null) _Camera = Camera.main;
        }

        private void Update()
        {
            // === LOOK (mouse) ===
            if (Input.GetMouseButton(0))
            {
                float yaw = Input.GetAxis("Mouse X") * _SteeringSpeed * Time.deltaTime;
                float pitchDelta = -Input.GetAxis("Mouse Y") * _SteeringSpeed * Time.deltaTime;

                transform.Rotate(0f, yaw, 0f);

                _pitch = Mathf.Clamp(_pitch + pitchDelta, _MinPitch, _MaxPitch);
                _Camera.transform.localEulerAngles = new Vector3(_pitch, 0f, 0f);
            }

            // === MOVE (WASD) ===
            float speed = _MovementSpeed;
            if (Input.GetKey(KeyCode.LeftShift)) speed *= _SprintMultiplier;

            float x = 0f;
            float z = 0f;
            if (Input.GetKey(KeyCode.D)) x += 1f;
            if (Input.GetKey(KeyCode.A)) x -= 1f;
            if (Input.GetKey(KeyCode.W)) z += 1f;
            if (Input.GetKey(KeyCode.S)) z -= 1f;

            Vector3 move = (transform.right * x + transform.forward * z);
            if (move.sqrMagnitude > 1f) move.Normalize();

            bool grounded = _cc.isGrounded;

            // === Timers for nicer jump ===
            if (grounded) _coyoteTimer = _CoyoteTime;
            else _coyoteTimer -= Time.deltaTime;

            if (Input.GetKeyDown(KeyCode.Space))
                _jumpBufferTimer = _JumpBuffer;
            else
                _jumpBufferTimer -= Time.deltaTime;

            // === Ground stick (fix for “bouncy landing”) ===
            // Daca esti pe sol si cazi, NU mai acumula gravitate; tine-l lipit usor.
            if (grounded && _verticalVelocity < 0f)
                _verticalVelocity = -_GroundStickForce;
            else
                _verticalVelocity -= _Gravity * Time.deltaTime;

            // === Jump (uses jump height) ===
            // sare daca ai apasat recent space + esti grounded (sau in coyote time)
            if (_jumpBufferTimer > 0f && _coyoteTimer > 0f)
            {
                _verticalVelocity = Mathf.Sqrt(2f * _Gravity * _JumpHeight);
                _jumpBufferTimer = 0f;
                _coyoteTimer = 0f;
            }

            float control = grounded ? 1f : _AirControl;

            Vector3 velocity = (move * (speed * control)) + Vector3.up * _verticalVelocity;
            _cc.Move(velocity * Time.deltaTime);
        }
    }
}
