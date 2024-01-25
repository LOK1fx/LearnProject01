using System;
using UnityEngine;

public class PlayerInteractableInfo : MonoBehaviour
{
    public event Action<ItemInfo> OnItemSelected;
    public event Action OnItemDeselected;

    [SerializeField] private float _interactableInfoShowDistance = 2f;
    [SerializeField] private float _interactableInfoCheckerInterval;
    [SerializeField] private LayerMask _interactableObjectsLayerMask;

    private float _currentIntervalTimer;

    private Player _currentPlayer;

    public void Construct(Player player)
    {
        _currentPlayer = player;
    }

    private void Update()
    {
        _currentIntervalTimer += Time.deltaTime;

        if (_currentIntervalTimer >= _interactableInfoCheckerInterval)
        {
            var cameraTransform = _currentPlayer.Camera.CameraTransform;

            OnItemDeselected?.Invoke();

            if (Physics.Raycast(cameraTransform.position, cameraTransform.forward,
                out var hit, _interactableInfoShowDistance, _interactableObjectsLayerMask))
            {
                if (hit.collider.gameObject.TryGetComponent<ItemInfo>(out var item))
                {
                    OnItemSelected?.Invoke(item);
                }
            }

            _currentIntervalTimer = 0f;
        }
    }
}