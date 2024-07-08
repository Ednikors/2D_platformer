using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void playLvl1(){
        SceneManager.LoadSceneAsync(1);
    }

    public void playLvl2(){
        SceneManager.LoadSceneAsync(2);
    }

    public void quitGame(){
        Application.Quit();
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; 
        #endif
    }
}

