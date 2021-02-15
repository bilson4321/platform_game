using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class EnemyController : MovingObjectController
    {
        public Transform pfBullet;
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
            if (currentHealth <= 0)
            {
                Destroy(gameObject);
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
                idleTime = 5.0f;
                Debug.Log(rigidBody.position);
                Transform bulletTransform=Instantiate(pfBullet,rigidBody.position+new Vector2(-1.4f,0),Quaternion.identity);
                Vector3 shootDirection = new Vector3(-1,0);
                bulletTransform.GetComponent<Projectile>().setup(shootDirection);
            }
        }
        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.collider.tag == "projectile")
            {
                takeDamage(15);
                Debug.Log("Health" + currentHealth);
                Destroy(collision.collider.gameObject);
            }
        }
    }
}