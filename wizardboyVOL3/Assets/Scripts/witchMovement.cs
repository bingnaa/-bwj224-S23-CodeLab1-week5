using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class witchMovement : MonoBehaviour
{
    private Transform player; //the enemy's target
    public float moveSpeed; //move speed
    private Vector2 localScale;
    private Rigidbody2D r2b;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        r2b = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            r2b.rotation = angle;
            localScale = direction;
        }
        else //checks if player has been "deleted"
        {
            player = GameObject.FindWithTag("Player").transform;
        }
    }

    private void FixedUpdate()
    {
        r2b.velocity = new Vector2(localScale.x, localScale.y) * moveSpeed;
    }

    // private void OnCollisionEnter2D(Collision2D col)
    // {
    //     if (col.gameObject.CompareTag("canDissolve"))
    //     {
    //         GameManager.instance.GetComponent<Dis1>().Dissolve(col);
    //     }


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("canDissolve"))
        {
            GameManager.instance.GetComponent<Dis1>().Dissolve(col);
        }
        if (col.gameObject.CompareTag("canShade"))
        {
            GameManager.instance.GetComponent<Shadow>().Shade(col);
        }

        if (col.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
