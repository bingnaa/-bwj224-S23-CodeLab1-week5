using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using UnityEngine;

public class ASCIILevelLoadScript : MonoBehaviour
{
    public GameObject player;
    public GameObject tree;
    public GameObject spike;
    public GameObject hole;
    public GameObject witch;
    public GameObject treeR;
    public GameObject treeL;
    public GameObject bigBush;
    public GameObject bush;
    public GameObject bushSq;
    public GameObject fLight;
    public GameObject grass;
    public GameObject butter;
    public GameObject ghost;
    public GameObject background;

    public Animator transAm;
    public Animator playerAnim;

    GameObject currentPlayer;
    GameObject level;

    const string FILE_NAME = "LevelNum.txt";
    const string FILE_DIR = "/Levels/";
    string FILE_PATH;

    public float xOffset;
    public float yOffset;

    public Vector2 playerStartPos;
    
    // Start is called before the first frame update
    void Start()
    {
        background = GameObject.FindWithTag("bGround");
        FILE_PATH = Application.dataPath + FILE_DIR + FILE_NAME;
        GameManager.instance.hasLoaded = true;

        LoadLevel();
    }

    public void LoadLevel()
    {
        Destroy(level);
        
        level = new GameObject("Level");
        
        string newPath = FILE_PATH.Replace("Num", GameManager.instance.CurrentLevel + "");
        
        //load all the lines of the file into an array of strings
        string[] fileLines = File.ReadAllLines(newPath);

        //for loop to go through each line
        for (int yPos = 0; yPos < fileLines.Length; yPos++)
        {
            //get each line out of the array
            string lineText = fileLines[yPos];

            //turn the current line into an array of chars
            char[] lineChars = lineText.ToCharArray();

            //loop through each char
            for (int xPos = 0; xPos < lineChars.Length; xPos++)
            {
                //get the current char
                char c = lineChars[xPos];

                //make a variable for a new GameObject
                GameObject newObj;

                switch (c)
                {
                    case 'p': 
                        playerStartPos = new Vector2(xOffset + xPos, yOffset - yPos);
                        newObj = Instantiate<GameObject>(player); //+new player
                        currentPlayer = newObj;
                        break;
                    case 't': 
                        newObj = Instantiate<GameObject>(tree); //+tree
                        break;
                    case 's': 
                        newObj = Instantiate<GameObject>(spike); //+spike
                        break;
                    case 'h':
                        newObj = Instantiate<GameObject>(hole); //+hole
                        break;
                    case '^':
                        newObj = Instantiate<GameObject>(witch); //+witch
                        break;
                    case 'r':
                        newObj = Instantiate<GameObject>(treeR); //+tree right
                        break;
                    case 'l':
                        newObj = Instantiate<GameObject>(treeL); //+tree left
                        break;
                    case 'B':
                        newObj = Instantiate<GameObject>(bigBush); //+big bush
                        break;
                    case 'b':
                        newObj = Instantiate<GameObject>(bush); //+bush
                        break;
                    case 'q':
                        newObj = Instantiate<GameObject>(bushSq); //+bush sq
                        break;
                    case 'i':
                        newObj = Instantiate<GameObject>(fLight); //+light
                        break;
                    case 'g':
                        newObj = Instantiate<GameObject>(grass); //+grass
                        break;
                    case 'w':
                        newObj = Instantiate<GameObject>(butter); //+butter
                        break;
                    case '!':
                        newObj = Instantiate<GameObject>(ghost); //+ghost
                        break;
                    case '1':
                        background.GetComponent<ChangeBackground>().ChangeBack(1);
                        newObj = null;
                        break;
                    case '2':
                        background.GetComponent<ChangeBackground>().ChangeBack(2);
                        newObj = null;
                        break;
                    case '3':
                        background.GetComponent<ChangeBackground>().ChangeBack(3);
                        newObj = null;
                        break;
                    case '*':
                        GameManager.instance.GetComponent<GameManager>().ScareChange(0);
                        newObj = null;
                        break;
                    case '@':
                        //GameManager.instance.GetComponent<GameManager>().EndChange();
                        newObj = null;
                        break;

                    default: //otherwise
                        newObj = null; //null
                        break;
                }

                //if we made a new GameObject
                if (newObj != null)
                {
                    newObj.transform.position =
                        new Vector2(
                            xOffset + xPos, 
                            yOffset - yPos);

                    newObj.transform.parent = level.transform;
                }
            }
        }
        
        playerAnim.Rebind();
    }

    public void ResetPlayer()
    {
        currentPlayer.transform.position = playerStartPos;
    }

    public void HitHole()
    {
        GameManager.instance.CurrentLevel++;
        transAm.Play("hole");
    }

    private void OnEnable()
    {
        background = GameObject.FindWithTag("bGround");
        transAm = GameObject.FindWithTag("coolAni").GetComponent<Animator>();
    }
}
