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
    public int lockersPoint;
    public bool lastIsLocker;
    public bool shelterIn;

    void Start()
    {
        lockersPoint = 0;
        lastIsLocker = false;
        shelterIn = false;
        do
            numRandom = Random.Range(0, 6);
        while (numRandom != 0 && numRandom != 4);
        for (int i = 0; i < platformNumber; i++)
        {
            Instantiate(ground[numRandom], firstPosition.position + new Vector3(17.75f * (i), 0, 0), Quaternion.identity, parent.transform);
            if (numRandom == 0)
            {

                if (i != 0)
                    Instantiate(blocks[numRandom].platforms[Random.Range(0, 5)], firstPosition.position + new Vector3(17.75f * (i), -1, 0), Quaternion.identity, firstPosition);
                do
                    numRandom = Random.Range(0, 6);
                while (numRandom != 0 && numRandom != 3);
                lastIsLocker = false;
            }
            else if (numRandom == 1)
            {

                Instantiate(blocks[numRandom].platforms[Random.Range(0,9)], firstPosition.position + new Vector3(17.75f * (i), 0.4f, 0), Quaternion.identity, firstPosition);
                do
                    numRandom = Random.Range(0, 6);
                while (numRandom != 1 && numRandom != 2 && numRandom != 4 && !(numRandom == 5 && lastIsLocker == false));
                lastIsLocker = false;
            }
            else if (numRandom == 2)
            {
                if (shelterIn == true)
                {
                    Instantiate(blocks[numRandom].platforms[Random.Range(0, 3)], firstPosition.position + new Vector3(17.75f * (i), -0.4f, 0), Quaternion.identity, firstPosition);
                    do
                        numRandom = Random.Range(1, 6);
                    while (numRandom != 1 && numRandom != 2 && numRandom != 4 && !(numRandom == 5 && lastIsLocker == false));

                }
                else if (shelterIn == false)
                {
                    Instantiate(blocks[numRandom].platforms[Random.Range(3, 6)], firstPosition.position + new Vector3(17.75f * (i), -0.4f, 0), Quaternion.identity, firstPosition);
                    do
                        numRandom = Random.Range(1, 6);
                    while (numRandom != 1 && numRandom != 4 && !(numRandom == 5 && lastIsLocker == false));
                }
                lastIsLocker = false;
            }
            else if (numRandom == 3)
            {
                do
                    numRandom = Random.Range(0, 6);
                while (numRandom != 1 && numRandom != 2 && !(numRandom == 5 && lastIsLocker == false));
                lastIsLocker = false;
            }
            else if (numRandom == 4)
            {
                numRandom = 0;
                lastIsLocker = false;
            }
            else if (numRandom == 5)
            {
                Instantiate(blocks[numRandom].platforms[lockersPoint], firstPosition.position + new Vector3(17.75f * (i), -0.4f, 0), Quaternion.identity, firstPosition);
                if (lockersPoint == 0)
                {
                    numRandom = 5;
                    lockersPoint = Random.Range(1, 3);
                    //while (numRandom != 1 && numRandom != 2 && numRandom != 4 && numRandom != 5);
                }
                else if (lockersPoint == 1)
                {
                    do
                        numRandom = Random.Range(0, 6);
                    //while (numRandom != 5);
                    while (numRandom != 4 && numRandom != 5);
                    if (numRandom == 5)
                        lockersPoint = Random.Range(1, 3);
                }
                else if (lockersPoint == 2)
                {
                    do
                        numRandom = Random.Range(0, 6);
                    while (numRandom != 1 && numRandom != 2 && numRandom != 4);

                }
                if (numRandom != 5)
                {
                    lockersPoint = 0;
                    lastIsLocker = true;
                }
            }
            if (shelterIn == false && numRandom == 2)
                shelterIn = true;
            else shelterIn = false;

        }
    }

    
    void Update()
    {
        
    }
}
