﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSniper : MonoBehaviour
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
        Player player = hitInfo.GetComponent<Player>();
        if(player != null)
        {
            player.TakeDamage(damage);
        }
        Destroy(gameObject);
    }

}
