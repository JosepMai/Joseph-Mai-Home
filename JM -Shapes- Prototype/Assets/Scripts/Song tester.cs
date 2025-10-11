using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Songtester : MonoBehaviour
{
    public float songTest;
    public float placeHolder;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        songTest += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            placeHolder = songTest;
            Debug.Log("Beat: " + (placeHolder - 0.3f));

        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            placeHolder = songTest;
            Debug.Log("Short Slider:" + (placeHolder - 0.3f));
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            placeHolder = songTest;
            Debug.Log("Long Slider:" + (placeHolder - 0.3f));
        }
    }
}
