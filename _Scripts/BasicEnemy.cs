using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{

    public float speed = 1;
    public int health = 20;
    public int damage = 5;
    public float aggroRange = 40;

    private Animator an;
    private SpriteRenderer sr;
    private bool aggro;
    private UnityStandardAssets._2D.PlatformerCharacter2D player;

    // Use this for initialization
    void Start()
    {
        an = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        aggro = false;
    }

    void FixedUpdate()
    {
        aggro = TestAggro();
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

    bool TestAggro()
    {
        Collider2D[] result = null;
        Physics2D.OverlapCircleNonAlloc(transform.position, aggroRange, result, layerMask: LayerMask.NameToLayer("Player"));
        if(result != null)
        {
            player = result[0].gameObject.GetComponent<UnityStandardAssets._2D.PlatformerCharacter2D>();
            return true;
        }
        else
        {
            return false;
        }
    }

    private void Flip()
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
            player.health -= damage;
            int direction;
            if (player.transform.position.x > transform.position.x)
            {
                direction = 1;
            }
            else
            {
                direction = -1;
            }
            player.GetComponent<Rigidbody2D>().AddForce(new Vector2(200 * direction,0));
        }
    }
}
