using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TesTest : MonoBehaviour
{
    public GameObject PlayButton;
    public GameObject Canvas;
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
        if (PlayButton == null)
        {
            transform.Translate(Vector3.up * riseSpeed * Time.deltaTime);
            riseSpeed += 1.0f;
        }
        else if (Canvas.GetComponent<ButtonManager>().ClickedStartButton == true)
        {
            riseSpeed = 20f;
            transform.Translate(Vector3.up * riseSpeed * Time.deltaTime);
        }
    }

}
