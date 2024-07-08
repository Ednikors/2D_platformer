
using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Health")]
    [SerializeField]private float startHealth;
    public float currentHealth{get; private set;}
    private Animator anim;
    private bool dead;
    [Header("Components")]
    [SerializeField] private Behaviour[] components;

    [Header("Audio")]
    [SerializeField] private AudioClip impact;
    [SerializeField] private AudioClip die;

    private void Awake() {
        currentHealth = startHealth;
        anim = GetComponent<Animator>();
    }

    public void TakeDamage(float _damage){
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startHealth);

        if(currentHealth > 0){
            anim.SetTrigger("hurt");
            SoundManager.instance.PlaySound(impact);
        } else
        {
            if (!dead)
            {
                anim.SetTrigger("die");
                SoundManager.instance.PlaySound(die);

                foreach (Behaviour component in components)
                    component.enabled = false;

                dead = true;
            }
        }
    }

    public void AddHealth(float _health){
        currentHealth = Mathf.Clamp(currentHealth + _health, 0, startHealth);
    }

    // private void Update() {
    //     if(Input.GetKeyDown(KeyCode.E)){
    //         TakeDamage(1);
    //     }
    // }

    private void Deactivate(){
        gameObject.SetActive(false);
    }

    public void Respawn()
    {
        AddHealth(startHealth);
        anim.ResetTrigger("die");
        anim.Play("Idle");
        dead = false;

        //Activate all attached component classes
        foreach (Behaviour component in components)
            component.enabled = true;
    }
}
