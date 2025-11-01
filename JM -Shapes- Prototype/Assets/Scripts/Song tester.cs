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
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        songTest += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            placeHolder = songTest;
            Debug.Log("Beat: " + (placeHolder - 0.3f + 0.6));

        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            placeHolder = songTest;
            Debug.Log("Short Slider:" + (placeHolder - 0.3f + 0.6));
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            placeHolder = songTest;
            Debug.Log("Long Slider:" + (placeHolder - 0.3f + 0.6));
        }

        if(Input.GetKeyDown(KeyCode.Alpha4))
        {
            placeHolder = songTest;
            Debug.Log("StackA:" + (placeHolder - 0.3f + 0.6));
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            placeHolder = songTest;
            Debug.Log("StackB:" + (placeHolder - 0.3f + 0.6));
        }
    }
}
