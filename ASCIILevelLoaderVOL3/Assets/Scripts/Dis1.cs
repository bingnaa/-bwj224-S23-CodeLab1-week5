using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dis1 : MonoBehaviour
{
    // Start is called before the first frame update

    private Material mat;
    private float fade = 1f;
    public GameObject b;
    public bool isD = false;

    public void Dissolve(Collider2D col)
    {
        b = col.gameObject;
        mat = col.gameObject.GetComponent<SpriteRenderer>().material;
        isD = true;
        fade = 1f;
    }

    private void Update()
    {
        if (b != null && mat != null)
        {
            if (isD)
            {
                fade -= Time.deltaTime;

                if (fade <= 0f)
                {
                    fade = 0f;
                    b.SetActive(false);
                }
            }

            mat.SetFloat("_Fade", fade);
        }
    }
}
