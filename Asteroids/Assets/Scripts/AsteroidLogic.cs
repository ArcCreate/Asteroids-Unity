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

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = rb.GetComponent<SpriteRenderer>();
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
        Destroy(this.gameObject, 5f);
    }
}
