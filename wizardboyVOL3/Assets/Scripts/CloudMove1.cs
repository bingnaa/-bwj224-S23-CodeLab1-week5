using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMove1 : MonoBehaviour
{
    public Rigidbody2D r2b2;
    public float speed;
    
    // Start is called before the first frame update
    void Start()
    {
        r2b2 = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        r2b2.velocity = new Vector2( Random.Range(-100,100), 0)*Time.fixedDeltaTime*speed;
    }
}
