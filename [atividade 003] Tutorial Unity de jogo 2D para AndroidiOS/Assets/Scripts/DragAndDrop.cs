﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    bool movedAllowed;
    Collider2D col;
    public ParticleSystem selectionEffect;
    public ParticleSystem deathEffect;
    private GameMaster gm;
    private AudioSource source;
    public AudioSource explosion;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        col = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

            if(touch.phase == TouchPhase.Began)//quando iniciamos o toque na tela
            {
                Collider2D touchedCollider = Physics2D.OverlapPoint(touchPosition);
                if(col == touchedCollider)
                {
                    Instantiate(selectionEffect, transform.position, Quaternion.identity);
                    source.Play();
                    movedAllowed = true;
                }
            }

            if(touch.phase == TouchPhase.Moved)//quando estamos movendo o dedo na tela
            {   
                if(movedAllowed)
                {
                    transform.position = new Vector2(touchPosition.x,touchPosition.y);
                }
                
            }

            if(touch.phase == TouchPhase.Ended)//quando finalizamos o toque na tela
            {
                movedAllowed = false;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Planet")
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            explosion.Play();
            gm.GameOver();
        }
    }
}
