using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static MenuManager instance;
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
        listMenus[actualIDMenu].SetActive(false);
        listMenus[_nextMenuID].SetActive(true);
        actualIDMenu = _nextMenuID;
    }

    public void QuitGame()
    {
        Application.Quit();
    }    
}
