using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class SceneManager : MonoBehaviour
{
    // SCENE TRANSITION
    
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
        UnityEngine.SceneManagement.SceneManager.LoadScene (sceneName:"Game 1");
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