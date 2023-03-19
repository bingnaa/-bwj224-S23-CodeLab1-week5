using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //static variable means the value is the same for all the objects of this class type and the class itself
    public static GameManager instance; //this static var will hold the Singleton

    private int score = 0;
    public bool hasLoaded = false;
    //public int bIndex;
    public GameObject backG;
    public int scareIndex = 1;

    public int Score
    {
        get { return score; }
        set
        {
            score = value;
        }
    }


    private int currentLevel = 0;

    public int CurrentLevel
    {
        get { return currentLevel; }
        set
        {
            currentLevel = value;
            GetComponent<ASCIILevelLoadScript>().LoadLevel();
            //backG.GetComponent<ChangeBackground>().ChangeBack(bIndex);
        }
    }
    void Awake()
    {
        if (instance == null) //instance hasn't been set yet
        {
            DontDestroyOnLoad(gameObject);  //Dont Destroy this object when you load a new scene
            instance = this;  //set instance to this object
        }
        else  //if the instance is already set to an object
        {
            Destroy(gameObject); //destroy this new object, so there is only ever one
        }
    }

    public void ScareChange(int index)
    {
        SceneManager.LoadScene("scare" + scareIndex.ToString());
        currentLevel++;
    }
    
    public void EndChange()
    {
        if (score == 8)
        {
            SceneManager.LoadScene("FinalButter");
        }
        else
        {
            SceneManager.LoadScene("FinalEnd");
        }
    }

    private void Update()
    {
        if (SceneManager.GetSceneByName("scare" + scareIndex).isLoaded)
        {
            GetComponent<ASCIILevelLoadScript>().enabled = false;
            hasLoaded = false;
        }
        else if (SceneManager.GetSceneByName("GameOver").isLoaded)
        {
            GetComponent<ASCIILevelLoadScript>().enabled = false;
            hasLoaded = false;
        }
        else if (SceneManager.GetSceneByName("Starting").isLoaded)
        {
            //GetComponent<ResetGame>().ResetG();
            score = 0;
            currentLevel = 0;
            scareIndex = 1;
            GetComponent<ASCIILevelLoadScript>().enabled = false;
            hasLoaded = false;
        }
        else if(!hasLoaded && SceneManager.GetSceneByName("GameScene").isLoaded)
        {
            GetComponent<ASCIILevelLoadScript>().enabled = true;
            GetComponent<ASCIILevelLoadScript>().LoadLevel();
            hasLoaded = true;
        }
    }
}
