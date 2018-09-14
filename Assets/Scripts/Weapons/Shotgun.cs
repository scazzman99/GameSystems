using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapon {

    #region Shotgun Variables
    public int pellets = 6;
    public bool canFire = true;
    #endregion


    public override void Attack()
    {
        if (canFire)
        {
            for (int i = 0; i < pellets; i++)
            {
                //store the forward direction of the player
                Vector3 dir = transform.forward;
                //Calculate offset using range
                Vector3 spread = Vector3.zero;
                //Offset on local Y
                spread += transform.up * Random.Range(-acc * 0.2f, acc * 0.2f);
                //Offset on local X
                spread += transform.right * Random.Range(-acc * 0.2f, acc * 0.2f);


                //instantiate new bullet from prefab bullet
                GameObject clone = Instantiate(projectile, spawnP.position, spawnP.rotation);
                //get the component from new bullet
                Grenade newBullet = clone.GetComponent<Grenade>();
                //tell the bullet to fire in direction + spread variation
                newBullet.Fire(dir + spread);
            }
            canFire = false;
            ammo--;
            StartCoroutine(FireReset(1f));
        }

    }

    public IEnumerator FireReset(float fireRate)
    {
        float timeWait = 1f / fireRate;
        yield return new WaitForSecondsRealtime(timeWait);
        canFire = true;
    }
}

