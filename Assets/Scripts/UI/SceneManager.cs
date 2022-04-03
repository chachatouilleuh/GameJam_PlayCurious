using System;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class SceneManager : MonoBehaviour
{
    private float m_choix ;
    // SCENE TRANSITION
    private void Awake()
    {
        m_choix = PlayerPrefs.GetFloat("choix");
    }

    public void OpenMenuScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene (sceneName:"Menu");
    }

    public void OpenCredits()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene (sceneName:"Credits");
    }
    
    public void OpenGameScene()
    {
        if (m_choix == 1)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene (sceneName:"Game2");

        }if (m_choix == 2)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene (sceneName:"Game1");

        }
    }
    
    //PAUSE
    
    // public void PauseGame ()
    // {
    //     Time.timeScale = 0;
    //     AudioListener.pause = true;
    // }
    //
    // public void ResumeGame ()
    // {
    //     Time.timeScale = 1;
    //     AudioListener.pause = false;
    // }

}