using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScenes : MonoBehaviour
{
    public int ClickCounter = 0;
    public bool FirstClick = true;
    public bool SecondClick = false;
    public string HighlightedLevel;
    public void Start()
    {
    }
    public void Update()
    {

    }
    public void Canon()
    {
        if (HighlightedLevel != "Canon")
        {
            HighlightedLevel = "Canon";
            ClickCounter = 0;
        }

        if (HighlightedLevel == "Canon")
        {
            ClickCounter += 1;
        }
    }
    public void LoadCanon()
    {
        if (ClickCounter == 2 && HighlightedLevel == "Canon")
        {
            SceneManager.LoadScene("Canon");
        }
        else if (ClickCounter == 2 && HighlightedLevel != "Canon")
        {
            ClickCounter = 0;
        }
    }
    public void Devil()
    {
        if (HighlightedLevel != "Devil")
        {
            HighlightedLevel = "Devil";
            ClickCounter = 0;
        }
        
        if (HighlightedLevel == "Devil")
        {
            ClickCounter += 1;
        }
    }
    public void LoadDevil()
    {
        if (ClickCounter == 2 && HighlightedLevel == "Devil")
        {
            SceneManager.LoadScene("Devil in Disguise");
        }
        else if (ClickCounter == 2 && HighlightedLevel != "Devil")
        {
            ClickCounter = 0;
        }
    }
    public void CD()
    {
        if (HighlightedLevel != "CD")
        {
            HighlightedLevel = "CD";
            ClickCounter = 0;
        }

        if (HighlightedLevel == "CD")
        {
            ClickCounter += 1;
        }
    }
    public void LoadCD()
    {
        if (ClickCounter == 2 && HighlightedLevel == "CD")
        {
            SceneManager.LoadScene("Cute Depress");
        }
        else if (ClickCounter == 2 && HighlightedLevel != "CD")
        {
            ClickCounter = 0;
        }
    }
    public void WindBreaker()
    {
        if (HighlightedLevel != "WindBreaker")
        {
            HighlightedLevel = "WindBreaker";
            ClickCounter = 0;
        }

        if (HighlightedLevel == "WindBreaker")
        {
            ClickCounter += 1;
        }
    }
    public void LoadWindBreaker()
    {
        if (ClickCounter == 2 && HighlightedLevel == "WindBreaker")
        {
            SceneManager.LoadScene("Wind Breaker");
        }
        else if (ClickCounter == 2 && HighlightedLevel != "WindBreaker")
        {
            ClickCounter = 0;
        }
    }
}
