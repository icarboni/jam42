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


        for (int i = 1; i < platformNumber; i++)
        {
            do
                numRandom = Random.Range(0, 5);
            while (numRandom != 0 && numRandom != 4);
            Instantiate(ground[numRandom], firstPosition.position + new Vector3(17.75f * (0), 0, 0), Quaternion.identity, parent.transform);

            Instantiate(ground[numRandom], firstPosition.position + new Vector3(17.75f * (i), 0, 0), Quaternion.identity, parent.transform);
            if (numRandom == 0)
            {
                Instantiate(blocks[numRandom].platforms[Random.Range(0, 5)], firstPosition.position + new Vector3(17.75f * (i), -1, 0), Quaternion.identity, firstPosition);
                do
                    numRandom = Random.Range(0, 5);
                while (numRandom != 0 && numRandom != 3);
            }
            else if (numRandom == 1)
            {
                Instantiate(blocks[numRandom].platforms[Random.Range(0,9)], firstPosition.position + new Vector3(17.75f * (i), 0.4f, 0), Quaternion.identity, firstPosition);
                do
                    numRandom = Random.Range(0, 5);
                while (numRandom != 2 && numRandom != 4);
            }
            else if (numRandom == 2)
            {
                Instantiate(blocks[numRandom].platforms[Random.Range(0, 3)], firstPosition.position + new Vector3(17.75f * (i), -0.4f, 0), Quaternion.identity, firstPosition);
                do
                    numRandom = Random.Range(0, 5);
                while (numRandom != 1 && numRandom != 4);
            }
            else if (numRandom == 3)
            {
                do
                    numRandom = Random.Range(0, 5);
                while (numRandom != 1 && numRandom != 2);
            }
            else
            {
                numRandom = 0;
            }


        }
    }

    
    void Update()
    {
        
    }
}
