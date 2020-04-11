using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    // how fast the character can move
    public float topSpeed = 10f;
    public bool isGrounded = false;

    // tell the sprite which direction it is pointing
    bool facingRight = true;

    // physics in fixed update
    private void FixedUpdate()
    {
        Jump();
        // get move direction
        float move = Input.GetAxis("Horizontal");

        // add velocity to rigidbody
        GetComponent<Rigidbody2D>().velocity = new Vector2(move * topSpeed, GetComponent<Rigidbody2D>().velocity.y);

        // if we are facing the negative direciton and, flip
        if(move > 0 && !facingRight)
        {
            FlipSprite();
        }
        else if(move < 0 && facingRight)
        {
            FlipSprite();
        }
    }

    void FlipSprite()
    {
        // change sprite direction
        facingRight = !facingRight;

        // get the local scale
        Vector3 theScale = transform.localScale;

        // flip on the x axis
        theScale.x *= -1;

        // apply that to the local scale
        transform.localScale = theScale;
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 5f), ForceMode2D.Impulse);
        }
    }
}
