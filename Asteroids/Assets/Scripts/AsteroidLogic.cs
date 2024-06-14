using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidLogic : MonoBehaviour
{
    //variables
    public Sprite[] list;
    public float size = 1.0f;
    public float speed;

    //refrences
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    private AsteroidManager manager;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = rb.GetComponent<SpriteRenderer>();
        manager = FindAnyObjectByType<AsteroidManager>();
    }

    private void Start()
    {
        //gives random sprite to asteroid fromlist
        spriteRenderer.sprite = list[Random.Range(0, list.Length)];

        //gives random angle
        this.transform.eulerAngles = new Vector3(0.0f, 0.0f, Random.value * 360.0f);

        //random size
        this.transform.localScale = Vector3.one * size;
        rb.mass = size;
    }

    public void Move(Vector2 d)
    {
        rb.AddForce(d * speed);

        //destroy after some time
        Destroy(this.gameObject, 10f);
    }

    //when it collides with something
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //splitting into smaller asteroids
        /*
        if(this.size * 0.5f >= manager.minSize)
        {
            Split();
        }
        */
        if(collision.gameObject.layer == 7)
        {
            if(this.gameObject.GetComponent<AsteroidLogic>().size > collision.gameObject.GetComponent<AsteroidLogic>().size)
            {
                Destroy(collision.gameObject);
                Split();
                Destroy(this.gameObject);
            }
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    //split into smaller asteroids
    private void Split()
    {
        Vector2 pos = this.transform.position;
        pos += Random.insideUnitCircle * 2f;
        AsteroidLogic a1 = Instantiate(this, pos, this.transform.rotation);
        a1.size = this.size / 2.0f;
        a1.Move(rb.velocity.normalized * speed/2);
    }
}
