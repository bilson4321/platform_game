using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D playerRigidBody;
    public Animator animator;
    public float MovementSpeed = 1;
    public float JumpForce = 1;
    float horizontal = 0;
    PlayerState currentState = PlayerState.idle;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");

        animator.SetFloat("speed", Mathf.Abs(horizontal));
        transform.position += new Vector3(horizontal, 0, 0) * Time.deltaTime * MovementSpeed;
        if (horizontal < 0)
        {
            transform.localRotation = Quaternion.Euler(0,180,0);
        } else
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        playerRigidBody.velocity.Set((horizontal * Time.deltaTime * MovementSpeed),0);

       //Debug.Log("upp or down" + playerRigidBody.velocity.y);
        if (playerRigidBody.velocity.y > 0.001)
        {
            animator.SetBool("jumping", true);
            animator.SetBool("onGround", false);
        }
        if (playerRigidBody.velocity.y < 0.001)
        {
            animator.SetBool("falling", true); 
            animator.SetBool("jumping",false);
        }
        if (playerRigidBody.velocity.y == 0.0)
        {
            animator.SetBool("onGround", true);
            animator.SetBool("falling", false);
        }
        if ((Input.GetButtonDown("Jump") || Input.GetKeyDown("up"))&& Mathf.Abs(playerRigidBody.velocity.y)<0.001)
        {
            playerRigidBody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
        }
    }

    void FixedUpdate()
    {

    }

    void handleInput()
    {

    }

    enum PlayerState { 
        idle,
        walking,
        jumping,
        falling,
        facingLeft,
        facingRight,
    }
}
