using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossController : BasicEnemy {

    private int count = 60;

    public GameObject[] projectiles;
    
    // Update is called once per frame
	void FixedUpdate () {
        if (this.aggro)
        {
            if (count % 60 == 0) {
                Instantiate(projectiles[0], new Vector3(transform.position.x - 2, transform.position.y, 0), new Quaternion());
            }
            count++;
        }
	}
}
