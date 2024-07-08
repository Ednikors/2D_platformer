using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelOpener : MonoBehaviour
{
    public void OpenPanel(){
        SceneManager.LoadSceneAsync(0);
    }
}
