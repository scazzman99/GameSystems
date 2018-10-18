using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BigFlap
{
    public class FlappyScore : MonoBehaviour
    {
        public Sprite[] numbers; //store all flappy digits ;)
        public GameObject scoreTextPrefab; //score prefab text element to make
        public Vector3 standbyPos = new Vector3(-15, 15); //pos offscreen
        public int maxDigits = 5; //amount of digits to store offscreen

        private GameObject[] scoreTextPool;
        private int[] digits;
        // Use this for initialization
        void Start()
        {
            SpawnPool();
            //Subscribe to scoreAdded function in GameManager
            GameManager.Instance.scoreAdded += RefreshScore;
        }

        // Update is called once per frame
        void Update()
        {

        }

        void RefreshScore(int score)
        {
            //convert score to array of digits
            int[] digits = GetDigits(score);
            //loop thru
            for(int i = 0; i < digits.Length; i++)
            {
                //get digit val
                int value = digits[i];
                //Get correspondng text element
                GameObject textElement = scoreTextPool[i];
                //get image componenet
                Image img = textElement.GetComponent<Image>();
                //assign sprite to number using val
                img.sprite = numbers[value];
                //activate the text element
                textElement.SetActive(true);
            }

            //loop thru all remaining text elements in pool
            for(int i = digits.Length; i < scoreTextPool.Length; i++)
            {
                //deactivate element
                scoreTextPool[i].SetActive(false);
            }
        }

        private void OnDestroy()
        {
            //unsubbin
            GameManager.Instance.scoreAdded -= RefreshScore;
        }

        void SpawnPool()
        {
            scoreTextPool = new GameObject[maxDigits];

            //loop thru digits
            for(int i = 0; i < maxDigits; i++)
            {
                //create new game object offscreen
                GameObject clone = Instantiate(scoreTextPrefab, standbyPos, Quaternion.identity);
                //get image component
                Image img = clone.GetComponent<Image>();
                //attach to seld
                img.sprite = numbers[i];
                clone.transform.SetParent(transform);
                clone.name = i.ToString();
                //add to pool
                scoreTextPool[i] = clone;


            }
        }

        int[] GetDigits(int number)
        {
            List<int> digits = new List<int>();
            //while number is greater than 10
            while(number >= 10)
            {
                //modulus by 10
                digits.Add(number % 10);
                //divide total by 10
                number /= 10;
            }

            //add last number to digits
            digits.Add(number);
            //flip the number around (it is backwards)
            digits.Reverse();
            //return array
            return digits.ToArray();
        }
    }
}
