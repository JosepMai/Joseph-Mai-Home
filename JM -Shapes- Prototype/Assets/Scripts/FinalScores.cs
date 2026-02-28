using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class FinalScores : MonoBehaviour
{
    public TextMeshProUGUI FinalScoreText;
    public TextMeshProUGUI PerfectText;
    public TextMeshProUGUI GoodText;
    public TextMeshProUGUI OkText;
    public TextMeshProUGUI BadText;
    public TextMeshProUGUI MissText;
    public TextMeshProUGUI GradeText;
    public TextMeshProUGUI BestScore;

    public bool isHighscore;
    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.GetInt("CurrentSong", 0) = SongID;
        //PlayerPrefs.GetInt("CurrentSong", 0) + "HS" = SongIDHS;
        if (PlayerPrefs.GetInt("FinalScore", 0 ) > PlayerPrefs.GetInt(PlayerPrefs.GetInt("CurrentSong", 0) + "HS", 0))
        {
            PlayerPrefs.SetInt(PlayerPrefs.GetInt("CurrentSong", 0) + "HS", PlayerPrefs.GetInt("FinalScore", 0)); // This updates the high score
            BestScore.text = "Best Score:" + PlayerPrefs.GetInt(PlayerPrefs.GetInt("CurrentSong", 0) + "HS", 0);
        }
        //Displaying Best Score uses PlayerPrefs.GetInt(PlayerPrefs.GetInt("CurrentSong", 0) + "HS", 0))
        //Display current score uses PlayerPrefs.GetInt("FinalScore", 0);
    }

    // Update is called once per frame
    void Update()
    {
        FinalScoreText.text = "Final Score:" + PlayerPrefs.GetInt("FinalScore", 0).ToString();
        PerfectText.text = "Perfect: " + PlayerPrefs.GetInt("Perfect", 0).ToString();
        GoodText.text = "Good: " + PlayerPrefs.GetInt("Good", 0).ToString();
        OkText.text = "Ok: " + PlayerPrefs.GetInt("Ok", 0).ToString();
        BadText.text = "Bad: " + PlayerPrefs.GetInt("Bad", 0).ToString();
        MissText.text = "Miss: " + PlayerPrefs.GetInt("Miss", 0).ToString();

        if (PlayerPrefs.GetInt("GRADE") == 6)
        {
            GradeText.text = "GRADE: S";
        }
        if (PlayerPrefs.GetInt("GRADE") == 5)
        {
            GradeText.text = "GRADE: A";
        }
        if (PlayerPrefs.GetInt("GRADE") == 4)
        {
            GradeText.text = "GRADE: B";
        }
        if (PlayerPrefs.GetInt("GRADE") == 3)
        {
            GradeText.text = "GRADE: C";
        }
        if (PlayerPrefs.GetInt("GRADE") == 2)
        {
            GradeText.text = "GRADE: D";
        }
        if (PlayerPrefs.GetInt("GRADE") == 1)
        {
            GradeText.text = "GRADE: F";
        }
    }
}
