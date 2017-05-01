using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    Vector2 desiredPosition;
    Rigidbody2D rb;
    public float speed=10;
    public float minMovementDistance = 1;
    SpriteRenderer rend;
    Animator anim;
    public bool atTarget = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rend = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        desiredPosition = transform.position;
    }

    void Update()
    {
        if (Mathf.Abs(desiredPosition.x - transform.position.x)>minMovementDistance)
        {
            Vector2 direction = new Vector2(desiredPosition.x - transform.position.x, 0).normalized;
            rb.velocity = direction * speed + Physics2D.gravity;
            //Flipping player in proper direction
            rend.flipX=direction.x < 0;
            anim.SetBool("walking", true);
            atTarget = false;
        }
        else
        {
            rb.velocity = Physics2D.gravity;
            anim.SetBool("walking",false);
            atTarget = true;
        }
    }

    public void Flip(int direction)
    {
        rend.flipX = direction < 0;
    }

    public void MoveTo(Vector2 pos)
    {
        atTarget = false;
        desiredPosition = pos;
    }
}
