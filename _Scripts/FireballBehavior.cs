using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballBehavior : MonoBehaviour {

    protected GameObject player;

    private static Vector3 initPos;
    public int damage;
    
    void Start()
    {
        player = GameObject.Find("Player");
        initPos = transform.position;
    }
    
    // Update is called once per frame
    void FixedUpdate () {
        Transform t = player.transform;
        transform.Translate((t.position - initPos) *Time.deltaTime, Space.World);
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.Equals(player))
        {
            player.GetComponent<UnityStandardAssets._2D.PlatformerCharacter2D>().TakeDamage(damage);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
