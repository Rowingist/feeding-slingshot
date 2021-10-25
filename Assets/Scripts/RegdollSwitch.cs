using UnityEngine;

public class RegdollSwitch : MonoBehaviour
{
    [SerializeField] private Rigidbody[] _rigidBodies;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();

        for (int i = 0; i < _rigidBodies.Length; i++)
        {
            _rigidBodies[i].isKinematic = true;
        }
    }

    public void MakeNotAffectedByPhysics()
    {
        _animator.enabled = false;

        for (int i = 0; i < _rigidBodies.Length; i++)
        {
            _rigidBodies[i].isKinematic = false;
        }
    }
}
