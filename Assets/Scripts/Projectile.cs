using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Vector3 shootDir;
    public void setup(Vector3 shootDirection)
    {
        this.shootDir = shootDirection;
    }

    // Update is called once per frame
    void Update()
    {
        float moveSpeed = 6f;
        transform.position += shootDir * moveSpeed * Time.deltaTime;
    }
    
    void DestroyGameObject()
    {
        Destroy(gameObject);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collided with" + collision.collider.name);
        if (collision.collider.name != "Dog") { }
        else if(collision.collider.name != "Cat")
        {} else
        {
            DestroyGameObject();
        }
    }
}
