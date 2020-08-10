using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public Animator anim;
    public float jumpForce;
    public bool isUp;
    public int scoreBox;
    public int health = 5;
    public GameObject effect;

    void Update()
    {
        if(health <= 0)
        {
            Instantiate(effect, transform.position, transform.rotation);
            GameController.instance.totalScore += scoreBox;
            GameController.instance.updateScoreText();
            Destroy(transform.parent.gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if(isUp)
            {
                anim.SetTrigger("hit");
                health--;
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            }
            else
            {
                anim.SetTrigger("hit");
                health--;
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, -jumpForce), ForceMode2D.Impulse);
            }
            
        }
    }
}