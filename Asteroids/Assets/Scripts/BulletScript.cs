using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    //variables
    public float speed = 1.0f;

    //refrences
    private Rigidbody2D rb;
    private AsteroidManager asteroidManager;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        asteroidManager = FindAnyObjectByType<AsteroidManager>();
    }

    public void Fire(Vector2 dir)
    {
        rb.AddForce(dir * speed);
    }


    //destroy upon contact
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 7)
        {
            asteroidManager.showExplosion(this.transform.position);
        }
        Destroy(this.gameObject);
    }
}
