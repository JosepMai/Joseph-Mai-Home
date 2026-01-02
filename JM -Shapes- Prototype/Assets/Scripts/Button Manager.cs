using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{

    public GameObject CurrentImage;
    public GameObject CanonImage;
    public GameObject DevilImage;
    public GameObject CDImage;
    public GameObject WindBreakerImage;
    public GameObject HUGSImage;
    public GameObject ThousandNightsImage;
    public GameObject FlameWallImage;
    public GameObject Coverup;
    public int ClickCounter = 0;
    public bool FirstClick = true;
    public bool SecondClick = false;
    public bool ClickedStartButton = false;
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
            CanonImage.SetActive(true);
            CurrentImage.SetActive(false);
            CurrentImage = CanonImage;
            Coverup.SetActive(false);
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
            DevilImage.SetActive(true);
            CurrentImage.SetActive(false);
            CurrentImage = DevilImage;
            Coverup.SetActive(false);
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
            CDImage.SetActive(true);
            CurrentImage.SetActive(false);
            CurrentImage = CDImage;
            Coverup.SetActive(false);
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
            WindBreakerImage.SetActive(true);
            CurrentImage.SetActive(false);
            CurrentImage = WindBreakerImage;
            Coverup.SetActive(false);
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
    public void HUGS()
    {
        if (HighlightedLevel != "HUGS")
        {
            HUGSImage.SetActive(true);
            CurrentImage.SetActive(false);
            CurrentImage = HUGSImage;
            Coverup.SetActive(false);
            HighlightedLevel = "HUGS";
            ClickCounter = 0;
        }

        if (HighlightedLevel == "HUGS")
        {
            ClickCounter += 1;
        }
    }
    public void LoadHUGS()
    {
        if (ClickCounter == 2 && HighlightedLevel == "HUGS")
        {
            SceneManager.LoadScene("Gachiakuta");
        }
        else if (ClickCounter == 2 && HighlightedLevel != "HUGS")
        {
            ClickCounter = 0;
        }
    }
    public void ThousandNights()
    {
        if (HighlightedLevel != "ThousandNights")
        {
            ThousandNightsImage.SetActive(true);
            CurrentImage.SetActive(false);
            CurrentImage = ThousandNightsImage;
            Coverup.SetActive(false);
            HighlightedLevel = "ThousandNights";
            ClickCounter = 0;
        }

        if (HighlightedLevel == "ThousandNights")
        {
            ClickCounter += 1;
        }
    }
    public void LoadThousandNights()
    {
        if (ClickCounter == 2 && HighlightedLevel == "ThousandNights")
        {
            SceneManager.LoadScene("Hilcrhyme");
        }
        else if (ClickCounter == 2 && HighlightedLevel != "ThousandNights")
        {
            ClickCounter = 0;
        }
    }
    public void Flamewall()
    {
        if (HighlightedLevel != "Flamewall")
        {
            FlameWallImage.SetActive(true);
            CurrentImage.SetActive(false);
            CurrentImage = FlameWallImage;
            Coverup.SetActive(false);
            HighlightedLevel = "Flamewall";
            ClickCounter = 0;
        }

        if (HighlightedLevel == "Flamewall")
        {
            ClickCounter += 1;
        }
    }
    public void LoadFlamewall()
    {
        if (ClickCounter == 2 && HighlightedLevel == "Flamewall")
        {
            SceneManager.LoadScene("Flamewall");
        }
        else if (ClickCounter == 2 && HighlightedLevel != "Flamewall")
        {
            ClickCounter = 0;
        }
    }

    public void StartButton()
    {

        SceneManager.LoadScene("Menu Scene");
    }
    public void DelayStartButton()
    {
        ClickedStartButton = true;
        Invoke("StartButton", 1f);
    }
}
