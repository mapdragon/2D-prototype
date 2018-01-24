using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{

    public float speed = 1;
    public int health = 20;
    public int damage = 5;

    protected Animator an;
    protected SpriteRenderer sr;
    public bool aggro;
    protected GameObject player;

    // Use this for initialization
    void Start()
    {
        an = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        aggro = false;
        player = GameObject.Find("Player");
    }

    void FixedUpdate()
    {
        an.SetBool("Moving", aggro);

        if (aggro)
        {
            if (player.transform.position.x > transform.position.x)
            {
                transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0), Space.World);
                if (!sr.flipX)
                {
                    Flip();
                }
            }
            else
            {
                transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0), Space.World);
                if (sr.flipX)
                {
                    Flip();
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            aggro = true;
            this.gameObject.GetComponent<CircleCollider2D>().enabled = false;
        }
    }

    protected void Flip()
    {
        sr.flipX = !sr.flipX;
        
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    public void TakeDamage(int dam)
    {
        health -= dam;
        if (health <= 0)
        {
            this.gameObject.SetActive(false);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.GetComponent<UnityStandardAssets._2D.PlatformerCharacter2D>().TakeDamage(damage);
        }
    }
}
