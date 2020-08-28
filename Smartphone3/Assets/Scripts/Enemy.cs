using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    private Rigidbody2D rig;
    public float speed;
    public Transform rightCol;
    public Transform leftCol;


    private bool colliding;

    public LayerMask layer;


    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rig.velocity = new Vector2(speed, rig.velocity.y);

        colliding = Physics2D.Linecast(rightCol.position, leftCol.position, layer);

        if(colliding)
        {
            transform.localScale = new Vector2(transform.localScale.x*-1f, transform.localScale.y);
            speed *= -1;

        }
    }
    public void TakeDamage(int damage)
    {
        health -= damage;

        if(health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            GameController.instance.ShowGameOver();
            Destroy(collision.gameObject);
        }
    }
}