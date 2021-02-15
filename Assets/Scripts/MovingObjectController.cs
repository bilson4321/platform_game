using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class MovingObjectController : MonoBehaviour
    {
        public Animator animator;
        public Rigidbody2D rigidBody;
        public int maxHealth=100;
        public int currentHealth = 0;

        public float MovementSpeed = 1;
        ObjectState objectState = ObjectState.idle;

        enum ObjectState
        {
            idle,
            walking,
            jumping,
            falling,
            facingLeft,
            facingRight,
        }

        // Use this for initialization
        void Start()
        {
            currentHealth = maxHealth;
        }

        // Update is called once per frame
        public virtual void Update()
        {

        }

        public void takeDamage(int damagePoint)
        {
            currentHealth -= damagePoint;
        }

        protected void moveHorizontal(float horizontal)
        {
            animator.SetFloat("speed", Mathf.Abs(horizontal));
            transform.position += new Vector3(horizontal, 0, 0) * Time.deltaTime * MovementSpeed;

            if (horizontal < 0)
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);
            }
            else
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
        }
    }
}