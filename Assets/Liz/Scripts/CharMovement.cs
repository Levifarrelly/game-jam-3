using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMovement : MonoBehaviour
{
    public float speed = 10;

   // public Vector3 jump;
    public float jumpHeight = 7f;
    public bool isJumping = false;

    Rigidbody2D rb = null;
    GameObject enemy;
    GameObject player;
    //public float force;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //jump = new Vector3(0, 2, 0);
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");

        transform.position += Vector3.right * horizontal * Time.deltaTime * speed;
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, 0, 100), transform.position.y, transform.position.z);
        
        
        if (Input.GetKeyDown(KeyCode.UpArrow) && (isJumping == false))
        {
            rb.AddForce(new Vector3(0, jumpHeight, 0), ForceMode2D.Impulse);
            
            //transform.position += 5 * transform.up;
            //rb.AddForce(jump * jumpForce, ForceMode2D.Impulse);
            //isGrounded = false;
            //.position = new Vector3(transform.position.x, (Mathf.Clamp(transform.position.y, 0, 10), transform.position.z);
        }
        
             
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Platform")
        {
            isJumping = false;
        }

        
    }

  

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Platform")
        {
            isJumping = true;
        }
    }
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //if (collision.gameObject.tag == "Platform")
    //{
    // rb.gravityScale = 0;
    // rb.velocity = Vector3.zero;
    // }
    // }
}
