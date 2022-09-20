using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static MenuManager instance;
    //public Transition transitionScript;
    public GameObject[] listMenus;
    [SerializeField]
    private int actualIDMenu = 0;

    private void Awake()
    {
        Singleton();
    }

    private void Singleton()
    {
        if (instance == null)
            instance = this;
    }

    public void ChangeMenu(int _nextMenuID)
    {
       // transitionScript.GoBlack();
        listMenus[actualIDMenu].SetActive(false);
        listMenus[_nextMenuID].SetActive(true);
        actualIDMenu = _nextMenuID;
        //transitionScript.GoWhite();
    }

    public void QuitGame()
    {
        Application.Quit();
    }    
}
