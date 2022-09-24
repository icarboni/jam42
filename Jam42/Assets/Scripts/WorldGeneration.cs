using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGeneration : MonoBehaviour
{
    public GameObject parent;
    public GameObject []ground;
    public List<GameObject> Platforms;
    public int platformNumber;
    public Transform firstPosition;
    //public GameObject firstPlatform;
    public int numRandom;
    public int nextRandom;

    void Start()
    {
        numRandom = Random.Range(0, 5);
        for (int i = 0; i < platformNumber; i++)
        {
            GameObject temp;
            temp = Instantiate(ground[numRandom] ,firstPosition.position + new Vector3(17.8f * (i), 0, 0), Quaternion.identity);
            Platforms.Add(temp);
            temp.transform.SetParent(parent.transform);
            Debug.LogError(numRandom);
            if (numRandom == 0)
            {
                do
                    numRandom = Random.Range(0, 5);
                while (numRandom != 0 && numRandom != 3);
                Debug.Log(numRandom);
            }
            else if (numRandom == 1)
            {
                do
                    numRandom = Random.Range(0, 5);
                while (numRandom != 2 && numRandom != 4);
                Debug.Log(numRandom);
            }
            else if (numRandom == 2)
            {
                do
                    numRandom = Random.Range(0, 5);
                while (numRandom != 1 && numRandom != 4);
                Debug.Log(numRandom);
            }
            else if (numRandom == 3)
            {
                do
                    numRandom = Random.Range(0, 5);
                while (numRandom != 1 && numRandom != 2);
                Debug.Log(numRandom);
            }
            else
            {
                numRandom = 0;
                Debug.Log(numRandom);
            }


        }
    }

    
    void Update()
    {
        
    }
}
