using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private float timeToFinish = 0;
    [SerializeField] bool gameStarted = false;

    private void Awake()
    {
        DontDestroyOnLoad(this);
        Singleton();
    }
    private void Update()
    {
        Cronomechronometer();
    }

    public void StartGame(string _nextScene)
    {
        SceneManager.LoadScene(_nextScene);
    }



    private void Singleton()
    {
        if (instance == null)
            instance = this;

    }
    public void Cronomechronometer()
    {
        if(timeToFinish < 100 && gameStarted)
         timeToFinish += Time.deltaTime;
    }

}

