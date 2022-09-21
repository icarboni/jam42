using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public float timeToFinish = 0;
    public int coins = 0;
    [SerializeField] bool gameStarted = false;

    private void Awake()
    {
        DontDestroyOnLoad(this);
        Singleton();
    }
    private void Update()
    {
        Cronomechronometer();
        print("Hola");
    }

    public void StartGame(string _nextScene)
    {
        SceneManager.LoadScene(_nextScene);
    }



    private void Singleton()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);

    }
    public void Cronomechronometer()
    {
        if(timeToFinish < 100 && gameStarted)
         timeToFinish += Time.deltaTime;
    }

}

