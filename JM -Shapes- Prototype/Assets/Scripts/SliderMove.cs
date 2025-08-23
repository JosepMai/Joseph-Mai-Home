using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderMove : MonoBehaviour
{
    //IN PROGRESS
    public Transform end;
    public Slider_Shrinker shrinker;
    public GameObject Point1;
    public GameObject Point2;
    public GameObject Point3;
    public GameObject FinalPoint;
    public GameObject gamemanager;
    public GameObject Slider;
    public Timeline tl;
    public bool CheckingIfKey3IsPressed;
    void Start()
    {
        tl = FindAnyObjectByType<Timeline>();
        CheckingIfKey3IsPressed = false;
    }

    // Update is called once per frame
    void Update()
    {
        DestroySliderWhenReleased();
    }

    public void DestroySliderWhenReleased()
    {
        //if (CheckingIfKey3IsPressed == true && !Input.GetKey(KeyCode.Alpha3))
        //{
        //    Destroy(Slider);
        //    CheckingIfKey3IsPressed = false;
        //}
    }
    public void MovingSlider()
    {
        //Debug.Log("Inside MovingSlider");
        transform.position = Vector3.MoveTowards(transform.position, end.position, 0.02f);
        CheckingIfKey3IsPressed = true;
    }
    public void ExitSlider()
    {
        Debug.Log("exit slider");
        //tl.hitNote++;
        Destroy(transform.root.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("test");
        if (collision.gameObject.tag == "Point1")
        {
            Point1.GetComponent<Renderer>().material.color = new Color(0.3f, 0.3f, 1f);
            FindAnyObjectByType<BeatManager>().score += 1;
            AddPoints();
            
        }
        if (collision.gameObject.tag == "Point2")
        {
            Point2.GetComponent<Renderer>().material.color = new Color(0.3f, 0.3f, 1f);
            FindAnyObjectByType<BeatManager>().score += 2;
            AddPoints();
        }
        if (collision.gameObject.tag == "Point3")
        {
            Point3.GetComponent<Renderer>().material.color = new Color(0.3f, 0.3f, 1f);
            FindAnyObjectByType<BeatManager>().score += 3;
            AddPoints();
        }
        if (collision.gameObject.tag == "FinalPoint")
        {
            FindAnyObjectByType<BeatManager>().score += 3;
            AddPoints();
            ExitSlider();
         
        }
    }

    public void AddPoints()
    {
        if(shrinker.badHit)
        {
            FindAnyObjectByType<BeatManager>().score += 1;
        }
        else if (shrinker.goodHit)
        {
            FindAnyObjectByType<BeatManager>().score += 3;
        }
        else if (shrinker.perfectHit)
        {
            FindAnyObjectByType<BeatManager>().score += 5;
        }
    }
}
