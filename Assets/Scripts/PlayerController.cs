using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    // rigidbody
    Rigidbody2D rb;
    // animator
    public Animator animator;

    // jump force
    Vector3 jump = new Vector3(0, 1, 0);
    public float jumpForce = 10.0f;
    public bool isGrounded = false;
    public bool canFlip = false;

    // speed and movement of rigidbody
    public float speed = 40f;
    float move;

    // flipped character and gravity with sprite
    bool facingRight = true;
    float yRotation = 0;
    float xRotation = 0;


    // attacking
    public bool isAttacking = false;
    private float timeToAttack;
    public float cooldownAttack;
    public Transform attackPos;
    public float attackRange;
    public LayerMask Enemies;
    public float Damage;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // get input from player
        move = Input.GetAxis("Horizontal");

        // melee attack
        if (timeToAttack <= 0)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                animator.SetBool("hit", true);
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, Enemies);
                
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    Debug.Log(enemiesToDamage[i]);
                    enemiesToDamage[i].GetComponent<EnemyController>().TakeDamage(Damage, gameObject);
                    
                }
            }
            timeToAttack = cooldownAttack;
        }
        else
        {
            animator.SetBool("hit", false);
            timeToAttack -= Time.deltaTime;
        }

        // check space for jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // jump
            rb.AddForce(jump * jumpForce, ForceMode2D.Force);
        }
    }

    private void FixedUpdate()
    {
        // move rigidbody accordingly
        rb.velocity = new Vector2(speed * move, rb.velocity.y);

        // check velocity and let player stay left after walking
        if (rb.velocity.x > 0 && !facingRight || rb.velocity.x < 0 && facingRight)
        {
            facingRight = !facingRight;
        }

        // flip object to corresponding side
        if (facingRight == true)
        {
            yRotation = 0;
        }
        else
        {
            yRotation = 180;
        }

        // rotate player
        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0);

        // set animatior vars
        animator.SetFloat("speed", Mathf.Abs(move));
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}