using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInteraction))]
public class InteractionDragAndDrop : MonoBehaviour
{
    [SerializeField] private Transform _dragParentTransform;

    private PlayerInteraction _playerInteraction;

    private InteractableDragAndDropObject _currentInteractionObject;


    private void Awake()
    {
        _playerInteraction = GetComponent<PlayerInteraction>();

        _playerInteraction.OnInteractableFound += OnInteraction;
        _playerInteraction.OnStopInteraction += OnStoppedInteraction;
    }

    private void FixedUpdate()
    {
        if (_currentInteractionObject != null)
        {
            _currentInteractionObject.Rigidbody.velocity = (_dragParentTransform.position -
                _currentInteractionObject.Rigidbody.position) * 8f;
        }
    }

    private void OnStoppedInteraction()
    {
        _currentInteractionObject.Throw(_dragParentTransform.forward);
        _currentInteractionObject = null;
    }

    private void OnInteraction(RaycastHit hit)
    {
        if (hit.collider.gameObject.TryGetComponent<InteractableDragAndDropObject>(out var interactableObject))
        {
            _currentInteractionObject = interactableObject;

            interactableObject.Take();
        }
    }
}