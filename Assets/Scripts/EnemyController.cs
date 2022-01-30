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
        Vector2 directionVector = transform.position - player.transform.position;
        rb.AddRelativeForce(directionVector.normalized * 999999);

        var r = Random.Range(1, 90);
        if (IsLeft(transform.position, player.transform.position)) {
            r = -r;
        } 

        var impulse = (r * Mathf.Deg2Rad) * rb.inertia;
        rb.AddTorque(impulse, ForceMode2D.Impulse);
    }

    bool IsLeft(Vector2 A, Vector2 B)
    {
        return -A.x * B.y + A.y * B.x < 0;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
