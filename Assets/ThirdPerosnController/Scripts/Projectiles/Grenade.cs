using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ThirdPersonController
{
    public class Grenade : Projectile
    {

        public float blastRad;
        public float blowback;
        public GameObject explosion;
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public override void Fire(Vector3 dir)
        {
            projectile.AddForce(dir * projSpeed, ForceMode.Impulse);
        }

        void Explode()
        {
            Collider[] hits = Physics.OverlapSphere(transform.position, blastRad);
            foreach (var hit in hits)
            {
                Enemy e = hit.GetComponent<Enemy>();
                if (e)
                {
                    e.DealDamage(damage);
                }
            }
        }

        void Effects()
        {
            Instantiate(explosion, transform.position, transform.rotation);

        }

        public override void OnCollisionEnter(Collision col)
        {
            string tag = col.collider.tag;
            if (tag != "Player" && tag != "Weapon")
            {
                Effects();
                Explode();
                Destroy(gameObject);
            }
        }
    }
}
