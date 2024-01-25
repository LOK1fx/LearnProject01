using System;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public event Action<RaycastHit> OnInteractableFound;
    public event Action OnStopInteraction;

    [SerializeField] private float _interactionDistance;

    [Space]
    [SerializeField] private LayerMask _interactableLayerMask;

    private bool _isInteracting;

    private Player _currentPlayer;

    public void Construct(Player player)
    {
        _currentPlayer = player;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (_isInteracting == false)
            {
                var cameraTransform = _currentPlayer.Camera.CameraTransform;

                if (Physics.Raycast(cameraTransform.position, cameraTransform.forward,
                out var hit, _interactionDistance, _interactableLayerMask))
                {
                    if (hit.collider.gameObject.TryGetComponent<IInteractable>(out var interactable))
                    {
                        _isInteracting = true;

                        OnInteractableFound?.Invoke(hit);
                    }
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