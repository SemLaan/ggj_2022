using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // rigidbody
    Rigidbody2D rb;

    // animator
    public Animator animator;

    // starting health
    float health = 100;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void TakeDamage(float damage)
    {
        health = health - damage;
        if (health < 0)
        {
            animator.SetBool("deuk", true);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
