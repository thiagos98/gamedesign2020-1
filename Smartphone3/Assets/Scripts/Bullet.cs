using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 20;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Sniper sniper = hitInfo.GetComponent<Sniper>();
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if(sniper != null)
        {
            sniper.TakeDamage(damage);
        }
        if(enemy != null)
        {
            enemy.TakeDamage(damage);
        }
        Destroy(gameObject);
    }

}
