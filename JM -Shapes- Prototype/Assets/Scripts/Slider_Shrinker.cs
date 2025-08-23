using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slider_Shrinker : MonoBehaviour
{
    //IN PROGRESS
    public float BeatSpeed = 0.005f; //Adjust this value to control the shrinking speed
    private Vector3 originalScale; //Sets the vector 3 to its original Scale

    public GameObject Slider;

    public bool FreezeTheRing = false;
    public bool miss;
    public bool badHit;
    public bool goodHit;
    public bool perfectHit;

    public Timeline tl;

    // Start is called before the first frame update
    void Start()
    {
        tl = FindAnyObjectByType<Timeline>();
        originalScale = transform.localScale; //Store the original scale
    }


    // Update is called once per frame
    void Update()
    {
        SliderShrink();
        CheckingSliderShrink();
    }

    public void SliderShrink()
    {
        if (transform.localScale.x > 0.20f && transform.localScale.y > 0.20f ) //Check if the object is bigger than the scale 0.2 for x and y
        {
            if (FreezeTheRing == false)
            {
                transform.localScale -= new Vector3(BeatSpeed, BeatSpeed, 0); //Reduce the scale in both X and Y directions
            }
        }
    }
    public void CheckingSliderShrink()
    {
        if(Input.GetKeyUp(KeyCode.Alpha3) && tl.sliderTimings[tl.hitNote] > 0 && tl.notes[tl.hitNote].name == gameObject.name)
        {
            Debug.Log("slider shrinker 1");
            FindAnyObjectByType<Timeline>().hitNote++;
        }
        if (Input.GetKey(KeyCode.Alpha3) && tl.notes[tl.hitNote].name == gameObject.name && transform.localScale.x > 0.75f && transform.localScale.x <= 1f) // way too early
        {
            Debug.Log("slider shrinker 2");
            FindAnyObjectByType<Timeline>().hitNote++;
            Destroy(transform.root.gameObject);
        }
        else if (Input.GetKey(KeyCode.Alpha3) && tl.notes[tl.hitNote].name == gameObject.name && transform.localScale.x > 0.75f && transform.localScale.x <= 1f) // Too early
        {
            FreezeTheRing = true;
            badHit = true;
        }
        else if (Input.GetKey(KeyCode.Alpha3) && tl.notes[tl.hitNote].name == gameObject.name && transform.localScale.x > 0.65f && transform.localScale.x <= 0.75f) // Okay
        {
            FreezeTheRing = true;
            goodHit = true;
        }
        else if (Input.GetKey(KeyCode.Alpha3) && tl.notes[tl.hitNote].name == gameObject.name && transform.localScale.x > 0.5f && transform.localScale.x <= 0.65f) // Perfect
        {
            FreezeTheRing = true;
            perfectHit = true;
        }
        else if (transform.localScale.x <= 0.3f && tl.notes[tl.hitNote].name == gameObject.name)
        {
            tl.SliderRemove();
            Destroy(transform.root.gameObject);
        }
    }
}
