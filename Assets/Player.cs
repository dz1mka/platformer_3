using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float movement = 0f;
    public float speed = 5f;
    private bool facingRight = true;
    public Rigidbody2D rb;
    public float jumpHeight = 10f;
    private bool isGround = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * speed;

        if (movement < 0f && facingRight == true)
        {
            transform.eulerAngles = new Vector3(0, -180f, 0);
            facingRight = false;
        }
        else if (movement > 0f && facingRight == false)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            facingRight = true;
        }

        if (Input.GetKey(KeyCode.Space) && isGround == true)
        {
            Jump();
            isGround = false;
        }
    }

    void Jump()
    {
        rb.AddForce(new Vector2(0, jumpHeight), ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            isGround = true;
        }
    }
}
