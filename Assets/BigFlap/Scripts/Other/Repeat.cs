using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BigFlap
{
    public class Repeat : MonoBehaviour
    {
        public float moveSpeed = 2f;
        public SpriteRenderer rend;
        public bool isRepeating = true;
        private float width;
        // Use this for initialization
        void Start()
        {
            // get the width of the collider and scale by transform
            if (rend)
            {
                width = rend.bounds.size.x;
            }
        }

        // Update is called once per frame
        void Update()
        {
            
            // Get position
            Vector3 pos = transform.position;
            //move position
            pos += Vector3.left * moveSpeed * Time.deltaTime;
            //if pos.x < -width
            if(pos.x < -width && isRepeating)
            {
                float offset = (width - .01f) * 2;
                // repeat = move to opposite side of the screen
                Vector3 newPos = new Vector3(offset, 0, 0);
                pos += newPos;
            }
            transform.position = pos;
        }
        
    }
}
