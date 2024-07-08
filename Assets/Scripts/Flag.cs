using UnityEngine;
using UnityEngine.SceneManagement;

public class Flag : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag == "Player"){
            SceneManager.LoadSceneAsync(2);
        }
    }
}
