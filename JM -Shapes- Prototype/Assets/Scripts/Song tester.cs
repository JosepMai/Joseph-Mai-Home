using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Songtester : MonoBehaviour
{
    public float songTest;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        songTest += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(songTest);
        }
    }
}
