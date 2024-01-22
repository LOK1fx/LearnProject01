using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    public Animator Anim;
    public int Health = 100;


    public void TakeDamage()
    {
        Health -= 10;

        Anim.Play("Enemy_TakeDamage", 0, 0);

        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }
}