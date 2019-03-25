using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelControll : MonoBehaviour
{
    public Button Lvl2, Lvl3, Lvl4;
    public static int levelPassed = 0;
    // Start is called before the first frame update
    void Start()
    {
        Lvl2.interactable = false;
        Lvl3.interactable = false;
        Lvl4.interactable = false;
        switch (levelPassed)
        {
            case 1:
                Lvl2.interactable = true;
                break;
            case 2:
                Lvl2.interactable = true;
                Lvl3.interactable = true;
                break;
            case 3:
                Lvl2.interactable = true;
                Lvl3.interactable = true;
                Lvl4.interactable = true;
                break;
        }
                

    }
}
