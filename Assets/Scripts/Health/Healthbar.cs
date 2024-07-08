using UnityEngine.UI;
using UnityEngine;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private Health playerHealth;
    [SerializeField] private Image totalHealthBar;
    [SerializeField] private Image curHealthBar;


    private void Start() {
        totalHealthBar.fillAmount = playerHealth.currentHealth/10;
    }

    private void Update() {
        curHealthBar.fillAmount = playerHealth.currentHealth/10;

    }
}
