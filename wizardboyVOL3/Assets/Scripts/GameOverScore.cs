using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScore : MonoBehaviour
{
    
    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = "Butter Collected: " + GameManager.instance.Score.ToString();
        //GetComponent<Text>().text = "test";
    }
}
