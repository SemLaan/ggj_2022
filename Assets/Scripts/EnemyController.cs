using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class EnemyController : MonoBehaviour
{
    // rigidbody
    Rigidbody2D rb;

    // animator
    public Animator animator;

    // starting health
    float health = 100;

    public AudioClip clip; //make sure you assign an actual clip here in the inspector

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void TakeDamage(float damage, GameObject player)
    {
        if (health > 0)
        {
            AudioSource.PlayClipAtPoint(clip, this.gameObject.transform.position);
            health = health - damage;
            animator.SetBool("deuk", true);
            rb.constraints = RigidbodyConstraints2D.None;
        }
        rb.AddRelativeForce(transform.forward * 100000);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
