using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

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
    public GameObject light;
    public GameObject grass;
    public GameObject point;

    Vector3Int centerPoint;

    private Tilemap groundMap;
    //public Tile.ColliderType col;
    
    public Animator playerAnim;

    GameObject currentPlayer;
    GameObject level;
    
    int currentLevel = 0;

    public int CurrentLevel
    {
        get { return currentLevel; }
        set
        {
            currentLevel = value;
            LoadLevel();
            groundMap.ClearAllTiles();
        }
    }
    
    const string FILE_NAME = "LevelNum.txt";
    const string FILE_DIR = "/Levels/";
    string FILE_PATH;

    public float xOffset;
    public float yOffset;

    public Vector2 playerStartPos;
    
    // Start is called before the first frame update
    void Start()
    {
        FILE_PATH = Application.dataPath + FILE_DIR + FILE_NAME;
        groundMap = GameObject.FindWithTag("Grid").GetComponent<Tilemap>();

        LoadLevel();
    }

    void LoadLevel()
    {
        Destroy(level);
        
        level = new GameObject("Level");
        
        string newPath = FILE_PATH.Replace("Num", currentLevel + "");
        
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
                GameObject newObj = null;
                Tile newTile = null;

                switch (c)
                {
                    case 'p': 
                        playerStartPos = new Vector2(xOffset + xPos, yOffset - yPos);
                        newObj = Instantiate<GameObject>(player); //+new player
                        currentPlayer = newObj;
                        newTile = null;
                        break;
                    case 't': 
                        newObj = Instantiate<GameObject>(tree); //+tree
                        newTile = ScriptableObject.CreateInstance<ScriptableTile>();
                        //Debug.Log(newTile.sprite);
                        newTile.name = "Tree" + xPos + "-" + yPos;
                        //newObj.name = "TreeGO" + xPos + "-" + yPos;
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
                        newObj = Instantiate<GameObject>(light); //+light
                        break;
                    case 'g':
                        newObj = Instantiate<GameObject>(grass); //+grass
                        break;
                    // case 'x':
                    //     newObj = Instantiate<GameObject>(point);
                    //     newObj.name = "point";
                    //     break;

                    default: //otherwise
                        newObj = null; //null
                        newTile = null;
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
                else if (newObj!= null && newObj.name == "point")
                {
                    newObj.transform.position =
                        new Vector2(
                            xOffset + xPos, 
                            yOffset - yPos);
                    
                    newObj.transform.parent = level.transform;
                    //centerPoint = groundMap.WorldToCell(newObj.transform.position);
                }
                if(newTile != null)
                {
                   //Vector3Int currentCell = groundMap.WorldToCell(newObj.transform.position);

                   //int xPoint = centerPoint.x + xPos;
                   //int yPoint = centerPoint.y + yPos;
                   //groundMap.RefreshTile(new Vector3Int(xPoint, yPoint));
                   //groundMap.SetTile(new Vector3Int(xPoint, yPoint), newTile);
                   //groundMap.SetTile(currentCell, newTile);
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
        CurrentLevel++;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
