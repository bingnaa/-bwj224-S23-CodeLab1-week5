using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverButton : MonoBehaviour
{
    public void SwitchStart()
    {
        //GameManager.instance.GetComponent<ResetGame>().ResetG();
        SceneManager.LoadScene("Starting");
    }
}
