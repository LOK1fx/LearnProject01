using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    public AudioSource Source;
    public AudioClip ShootSound01;
    public Transform CameraTransform;
    public LayerMask ShootableLayerMask;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Source.PlayOneShot(ShootSound01);
            Debug.DrawRay(CameraTransform.position, CameraTransform.forward * 10000f, Color.red, 1f);

            if (Physics.Raycast(CameraTransform.position, CameraTransform.forward, out RaycastHit hit, 10000f, ShootableLayerMask))
            {
                if (hit.collider.gameObject.TryGetComponent<Enemy>(out Enemy enemy))
                {
                    enemy.TakeDamage();
                }

                if (hit.collider.gameObject.TryGetComponent<ItemInfo>(out var item))
                {
                    item.PrintToConsole();
                }
            }
        }
    }
}