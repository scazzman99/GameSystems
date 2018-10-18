using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BigFlap
{
    public class Player : MonoBehaviour
    {
        public float upforce = 2f;
        public bool isDead = false;
        public Rigidbody2D rigid;

        // Use this for initialization
        void Start()
        {
            rigid = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
            //if player hits space add force up and cancel current velocity
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Flap();
            }
        }
        

        void Flap()
        {
            if (!isDead)
            {
                //cancel velocity and apply force upwards
                rigid.velocity = Vector2.zero;
                rigid.AddForce(Vector2.up * upforce, ForceMode2D.Impulse);
            }
        }
    }
}
