using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Модификатор доступа - public, Тип поля - Rigidbody, Название - Rb;
    public Rigidbody Rb;
    public float Speed;
    public float JumpStrength;

    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        Vector3 velocity = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        Vector3 jumpVector = new Vector3(0, JumpStrength, 0);


        velocity.Normalize();

        Rb.velocity = velocity * Speed * Time.deltaTime;

        if (Input.GetButtonDown("Jump"))
        {
            Rb.AddForce(jumpVector, ForceMode.Impulse);
        }
    }
}