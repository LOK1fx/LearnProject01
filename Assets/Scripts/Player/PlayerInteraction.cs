using System;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public event Action<RaycastHit> OnInteractableFound;
    public event Action OnStopInteraction;

    [SerializeField] private float _interactionDistance;

    [Space]
    [SerializeField] private LayerMask _interactableLayerMask;
    [SerializeField] private Transform _playerCameraTransform;


    private bool _isInteracting;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (_isInteracting == false)
            {
                if (Physics.Raycast(_playerCameraTransform.position, _playerCameraTransform.forward,
                out var hit, _interactionDistance, _interactableLayerMask))
                {
                    _isInteracting = true;

                    OnInteractableFound?.Invoke(hit);
                }
            }
            else
            {
                _isInteracting = false;

                OnStopInteraction?.Invoke();
            }
        }
    }
}