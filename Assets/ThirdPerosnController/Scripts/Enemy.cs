using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace ThirdPersonController
{
    public class Enemy : MonoBehaviour
    {

        public enum State
        {
            Patrol = 0,
            Seek = 1
        }

        private Transform[] waypoints; //array of waypoints
        public Transform waypointParent; //parent of the array
        public Transform target; //player target
        int currentIndex = 1; //current spot in array
        public float stoppingDist = .5f;
        public float seekRad = 5f;
        public State myState = State.Patrol; //default state of patrol
        public NavMeshAgent agent;
        public float enemyHP = 20f;

        // Use this for initialization
        void Start()
        {
            waypoints = waypointParent.GetComponentsInChildren<Transform>(); //get waypoints from heirachy.
        }

        // Update is called once per frame
        void Update()
        {
            switch (myState)
            {
                case State.Patrol:
                    //patrol statements
                    Patrol();
                    break;
                case State.Seek:
                    //seek statements
                    Seek();
                    break;
                default:
                    break;
            }

        }

        void Patrol()
        {
            Transform point = waypoints[currentIndex];
            float distance = Vector3.Distance(transform.position, point.position);

            if (distance < stoppingDist)
            {
                currentIndex++;
                if (currentIndex >= waypoints.Length)
                {
                    currentIndex = 1;
                }

            }

            agent.SetDestination(point.position);
            float distToPlayer = Vector3.Distance(transform.position, target.position);
            if (distToPlayer <= seekRad)
            {
                myState = State.Seek;
            }
        }



        void Seek()
        {
            float distToPlayer = Vector3.Distance(transform.position, target.position);
            agent.SetDestination(target.position);

            if (distToPlayer > seekRad)
            {
                myState = State.Patrol;
            }

        }

        public void DealDamage(float damage)
        {
            enemyHP -= damage;
            if (enemyHP <= 0)
            {
                gameObject.SetActive(false);
            }
        }
    }
}

