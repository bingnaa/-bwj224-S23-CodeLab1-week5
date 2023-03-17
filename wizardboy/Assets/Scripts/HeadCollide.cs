using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadCollide : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player") && GameManager.instance.scareIndex < 4)
        {
            GameManager.instance.scareIndex++;
        }
    }
}
