
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D body;
    private Animator anim;
    [SerializeField] private float speed;

    private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private AudioClip jumpSound;

    private float verticalInpt;
    private bool isLadder;
    private bool isClimbing;


    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        float horizontalInpt = Input.GetAxis("Horizontal");
        verticalInpt = Input.GetAxis("Vertical");
        body.velocity = new Vector2(horizontalInpt * speed, body.velocity.y);
        

        if (horizontalInpt > 0.01f)
        {
            transform.localScale = Vector3.one;
        }
        else if (horizontalInpt < -0.01f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        if (Input.GetKey(KeyCode.Space) && isGrounded())
        {
            body.velocity = new Vector2(body.velocity.x, speed);
            anim.SetTrigger("jump");
            SoundManager.instance.PlaySound(jumpSound);
        }

        if(isLadder && verticalInpt > 0.01f){
            isClimbing = true;
            anim.SetTrigger("climb");
        }

        anim.SetBool("run", horizontalInpt!=0);
        anim.SetBool("grounded", isGrounded());
        anim.SetBool("onLadder", isLadder);
    }

    private void FixedUpdate() {
        if(isClimbing){
            body.gravityScale = 0f;
            body.velocity = new Vector2(body.velocity.x, verticalInpt*speed);
        } else{
            body.gravityScale = 1f;
        }
    }

    private bool isGrounded(){
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size,
                                                    0, Vector2.down, 0.1f, groundLayer); 
        return raycastHit.collider != null;
    }

    public bool canAttack(){
        return !isLadder;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("ladder")){
            isLadder = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if(collision.CompareTag("ladder")){
            isLadder = false;
            isClimbing = false;
        }
    }
}
