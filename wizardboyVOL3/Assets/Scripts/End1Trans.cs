using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class End1Trans : MonoBehaviour
{
    private PlayableDirector director;
    private bool hasPlayed = true;
    
    void Awake()
    {
        director = GetComponent<PlayableDirector>();
        // director.played += Director_Played;
        director.stopped += Director_Stopped;
    }

    private void Director_Stopped(PlayableDirector obj)
    {
        if (hasPlayed)
        {
            SceneManager.LoadScene("GoodEndScene");
        }
    }
}
