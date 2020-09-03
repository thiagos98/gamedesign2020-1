 using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;
    public float Speed;
    public float JumpForce;

    public bool isJumping=false;
    public bool doubleJump;

    private Rigidbody2D rig;
    private Animator anim;
    public Joystick joystick;
    public Bullet bullet;

    bool isBlowing;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        //Move o personagem em uma posicao
        //Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        //transform.position += movement * Time.deltaTime * Speed;

        float moviment = joystick.Horizontal;
        rig.velocity = new Vector2(moviment * Speed, rig.velocity.y);

        if (moviment > 0f)
        {
            anim.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f,0f,0f);
        }

        if (moviment < 0f)
        {
            anim.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }

        if (moviment == 0f)
        {
            anim.SetBool("walk", false);
        }
    }

    public void Jump()
    {
        if (!isBlowing)
        {
            if (!isJumping)
            {
                rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);//Impulse ou Force
                doubleJump = true;
                anim.SetBool("jump", true);
            }
            else
            {
                if (doubleJump)
                {
                    rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);//Impulse ou Force
                    doubleJump = false;
                }
            }
        }
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        GameController.instance.ShowGameOver();
        Destroy(gameObject);
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            isJumping = false;
            anim.SetBool("jump", false);

        }

        if(collision.gameObject.CompareTag("Finish"))
        {
            Debug.Log("Finalizou a fase");
        }

        if (collision.gameObject.CompareTag("Spike"))
        {
            GameController.instance.ShowGameOver();
            Destroy(gameObject);
        }

        if(collision.gameObject.CompareTag("Saw"))
        {
            GameController.instance.ShowGameOver();
            Destroy(gameObject);
        }
 
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            isJumping = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Upgrade"))
        {
            bullet.damage += 20;
        }
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        if(collider.gameObject.layer == 11)
        {
            isBlowing = true;
        }
    }
    void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.gameObject.layer == 11)
        {
            isBlowing = false;
        }
    }
}