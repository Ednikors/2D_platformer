
using UnityEngine;

public class LowerPlatform : MonoBehaviour
{
    [SerializeField] private Health playerHealth;

    public void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag == "Player"){
            playerHealth.TakeDamage(10);
        }
    }
}
