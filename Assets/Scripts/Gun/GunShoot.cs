using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShoot : MonoBehaviour {


    #region Vars
    public GameObject bullet;
    public Transform spawnPoint;
    public KeyCode fireButton;
    #endregion
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(fireButton))
        {
            //instantiate new bullet from prefab bullet
            GameObject clone = Instantiate(bullet, transform.position, transform.rotation);
            //get the component from new bullet
            Bullet newBullet = clone.GetComponent<Bullet>();
            //tell the bullet to fire
            newBullet.Fire(transform.forward);
        }
	}
}
