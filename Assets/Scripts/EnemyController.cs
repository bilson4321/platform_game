using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class EnemyController : MovingObjectController
    {
        public Rigidbody2D patrolArea;

        private float movement = 2.0f;
        private float idleTime = 0;
        private bool directionSwitch = true;

        public override void Update()
        {
            base.Update();
            
            if (idleTime > 0)
            {
                idleTime -= Time.deltaTime;
                animator.SetFloat("speed",0);
            } else
            {
                moveEitherWay();
            }
        }

        void moveEitherWay()
        {
            if (directionSwitch)
            {
                moveHorizontal(movement);
            } else
            {
                moveHorizontal(-movement);
            }
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {

            if (collision.name == "PatrolArea")
            {
                idleTime = 2;
                directionSwitch = !directionSwitch;
            }
            if(collision.name == "Dog")
            {
                Debug.Log("Attacking");
                idleTime = 0.5f;
            }
        }

    }
}