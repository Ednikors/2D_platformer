using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D body;
    private Animator anim;
    [SerializeField] private float speed;

    private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask groundLayer;


    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        float horizontalInpt = Input.GetAxis("Horizontal");
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
        }

        anim.SetBool("run", horizontalInpt!=0);
        anim.SetBool("grounded", isGrounded());
    }

    // private void Jump(){
        
    // }
    private bool isGrounded(){
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size,
                                                    0, Vector2.down, 0.1f, groundLayer); 
        return raycastHit.collider != null;
    }


    public bool canAttack(){
        return true;
    }
}
