using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ThirdPersonController
{
    public class Pistol : Weapon
    {


        #region PistolVars

        #endregion


        public override void Attack()
        {

            //instantiate new bullet from prefab bullet
            GameObject clone = Instantiate(projectile, spawnP.position, spawnP.rotation);
            //get the component from new bullet
            Bullet newBullet = clone.GetComponent<Bullet>();
            //tell the bullet to fire
            newBullet.Fire(spawnP.forward);

        }
    }
}
