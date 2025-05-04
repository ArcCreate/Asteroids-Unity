using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //variables
    private bool isMoving;
    private float moveDirection;
    public float speed = 1.0f;
    public float turnSpeed = 1.0f;
    public int maxHealth = 3;
    private int currentHealth;

    //refrences
    private Rigidbody2D rb;
    public BulletScript bulletPrefab;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    //Update function used for inputs
    private void Update()
    {
        //player input
        isMoving = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);

        //turning
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            moveDirection = 1.0f;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            moveDirection = -1.0f;
        }
        else
        {
            moveDirection = 0.0f;
        }

        //shooting
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    //using for physics code
    private void FixedUpdate()
    {
        if (isMoving)
        {
            rb.AddForce(this.transform.up * speed);
        }

        if(moveDirection != 0.0f)
        {
            rb.AddTorque(moveDirection * turnSpeed);
        }
    }

    private void Shoot()
    {
        BulletScript bullet = Instantiate(bulletPrefab, this.transform.position, this.transform.rotation);
        bullet.Fire(this.transform.up);
    }
}
