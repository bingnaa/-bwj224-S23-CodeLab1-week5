using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMov : MonoBehaviour
{
    public Rigidbody2D rb;
    private Vector2 moveInput;
    public float speed = 1f;
    public Animator player;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GetComponent<Animator>();
    }

    private void Update()
    {
        Move();
        Animate();
    }

    void Move()
    {
        float Horizontal = Input.GetAxis("Horizontal");
        float Vertical = Input.GetAxis("Vertical");

        if (Horizontal == 0 && Vertical == 0)
        {
            rb.velocity = new Vector2(0, 0);
        }

        moveInput = new Vector2(Horizontal, Vertical);
        rb.velocity = moveInput * speed * Time.fixedDeltaTime;
    }

    void Animate()
    {
        player.SetFloat("MovementX", moveInput.x);
        player.SetFloat("MovementY", moveInput.y);
    }
}
