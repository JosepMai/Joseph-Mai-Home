using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderMove : MonoBehaviour
{
    public Transform end;

    public GameObject Point1;
    public GameObject Point2;
    public GameObject Point3;
    public GameObject FinalPoint;
    public GameObject gamemanager;
    public GameObject Slider;

    public bool CheckingIfKey3IsPressed;
    void Start()
    {
        CheckingIfKey3IsPressed = false;
    }

    // Update is called once per frame
    void Update()
    {
        CheckingIfSliderIsMoving();
    }

    public void CheckingIfSliderIsMoving()
    {
        if (Input.GetKey(KeyCode.Alpha3))
        {
            transform.position = Vector3.MoveTowards(transform.position, end.position, 0.01f);
            CheckingIfKey3IsPressed = true;
        }
        else if (CheckingIfKey3IsPressed == true && !Input.GetKey(KeyCode.Alpha3))
        {
            Destroy(Slider);
            CheckingIfKey3IsPressed = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Point1")
        {
            Point1.GetComponent<Renderer>().material.color = new Color(0.3f, 0.3f, 1f);
            FindAnyObjectByType<BeatManager>().score += 1;
        }
        if (collision.gameObject.tag == "Point2")
        {
            Point2.GetComponent<Renderer>().material.color = new Color(0.3f, 0.3f, 1f);
            FindAnyObjectByType<BeatManager>().score += 2;
        }
        if (collision.gameObject.tag == "Point3")
        {
            Point3.GetComponent<Renderer>().material.color = new Color(0.3f, 0.3f, 1f);
            FindAnyObjectByType<BeatManager>().score += 3;
        }
        if (collision.gameObject.tag == "FinalPoint")
        {
            FindAnyObjectByType<BeatManager>().score += 3;
            Destroy(Slider);
        }
    }
}
