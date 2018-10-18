using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BigFlap
{
    public class ColumnSpawner : MonoBehaviour
    {
        public GameObject prefab;
        public int columnPoolSize = 5;
        public float spawnRate = 3f;
        public float minY = -1f;
        public float maxY = 3.5f;
        public Vector3 standbyPos = new Vector3(-15, -25);
        //start point for the column
        public float startX = 10f;
        

        private Transform[] columns;
        private int currentColumn = 0;
        private float spawnTimer = 0f;

        // Use this for initialization
        void Start()
        {
            SpawnColumns();
        }

        // Update is called once per frame
        void Update()
        {
            //increase the timer
            spawnTimer += Time.deltaTime;
            //is the game not over AND spawn timer reached spawnrate
            if(!GameManager.Instance.isGameOver && spawnTimer >= spawnRate)
            {
                //reset timer
                spawnTimer = 0f;
                //Reposition the column
                RepositionColumns();
            }
        }

        void SpawnColumns()
        {
            //create pool to store the columns
            //loop thru the pool
            //fill each element with a new column

            columns = new Transform[columnPoolSize];

            for(int i = 0; i < columns.Length; i++)
            {
                GameObject clone = Instantiate(prefab, transform); //create the clone of prefab
                Transform column = clone.transform; // set transform to clones
                column.position = standbyPos; //put column to standbyPos
                columns[i] = column; //add the column to the array
            }
        }

        void RepositionColumns()
        {
            //Get random Y pos
            //get current column
            //reposition that colum
            //incriment currentColumn
            //if current column exceeds pool size
            //Set current Colum back to zero

            float yPos = Random.Range(minY, maxY);
            Transform column = columns[currentColumn];
            column.position = new Vector3(startX, yPos);
            currentColumn++;
            if(currentColumn > columns.Length - 1)
            {
                currentColumn = 0;
            }
        }
    }
}
