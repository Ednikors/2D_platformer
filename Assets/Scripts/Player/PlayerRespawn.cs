using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    private Transform spawnPoint;
    private Health playerHealth;
    private UIManager uiManager;

    private void Awake()
    {
        playerHealth = GetComponent<Health>();
        uiManager = FindObjectOfType<UIManager>();
    }

    public void RespawnCheck()
    {
        if (spawnPoint == null) 
        {
            uiManager.GameOver();
            return;
        }

        playerHealth.Respawn();
        transform.position = spawnPoint.position; 

    }
}
