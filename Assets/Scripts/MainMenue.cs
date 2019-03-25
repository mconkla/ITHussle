using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainMenue : MonoBehaviour
{

    public GameObject lvlcontroll;
    public Slider slider;
    public GameObject lvlmanager;
  



    [HideInInspector]
    public static float stored;

 
    public void LoadLvl(Button btn)
    {

        DontDestroyOnLoad(lvlcontroll);
 
        SceneManager.LoadScene(int.Parse(btn.name));
       
    }


    public void QuitGame()
    {
        Application.Quit();
    }


    public void StoreValue()
    {
        stored = slider.value;
    }


}



