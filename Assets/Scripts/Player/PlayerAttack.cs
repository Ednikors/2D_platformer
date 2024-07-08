
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private PlayerMovement playerMovement;
    [SerializeField] private Transform firepoint;
    [SerializeField] private GameObject[] laser;
    [SerializeField] private float coolDown;
    [SerializeField] private AudioClip laserSound;
    private float coolDownTimer = Mathf.Infinity;
    private GameObject gunObject;

    private void Awake() {
        playerMovement = GetComponent<PlayerMovement>();
        gunObject = GameObject.Find("Gun");
    }

private void Update() {
    if(Input.GetMouseButton(0)&&coolDownTimer>coolDown&&playerMovement.canAttack()){
        Attack();
    }
    coolDownTimer += Time.deltaTime;
}

private void Attack(){
    SoundManager.instance.PlaySound(laserSound);
    coolDownTimer = 0;
    laser[FindLaser()].transform.position = gunObject.transform.position;
    laser[FindLaser()].GetComponent<LaserProjectile>().SetDirection(transform.localScale.x, transform.localScale.y, gunObject.transform.rotation.z);
}

private int FindLaser()
    {
        for (int i = 0; i < laser.Length; i++)
        {
            if (!laser[i].activeInHierarchy)
                return i;
        }
        return 0;
    }
}
