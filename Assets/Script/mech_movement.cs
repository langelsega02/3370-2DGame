using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class mech_movement : MonoBehaviour
{
    Rigidbody2D rb;

    float speedX;
    public float speed;
    //private bool isFacingRight = true;

    [SerializeField] float buttonTime = 0.5f;
    [SerializeField] float jumpHeight = 5f;
    //[SerializeField] float cancelRate = 100;
    [SerializeField] float jump;
    float jumpTime;
    //bool jumpCancelled;
    bool jumping;

    //bool isGrounded;

    //public Transform inGround;
    public LayerMask groundLayer;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //isGrounded = Physics2D.OverlapCapsule(inGround.position, new Vector2(2.5f, 1.0f), CapsuleDirection2D.Horizontal, 0, groundLayer);
        speedX = Input.GetAxisRaw("Horizontal") * speed;

        if (Input.GetKeyDown(KeyCode.Space) /*&& IsGrounded()*/)
        {
            rb.velocity = new Vector2(0, 0);
            float jumpForce = Mathf.Sqrt(jumpHeight * -2 * (Physics2D.gravity.y * rb.gravityScale));
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            jumping = true;
            //jumpCancelled = false;
            jumpTime = 0;
            //rb.velocity = new Vector2(rb.velocity.x, jump);
        }
        if (jumping)
        {
            jumpTime += Time.deltaTime;

            /*if (Input.GetKeyUp(KeyCode.Space))
            {
                //cancel jump
               /jumpCancelled = true;
            }*/
            if (jumpTime > buttonTime)
            {
                jumping = false;
            }
        }
        rb.velocity = new Vector2(speedX, rb.velocity.y);
        //Flip();
    }
    /*bool IsGrounded()
    {
        Vector2 position = transform.position;
        Vector2 direction = Vector2.down;
        float distance = 0.5f;

        Debug.DrawRay(position, direction, Color.green);
        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, groundLayer);
        if (hit.collider != null)
        {
            return true;
        }

        return false;
    }*/
    private void FixedUpdate()
    {
        /*if (jumpCancelled && jumping && rb.velocity.y > 0)
        {
            rb.AddForce(Vector2.down * cancelRate);
        }*/
    }

    /*private void Flip()
    {
        if (isFacingRight && speedX < 0f || !isFacingRight && speedX > 0f)
        {
            isFacingRight = !isFacingRight;

            transform.Rotate(0f, 180f, 0f); 
        }
    }*/

}