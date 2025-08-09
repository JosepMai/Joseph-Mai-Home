using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeatManager : MonoBehaviour
{
    public float totalSongTime;
    public float totalCountdownTime;

    public int BeatsInSong;
    public int BeatsCounter;
    public int score;

    public bool CheckingCountdown;
    public bool Beat1Triggered;
    public bool Beat2Triggered;

    public TMP_Text CountdownTime;
    public TMP_Text SongTime;
    public TMP_Text ScoreText;

    public GameObject Beat1;
    public GameObject Beat2;
    public GameObject ShrinkingRing1;
    public GameObject ShrinkingRing2;
    public GameObject InnerCircle1;
    public GameObject InnerCircle2;

    public GameObject[] listOfNotes;

    public int numOfNotes;
    public KeyCode key;

    // A reference to the active note

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        BeatsInSong = 60; // Creates a timer for amount of beats 
        totalSongTime = BeatsInSong; //sets the total time to amount of beats in the song
        totalCountdownTime = 3f;// Creates a countdown Timer of 3;
        BeatsInSong = BeatsCounter;
    }

    // Update is called once per frame
    void Update()
    {
        CountdownTimers();

    }
    public void CountdownTimers()// Function for the Timers(Countdown, Total Time, and End Time)
    {
        if (Beat2Triggered == false && Beat1Triggered == false && totalCountdownTime >= 0.1f)
        {
            Beat1Triggered = true;
        }
        if (totalCountdownTime > 0) // If the Countdown Time is greater than 0
        {
            totalCountdownTime -= Time.deltaTime;// Takes a second away each time from the totalcountdown time
            CountdownTime.text = Mathf.Round(totalCountdownTime).ToString();// Sets the countdowntime.text to the countdown time variable.
                                                                            // Creating a String for it
            CheckingCountdown = true;// Sets the countdown to true
        }
        else // Otherwise the Countdown Time would be 0 
        {
            CountdownTime.text = "";// Sets the countdown text to nothing
            totalSongTime -= Time.deltaTime;// Starts subtracting time from the song time
            SongTime.text = "Time Left:" + Mathf.Round(totalSongTime).ToString();// Sets the string of Song time to the totalSongTime variable
            CheckingCountdown = false;// Sets the countdown to false
        }

        if (totalSongTime <= 0)
        {
            SceneManager.LoadScene(0);
        }
    }

}
