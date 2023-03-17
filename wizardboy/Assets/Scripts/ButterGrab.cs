using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButterGrab : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D col)
    {
        GameManager.instance.Score++;
        Debug.Log(GameManager.instance.Score);
        Destroy(gameObject);
    }
}
