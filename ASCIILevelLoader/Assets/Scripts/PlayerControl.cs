using System;
using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    private PlayerControlMov control;

    [SerializeField]
    private Tilemap groundTileMap;
    [SerializeField]
    //public Tilemap colliTileMap;

    Rigidbody2D rb2D; 
    public Animator player;
    //public Vector3 forceAmount;
    public float moveSpeed = 1f;
    public Vector2 direction;

    private void Awake()
    {
        control = new PlayerControlMov();
    }

    private void OnEnable()
    {
        control.Enable();
    }
    
    private void OnDisable()
    {
        control.Disable();
    }

    void Start()
    {
        //forceAmount = new Vector3(1.0f, 1.0f, 0.0f);
        groundTileMap = GameObject.FindWithTag("Grid").GetComponent<Tilemap>();
        rb2D = GetComponent<Rigidbody2D>();

        control.Main.Movement.performed += ctx => Move(ctx.ReadValue<Vector2>());
    }

    private void Move(Vector2 direction)
    {
        if (CanMove(direction))
        {
            transform.position += ((Vector3)direction);
        }
    }

    private bool CanMove(Vector2 direction)
    { 
        // if (collides)
        // {
        //     return false;
        // }
        return true;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.S)) //if W is pressed
        {
            direction = new Vector2(0, -1f);
            player.Play("player");
        }

        else if (Input.GetKey(KeyCode.W)) //if S is pressed
        {
            direction = new Vector2(0, 1f);
            player.Play("playerback");
        }

        else if (Input.GetKey(KeyCode.A)) //if A is pressed
        {
            direction = new Vector2(1f, 0);
            player.Play("playerL");
        }

        else if (Input.GetKey(KeyCode.D)) //if D is pressed
        {
            direction = new Vector2(-1f, 0);
            player.Play("playerR");
        }
        //Vector3Int gridPos = groundTileMap.WorldToCell(transform.position + (Vector3)direction);
    }

    void FixedUpdate()
    {
        //tried pixel perfect movement
        /*if (Input.GetKey(KeyCode.S)) //if W is pressed
        {
            player.Play("player");
            transform.position = new Vector2(rb2D.position.x, rb2D.position.y-1);
        }

        else if (Input.GetKey(KeyCode.W)) //if S is pressed
        {
            player.Play("playerback");
            transform.position = new Vector2(rb2D.position.x, rb2D.position.y+1);
        }

        else if (Input.GetKey(KeyCode.A)) //if A is pressed
        {
            player.Play("playerL");
            transform.position = new Vector2(rb2D.position.x-1, rb2D.position.y);
        }

        else if (Input.GetKey(KeyCode.D)) //if D is pressed
        {
            player.Play("playerR");
            transform.position = new Vector2(rb2D.position.x+1, rb2D.position.y);
        }
        rb2D.MovePosition(transform.position + forceAmount*Time.fixedDeltaTime);*/
    }
}
