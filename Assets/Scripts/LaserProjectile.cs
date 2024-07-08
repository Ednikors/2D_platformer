using UnityEngine;

public class LaserProjectile : MonoBehaviour
{
    private float speed = 30;
    private bool hit;
    private float x, y, angle;
    private BoxCollider2D boxCollider;

    private float lifetime;
    // private Animator anim;

    private void Awake() {
        boxCollider = GetComponent<BoxCollider2D>();

    }

    private void Update()
{
        if (hit) return;

        float angleRad = transform.eulerAngles.z * Mathf.Deg2Rad;
        float deltaX = speed * x * Time.deltaTime * Mathf.Cos(angleRad);
        float deltaY = speed * x * Time.deltaTime * Mathf.Sin(angleRad);
        transform.Translate(new Vector2(deltaX, deltaY));

        float angleDeg = angleRad * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angleDeg);

        lifetime += Time.deltaTime;
        if(lifetime > 5){
            gameObject.SetActive(false);
        }
}

    private void OnTriggerEnter2D(Collider2D collision) {
        hit = true;
        boxCollider.enabled = false;
        if (collision.tag == "Enemy"&&collision.GetComponent<Health>()!=null)
            collision.GetComponent<Health>().TakeDamage(1);
        Deactivate();
    }

    public void SetDirection(float _x, float _y, float _angle){
        x = _x;
        y = _y;
        angle = _angle;
        transform.right = new Vector2(_x, _y);
        transform.eulerAngles = new Vector3(0, 0, _angle * Mathf.Rad2Deg);
        gameObject.SetActive(true);
        hit = false;
        boxCollider.enabled = true; 
        lifetime = 0;
    }

    private void Deactivate(){
        gameObject.SetActive(false);
    }
}
