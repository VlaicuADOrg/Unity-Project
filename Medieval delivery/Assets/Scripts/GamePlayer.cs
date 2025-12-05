using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Lab9Assets.Scripts
{
    internal class GamePlayer : MonoBehaviour
    {
        [SerializeField] private float _MovementSpeed;
        [SerializeField] private float _SteeringSpeed;
        [SerializeField] private Camera _Camera;

        private void Update()
        {
            float synchronizedMovementSpeed = _MovementSpeed * Time.deltaTime;
            float synchronizedSteeringSpeed = _SteeringSpeed * Time.deltaTime;

            if (Input.GetKey(KeyCode.LeftShift))
            {
                synchronizedMovementSpeed *= 3;
            }

            if (Input.GetKey(KeyCode.W))
            {
                transform.position += transform.forward * synchronizedMovementSpeed;
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.position += transform.right * synchronizedMovementSpeed;
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.position -= transform.forward * synchronizedMovementSpeed;
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.position -= transform.right * synchronizedMovementSpeed;
            }

            if (Input.GetMouseButton(0))
            {
                float horizontalRotation = Input.GetAxis("Mouse X") * synchronizedSteeringSpeed;
                float verticalRotation = -Input.GetAxis("Mouse Y") * synchronizedSteeringSpeed;
                transform.Rotate(0, horizontalRotation, 0);
                _Camera.transform.Rotate(verticalRotation, 0, 0);
            }
        }
    }
}
