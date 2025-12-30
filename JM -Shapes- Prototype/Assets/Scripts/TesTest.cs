using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TesTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    public float riseSpeed = 0.5f;

    void Update()
    {
        moveup();
    }
    public void moveup()
    {
       transform.Translate(Vector3.up * riseSpeed * Time.deltaTime);
        riseSpeed += 1.0f;
    }
}
