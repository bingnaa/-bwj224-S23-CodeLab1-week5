using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shadow : MonoBehaviour
{
    private Material mat;
    private float scanS = 1f;
    public GameObject b;
    public bool isS = false;
    
    public void Shade(Collider2D col)
    {
        b = col.gameObject;
        mat = col.gameObject.GetComponent<SpriteRenderer>().material;
        col.GetComponent<AudioSource>().Play();
        isS = true;
        scanS = 1f;
    }
    
    private void Update()
    {
        if (b != null && mat != null)
        {
            if (isS)
            {
                scanS -= Time.deltaTime*2;

                if (scanS <= 0f)
                {
                    scanS = 1f;
                    isS = false;
                }
            }

            mat.SetFloat("_ScanStrength", scanS);
        }
    }
}
