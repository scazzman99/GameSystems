using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour {

    public float projSpeed;
    public float damage;
    public Rigidbody projectile;
    public GameObject impact;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public virtual void Fire(Vector3 dir)
    {
        projectile.AddForce(dir * projSpeed, ForceMode.Impulse);
    }

    public virtual void OnCollisionEnter(Collision col)
    {
        
    }

}
