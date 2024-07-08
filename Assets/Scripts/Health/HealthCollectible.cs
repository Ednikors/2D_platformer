using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    private float healthValue = 1;
    [SerializeField] private AudioClip pickUp;

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag == "Player"){
            collision.GetComponent<Health>().AddHealth(healthValue);
            gameObject.SetActive(false);
            SoundManager.instance.PlaySound(pickUp);
        }
    }
}
