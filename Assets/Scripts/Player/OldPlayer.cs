using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldPlayer : MonoBehaviour
{
    //����������� ������� - public, ��� ���� - int, �������� - Health;
    public int Health;
    public float Speed = 5.25f;

    //int = ������������� �������� 1, 2, 3, -5, -125    25.23
    //float = ������� ����� 1, 2, 3, -5, -125, 25.23, -5.5, -10.57

    //public - ����� ���
    //private - �� ����� �����

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * Time.deltaTime * Speed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += -transform.right * Time.deltaTime * Speed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += -transform.forward * Time.deltaTime * Speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * Time.deltaTime * Speed;
        }
    }
}