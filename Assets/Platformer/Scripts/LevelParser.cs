﻿using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LevelParser : MonoBehaviour
{
    public string filename;
    public GameObject rockPrefab;
    public GameObject brickPrefab;
    public GameObject questionBoxPrefab;
    public GameObject stonePrefab;
    public Transform environmentRoot;

    // --------------------------------------------------------------------------
    void Start()
    {
        LoadLevel();
    }

    // --------------------------------------------------------------------------
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ReloadLevel();
        }
    }

    // --------------------------------------------------------------------------
    private void LoadLevel()
    {
        string fileToParse = $"{Application.dataPath}{"/Resources/"}{filename}.txt";
        //Debug.Log($"Loading level file: {fileToParse}");

        Stack<string> levelRows = new Stack<string>();

        // Get each line of text representing blocks in our level
        using (StreamReader sr = new StreamReader(fileToParse))
        {
            string line = "";
            while ((line = sr.ReadLine()) != null)
            {
                levelRows.Push(line);
            }

            sr.Close();
        }

        int row = 0;

        // Go through the rows from bottom to top
        while (levelRows.Count > 0)
        {
            string currentLine = levelRows.Pop();

            char[] letters = currentLine.ToCharArray();
            for (int column = 0; column < letters.Length; column++)
            {
                var letter = letters[column];
                // Todo - Instantiate a new GameObject that matches the type specified by letter
                Vector2 pos = new Vector2(column, row);
                if (letter == 'x')
                {
                    
                    Instantiate(rockPrefab, pos, Quaternion.identity, environmentRoot);
                }
                else if (letter == 'b')
                {
                    Instantiate(brickPrefab, pos, Quaternion.identity, environmentRoot);
                }
                else if(letter == 's')
                {
                    Instantiate(stonePrefab, pos, Quaternion.identity, environmentRoot);
                }
                else if(letter == '?')
                {
                    Instantiate(questionBoxPrefab, pos, Quaternion.identity, environmentRoot);
                }
            }
            row++;
        }
        
    }

    // --------------------------------------------------------------------------
    private void ReloadLevel()
    {
        foreach (Transform child in environmentRoot)
        {
           Destroy(child.gameObject);
        }
        LoadLevel();
    }
}
