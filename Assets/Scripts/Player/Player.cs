using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Модификатор доступа - public, Тип поля - Rigidbody, Название - Rb;
    public Rigidbody Rb;
    public Transform GroundChecker;
    public float GroundChecherRadius;
    public LayerMask GroundLayerMask;

    public float Speed;
    public float JumpStrength;
    public bool IsOnGround;

    // Start is called before the first frame update
    private void Start()
    {
        
    }

    private void Update()
    {
        Vector3 jumpVector = new Vector3(0, JumpStrength, 0);

        if (IsOnGround)
        {
            if (Input.GetButtonDown("Jump"))
            {
                Rb.AddForce(jumpVector, ForceMode.Impulse);

                IsOnGround = false;
            }
        }
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        IsOnGround = Physics.CheckSphere(GroundChecker.position, GroundChecherRadius, GroundLayerMask);

        Vector3 direction = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));

        direction.Normalize();
        direction = transform.TransformDirection(direction);

        if (IsOnGround)
        {
            Rb.velocity = direction * Speed;
        }
        else
        {
            float projectVelocity = Vector3.Dot(Rb.velocity, direction);
            float accelerationVelocity = Speed * Time.fixedDeltaTime * 2f;

            if (projectVelocity + accelerationVelocity > Speed)
            {
                accelerationVelocity = Speed - projectVelocity;
            }

            Rb.velocity += direction * accelerationVelocity;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(GroundChecker.position, GroundChecherRadius);
    }
}