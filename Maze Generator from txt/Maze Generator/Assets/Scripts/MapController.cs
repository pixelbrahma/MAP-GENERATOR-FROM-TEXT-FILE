using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

public class MapController : MonoBehaviour {

    [SerializeField] Transform wallPrefab;
    [SerializeField] Transform groundPrefab;
    [SerializeField] Transform startPointPrefab;
    [SerializeField] Transform endPointPrefab;
    [SerializeField] GameObject playerPrefab;
    private bool playerPresent = false;
    private GameObject player;
 
    public const string WALL = "X";
    public const string GROUND = "O";
    public const string START = "S";
    public const string END = "E";

	void Start () {
        string[][] levelData = ReadFile("D:/Assignment Unity 2/Maze Generator from txt/Maze Generator/Assets" +
            "/LevelText/testMap.txt");
        for(int x=0;x<levelData.Length;x++)
        {
            for(int y=0;y<levelData[0].Length;y++)
            {
                switch(levelData[x][y])
                {
                    case WALL:
                        Instantiate(wallPrefab, new Vector3(y, -x, 0f), Quaternion.identity);
                        break;
                    case GROUND:
                        Instantiate(groundPrefab, new Vector3(y, -x, 0f), Quaternion.identity);
                        break;
                    case START:
                        Instantiate(startPointPrefab, new Vector3(y, -x, 0f), Quaternion.identity);
                        if (playerPresent == false)
                        {
                            player = Instantiate(playerPrefab, new Vector3(y, -x, -0.8f), Quaternion.identity);
                            playerPresent = true;
                        }
                        break;
                    case END:
                        Instantiate(endPointPrefab, new Vector3(y, -x, 0f), Quaternion.identity);
                        break;
                }
            }
        }
	}

    string[][] ReadFile(string mapFile)
    {
        string text = System.IO.File.ReadAllText(mapFile);
        string[] lines = Regex.Split(text, "\r\n");
        int rows = lines.Length;

        string[][] levelData = new string[rows][];
        for(int i=0;i<rows;i++)
        {
            string[] eachStringInRow = Regex.Split(lines[i], " ");
            levelData[i] = eachStringInRow;
        }

        return levelData;
    }
}
