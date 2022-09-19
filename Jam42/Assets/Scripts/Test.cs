using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{

    [SerializeField]
    private float x = -6;
    void Start()
    {

    }
    void Update()
    {
        x += Time.deltaTime;
      transform.position = new Vector3 (x, 0, 0);
    }
}
