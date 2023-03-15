using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class ChooChooTransition : MonoBehaviour
{
    private PlayableDirector director;

    public GameObject controlP;
    private bool hasPlayed = true;
    
    // Start is called before the first frame update
    void Awake()
    {
        director = GetComponent<PlayableDirector>();
        // director.played += Director_Played;
        director.stopped += Director_Stopped;
    }

    // private void Director_Played(PlayableDirector obj)
    // {
    //     controlP.SetActive(false);
    // }

    private void Director_Stopped(PlayableDirector obj)
    {
        if (hasPlayed)
        {
            SceneManager.LoadScene("GameScene");
        }
    }
}
