using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossController : BasicEnemy {

    private int count = 60;

    public GameObject[] projectiles;
    public GameObject shooter;
    
    // Update is called once per frame
	void FixedUpdate () {
        if (this.aggro)
        {
            if (count % 60 == 0) {
                Instantiate(projectiles[0], shooter.transform.position, Quaternion.identity);
            }
            count++;
        }
	}

    public void TakeDamage(int dam)
    {
        health -= dam;
        if (health <= 0)
        {
            SceneManager.LoadScene("Win");
        }
    }
}
