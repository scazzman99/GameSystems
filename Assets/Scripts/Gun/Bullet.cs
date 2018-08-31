using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    //REMEMBER TO TURN OFF GRAVITY FOR THE BULLETS
    #region Vars
    public float damage = 10f;
    public float speed = 50f;
    public Rigidbody bullet;
    #endregion
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Fire(Vector3 direction)
    {
        //add force in given direction as an impulse
        bullet.AddForce(direction * speed, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other)
    {
        //get enemy componenet
        Enemy enemy = other.GetComponent<Enemy>();
        //if it is an enemy
        if (enemy)
        {
            enemy.DealDamage(damage);
            //destroy bullet
            Destroy(gameObject);
            Debug.Log("Take damage");
        }
    }
}
