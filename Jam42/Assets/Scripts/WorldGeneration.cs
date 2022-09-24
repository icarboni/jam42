using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGeneration : MonoBehaviour
{
    public GameObject parent;
    public GameObject []ground;
    public Platforms []blocks;
    public int platformNumber;
    public Transform firstPosition;
    public int numRandom;
    public int nextRandom;

    void Start()
    {
        numRandom = Random.Range(0, 5);
        for (int i = 0; i < platformNumber; i++)
        {
            Instantiate(ground[numRandom], firstPosition.position + new Vector3(17.75f * (i), 0, 0), Quaternion.identity, parent.transform);
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
                Instantiate(blocks[numRandom].platforms[Random.Range(0,9)], firstPosition.position + new Vector3(17.75f * (i), 0.4f, 0), Quaternion.identity, firstPosition);
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
