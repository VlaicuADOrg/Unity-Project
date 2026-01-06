using System.Collections.Generic;
using UnityEngine;


//Incercarea anterioara 
public class PlatformCarryDelta : MonoBehaviour
{
    [SerializeField] private Transform platformRoot; 

    private Vector3 _lastPlatformPos;


    private readonly HashSet<CharacterController> _controllers = new();

    private void Awake()
    {
        if (platformRoot == null)
            platformRoot = transform.parent != null ? transform.parent : transform;

        _lastPlatformPos = platformRoot.position;
    }

    private void LateUpdate()
    {
        Vector3 delta = platformRoot.position - _lastPlatformPos;
        if (delta.sqrMagnitude > 0f)
        {
            foreach (var cc in _controllers)
            {
                if (cc != null)
                    cc.Move(delta);
            }
        }

        _lastPlatformPos = platformRoot.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        var cc = other.GetComponentInParent<CharacterController>();
        if (cc != null) _controllers.Add(cc);
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        var cc = other.GetComponentInParent<CharacterController>();
        if (cc != null) _controllers.Remove(cc);
    }
}
