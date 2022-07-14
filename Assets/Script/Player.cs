using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 1;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Movement();
    }

    void Movement()
    {
        float x;
        float y;

        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");

        Vector2 moveDelta = new (x, y);
        rb.velocity = moveDelta * speed;

        if (x > 0)
        {
            transform.localScale = new (-1, 1, 1);
        }
        if (x < 0)
        {
            transform.localScale = Vector3.one;
        }
    }
}
