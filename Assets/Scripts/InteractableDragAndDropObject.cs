using UnityEngine;

[RequireComponent(typeof(Collider), typeof(Rigidbody))]
public class InteractableDragAndDropObject : MonoBehaviour, IInteractable
{
    public Rigidbody Rigidbody { get; private set; }
    private Collider _collider;

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
        _collider = GetComponent<Collider>();
    }

    public void Take()
    {
        
    }

    public void Throw(Vector3 direction)
    {
        Rigidbody.AddForce(direction * 10f, ForceMode.Impulse);
    }
}