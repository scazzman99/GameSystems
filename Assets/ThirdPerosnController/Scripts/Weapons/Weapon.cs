using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ThirdPersonController
{
    public abstract class Weapon : MonoBehaviour
    {

        public int damage = 50;
        public float acc = 1f;
        public float range = 10f;
        public float fireRate = 5f;
        public int ammo = 10;
        public GameObject projectile;
        protected int currentAmmo = 0;
        public Transform spawnP;

        //Method is abstract and will be overriden elsewhere. No body as it is abstract
        public abstract void Attack();



        public void Reload()
        {
            currentAmmo = ammo;
        }

    }
}
