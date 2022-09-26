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
    public bool hadBreak;

    void Start()
    {
        lockersPoint = 0;
        lastIsLocker = false;
        shelterIn = false;
        numRandom = 4;
        hadBreak = false;

        for (int i = 0; i < platformNumber; i++)
        {
            Instantiate(ground[numRandom], firstPosition.position + new Vector3(17.75f * (i), 0, 0), Quaternion.identity, parent.transform);
            if (numRandom == 0)
            {

                if (i != 0)
                    Instantiate(blocks[numRandom].platforms[Random.Range(0, 5)], firstPosition.position + new Vector3(17.75f * (i), -1, 0), Quaternion.identity, firstPosition);
                do
                    numRandom = Random.Range(0, 7);
                while (numRandom != 0 && numRandom != 3);
                lastIsLocker = false;
            }
            else if (numRandom == 1)
            {

                Instantiate(blocks[numRandom].platforms[Random.Range(0,10)], firstPosition.position + new Vector3(17.75f * (i), 0.4f, 0), Quaternion.identity, firstPosition);
                do
                    numRandom = Random.Range(0, 8);
                while (numRandom != 1 && numRandom != 2 && numRandom != 4 && !(numRandom == 5 && lastIsLocker == false) && numRandom != 6 && numRandom != 7);
                lastIsLocker = false;
                hadBreak = true;
            }
            else if (numRandom == 2)
            {
                if (shelterIn == true)
                {
                    Instantiate(blocks[numRandom].platforms[Random.Range(0, 3)], firstPosition.position + new Vector3(17.75f * (i), -0.4f, 0), Quaternion.identity, firstPosition);
                    do
                        numRandom = Random.Range(1, 8);
                    while (numRandom != 1 && numRandom != 2 && numRandom != 4 && !(numRandom == 5 && lastIsLocker == false) && numRandom != 7);

                }
                else if (shelterIn == false)
                {
                    Instantiate(blocks[numRandom].platforms[Random.Range(3, 6)], firstPosition.position + new Vector3(17.75f * (i), -0.4f, 0), Quaternion.identity, firstPosition);
                    do
                        numRandom = Random.Range(1, 8);
                    while (numRandom != 1 && numRandom != 4 && !(numRandom == 5 && lastIsLocker == false) && numRandom != 6 && numRandom != 7);
                }
                lastIsLocker = false;
            }
            else if (numRandom == 3)
            {
                Instantiate(blocks[numRandom].platforms[Random.Range(0, 4)], firstPosition.position + new Vector3(17.75f * (i), -1, 0), Quaternion.identity, firstPosition);

                do
                    numRandom = Random.Range(0, 8);
                while (numRandom != 1 && numRandom != 2 && !(numRandom == 5 && lastIsLocker == false) && numRandom != 6 && numRandom != 7);
                lastIsLocker = false;
            }
            else if (numRandom == 4)
            {
                if (i != 0)
                    Instantiate(blocks[numRandom].platforms[Random.Range(0, 4)], firstPosition.position + new Vector3(17.75f * (i), -1, 0), Quaternion.identity, firstPosition);
                numRandom = 0;
                lastIsLocker = false;
            }
            else if (numRandom == 5)
            {
                if (lockersPoint == 0)
                {
                    Instantiate(blocks[numRandom].platforms[Random.Range(0,2)], firstPosition.position + new Vector3(17.75f * (i), -0.4f, 0), Quaternion.identity, firstPosition);
                    numRandom = 5;
                    lockersPoint = Random.Range(1, 3);
                    //while (numRandom != 1 && numRandom != 2 && numRandom != 4 && numRandom != 5);
                }
                else if (lockersPoint == 1)
                {
                    Instantiate(blocks[numRandom].platforms[Random.Range(2, 4)], firstPosition.position + new Vector3(17.75f * (i), -0.4f, 0), Quaternion.identity, firstPosition);
                    do
                        numRandom = Random.Range(0, 8);
                    //while (numRandom != 5);
                    while (numRandom != 4 && numRandom != 5 && numRandom != 7);
                    if (numRandom == 5)
                        lockersPoint = Random.Range(1, 3);
                }
                else if (lockersPoint == 2)
                {
                    Instantiate(blocks[numRandom].platforms[Random.Range(4, 6)], firstPosition.position + new Vector3(17.75f * (i), -0.4f, 0), Quaternion.identity, firstPosition);
                    do
                        numRandom = Random.Range(0, 8);
                    while (numRandom != 1 && numRandom != 2 && numRandom != 4 && numRandom != 6 && numRandom != 7);

                }
                if (numRandom != 5)
                {
                    lockersPoint = 0;
                    lastIsLocker = true;
                }
            }
            else if (numRandom == 6)
            {
                do
                    numRandom = Random.Range(0, 8);
                while (numRandom != 2 && numRandom != 4 && !(numRandom == 5 && lastIsLocker == false) && numRandom != 7);
                lastIsLocker = false;
            }
            else if (numRandom == 7)
            {
                if (hadBreak == false)
                    numRandom = 1;
                else
                {
                    do
                        numRandom = Random.Range(0, 7);
                    while (numRandom != 2 && numRandom != 4 && !(numRandom == 5 && lastIsLocker == false) && numRandom != 6);
                }
                lastIsLocker = false;
            }
            if (shelterIn == false && numRandom == 2)
                shelterIn = true;
            else shelterIn = false;

            if (hadBreak == true && numRandom != 7)
                hadBreak = false;

        }
    }

    
    void Update()
    {
        
    }
}
