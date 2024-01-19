using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    public Transform CameraTransform;
    public LayerMask ShootableLayerMask;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("Выстрел");

            if (Physics.Raycast(CameraTransform.position, CameraTransform.forward, out RaycastHit hit, 10000f, ShootableLayerMask))
            {
                Debug.Log("Попал!");
            }
        }
    }
}