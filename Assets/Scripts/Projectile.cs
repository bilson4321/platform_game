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
        float moveSpeed = 8f;
        transform.position += shootDir * moveSpeed * Time.deltaTime;
    }
    /*
    void DestroyGameObject()
    {
        Destroy(gameObject);
    }*/
    private void OnCollisionEnter2D(Collision2D collision)
    {
       // DestroyGameObject();
    }
}
