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
        Vector3Int check = groundTileMap.WorldToCell(transform.position + (Vector3)direction);
        if (groundTileMap.GetColliderType((Vector3Int)check) == Tile.ColliderType.Sprite) 
        { 
            Debug.Log(groundTileMap.GetTile<Tile>(check).name);
            //Collision
            return false;
        }
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
}
