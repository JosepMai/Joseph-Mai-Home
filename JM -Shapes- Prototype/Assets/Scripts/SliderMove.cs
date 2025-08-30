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
    public bool checkingIfKey3IsPressed;
    void Start()
    {
        tl = FindAnyObjectByType<Timeline>();
        checkingIfKey3IsPressed = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void MovingSlider()
    {
        //Debug.Log("Inside MovingSlider");
        transform.position = Vector3.MoveTowards(transform.position, end.position, 0.02f);
        checkingIfKey3IsPressed = true; //Sets checkingifKey3IsPressed to true
    }
    public void ExitSlider() // When it reaches the end properly
    {
        tl.hitNote++; //Increases hitNote/Currentnote by 1
        tl.reachedEnd = true;//Sets reachedEnd to true
        tl.holdingSlider = false;
        //tl.holdingSlider = false;
        Destroy(transform.root.gameObject);//Destroys the root of a gameObject
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Point1")
        {
            Point1.GetComponent<Renderer>().material.color = new Color(0.3f, 0.3f, 1f);
            FindAnyObjectByType<BeatManager>().score += 1;
            AddPoints();
            
        }
        if (collision.gameObject.tag == "Point2")
        {
            Point2.GetComponent<Renderer>().material.color = new Color(0.3f, 0.3f, 1f);
            FindAnyObjectByType<BeatManager>().score += 1;
            AddPoints();
        }
        if (collision.gameObject.tag == "Point3")
        {
            Point3.GetComponent<Renderer>().material.color = new Color(0.3f, 0.3f, 1f);
            FindAnyObjectByType<BeatManager>().score += 1;
            AddPoints();
        }
        if (collision.gameObject.tag == "FinalPoint")
        {
            FindAnyObjectByType<BeatManager>().score += 1;
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
            FindAnyObjectByType<BeatManager>().score += 2;
        }
        else if (shrinker.perfectHit)
        {
            FindAnyObjectByType<BeatManager>().score += 3;
        }
    }
}
