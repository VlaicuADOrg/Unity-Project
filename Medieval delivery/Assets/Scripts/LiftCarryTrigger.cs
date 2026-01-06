using UnityEngine;
using UnityEngine.AI;

public class LiftCarryAndDisableNavMesh : MonoBehaviour
{
    [SerializeField] private Transform platformRoot;

    private Vector3 _lastPlatformPos;
    private CharacterController _playerCC;
    private Transform _playerRoot;
    private NavMeshAgent _playerAgent;

    private void Awake()
    {
        if (platformRoot == null)
            platformRoot = transform.parent != null ? transform.parent : transform;

        _lastPlatformPos = platformRoot.position;
    }

    private void LateUpdate()
    {
        if (_playerCC == null) return;

        Vector3 delta = platformRoot.position - _lastPlatformPos;
        if (delta.sqrMagnitude > 0f)
            _playerCC.Move(delta); 

        _lastPlatformPos = platformRoot.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        _playerCC = other.GetComponentInParent<CharacterController>();
        _playerRoot = other.transform.root;

        
        _playerAgent = other.GetComponentInParent<NavMeshAgent>();
        if (_playerAgent != null)
            _playerAgent.enabled = false;

        _lastPlatformPos = platformRoot.position;
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        
        if (_playerAgent != null)
        {
            _playerAgent.enabled = true;
            
            _playerAgent.Warp(_playerRoot.position);
        }

        _playerCC = null;
        _playerRoot = null;
        _playerAgent = null;

        _lastPlatformPos = platformRoot.position;
    }
}
