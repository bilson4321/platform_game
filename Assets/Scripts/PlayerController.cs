using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class PlayerController : MovingObjectController
    {
        public float JumpForce = 1;

        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        public override void Update()
        {
            base.Update();
            handleInput();

            if (rigidBody.velocity.y > 0.001)
            {
                animator.SetBool("jumping", true);
                animator.SetBool("onGround", false);
            }
            if (rigidBody.velocity.y < 0.001)
            {
                animator.SetBool("falling", true);
                animator.SetBool("jumping", false);
            }
            if (rigidBody.velocity.y == 0.0)
            {
                animator.SetBool("onGround", true);
                animator.SetBool("falling", false);
            }
        }

        void handleInput()
        {
            float horizontal = Input.GetAxis("Horizontal");
            moveHorizontal(horizontal);

            if ((Input.GetButtonDown("Jump") || Input.GetKeyDown("up")) && Mathf.Abs(rigidBody.velocity.y) < 0.001)
            {
                jump();
            }
        }
        void jump()
        {
            rigidBody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
        }
    }
}
