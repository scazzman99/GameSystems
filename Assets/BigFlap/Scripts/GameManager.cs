using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BigFlap
{
    public class GameManager : MonoBehaviour
    {
        #region Singleton
        //exception to camelCasing as this is a property
        public static GameManager Instance = null;
        private void Awake()
        {
            if(Instance != null)
            {
                Destroy(Instance);
            }
            Instance = this;
        }
        private void OnDestroy()
        {
            //dereference instance
            Instance = null;
        }
        #endregion
        public int score = 0;
        public bool isGameOver = false;

        //subscriber listener
        public delegate void IntCallBack(int number);
        //this is a container that people can subscribe to (if invoked scripts will know about it)
        public IntCallBack scoreAdded;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void AddScore(int scoreToAdd)
        {
            if (isGameOver)
            {
                return;
            }
            score += scoreToAdd;

            //Call subscribers
            scoreAdded.Invoke(score);
        }
    }
}
