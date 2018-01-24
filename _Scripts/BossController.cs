using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : BasicEnemy {

    private int count = 0;

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
