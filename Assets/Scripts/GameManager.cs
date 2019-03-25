using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject GameMenue;
    public GameObject GameOverMenu;
    public GameObject AudioManager;
    public GameObject LevelComplete;
    public GameObject Player;
 


    //Game Mode Handling--------------------------------------------------------------
    public void StartGame()
    {
       Time.timeScale = 1f;
       AudioManager.GetComponent<AudioManager>().Play("Backgroundmusic");
      
    }

    public void PauseGame()
    {
        GameMenue.SetActive(true);
        Time.timeScale = 0f;
        AudioManager.GetComponent<AudioManager>().Stop("Backgroundmusic");
        Player.GetComponent<PlayerMovement>().pause = true;
    }
    public void Resume()
    {
        Time.timeScale = 1f;
        AudioManager.GetComponent<AudioManager>().Resume("Backgroundmusic");
        Player.GetComponent<PlayerMovement>().pause = false;
    }
    public void GameOver()
    {

        GameOverMenu.SetActive(true);
        Time.timeScale = 0f;
        AudioManager.GetComponent<AudioManager>().Stop("Backgroundmusic");
    }

    public void HitFinish()
    {
        LevelControll.levelPassed = SceneManager.GetActiveScene().buildIndex;
        Invoke("nextScene", 3f);
        Player.GetComponent<PlayerMovement>().pause = true;
        LevelComplete.SetActive(true);
        
    }
    //Game Mode Handling--------------------------------------------------------------

    
    void nextScene()
    {
        //DontDestroyOnLoad(AudioManager);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


    //Menu Optionen ------------------ HANDLER
    public void GoToMain()
    {
        SceneManager.LoadScene(0);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    //Menu Optionen ------------------ HANDLER
}
