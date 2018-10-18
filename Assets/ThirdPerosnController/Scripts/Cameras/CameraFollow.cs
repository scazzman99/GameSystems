using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ThirdPersonController
{
    public class CameraFollow : MonoBehaviour
    {

        public Transform target; //so we know who we are following

        private Vector3 offset;

        // Use this for initialization
        void Start()
        {
            offset = transform.position - target.position; //gives camera its starting offset based on how far away it is from the target it's following. this will keep the camera here without attaching it to player!
        }

        // Update is called once per frame
        void Update()
        {
            transform.position = target.position + offset; //sets camera's position to wherever the target plus offset to simulate a camera following the player
        }
    }
}
