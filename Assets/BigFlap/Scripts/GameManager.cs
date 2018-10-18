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

        public bool isGameOver = false;


        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
