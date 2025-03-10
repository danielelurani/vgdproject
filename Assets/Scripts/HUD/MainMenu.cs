using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
  
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);    
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("LoadSceneMenu");
    }

    public void QuitGame()
    {
        Destroy(GameObject.Find("Music"));
        Application.Quit();
    }
}
