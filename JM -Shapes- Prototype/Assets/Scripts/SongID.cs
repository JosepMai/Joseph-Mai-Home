using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongID : MonoBehaviour
{
    public int songID;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("CurrentSong", songID);
    }

}
