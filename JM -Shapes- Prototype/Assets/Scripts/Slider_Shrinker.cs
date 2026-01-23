using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slider_Shrinker : MonoBehaviour
{
    //IN PROGRESS
    public float BeatSpeed = 0.005f; //Adjust this value to control the shrinking speed
    private Vector3 originalScale; //Sets the vector 3 to its original Scale

    public GameObject Slider;

    public bool startShrinking;
    public bool FreezeTheRing = false;
    public bool miss;
    public bool badHit;
    public bool goodHit;
    public bool perfectHit;


    public Timeline tl;

    //PlayerInputManager playerInputManager;

    // Start is called before the first frame update
    void Start()
    {
        //playerInputManager = FindObjectOfType<PlayerInputManager>();
        tl = FindAnyObjectByType<Timeline>();
        originalScale = transform.localScale; //Store the original scale
        Invoke("ShrinkCountdown", 0.15f);
    }


    // Update is called once per frame
    void Update()
    {
        CheckingSliderShrink();
    }

    private void FixedUpdate()
    {
        if (startShrinking == true)
        {
            SliderShrink();
        }
    }
    public void ShrinkCountdown()
    {
        startShrinking = true;
    }

    public void SliderShrink()
    {
        if (transform.localScale.x > 0.20f && transform.localScale.y > 0.20f ) //Check if the object is bigger than the scale 0.2 for x and y
        {
            if (FreezeTheRing == false)//If freeze the ring = false
            {
                transform.localScale -= new Vector3(BeatSpeed, BeatSpeed, 0) * Time.deltaTime; //Reduce the scale in both X and Y directions
            }
        }
    }
    public void CheckingSliderShrink()
    {
        if (Input.GetKeyDown(KeyCode.C) && tl.notes[tl.hitNote].name == gameObject.transform.root.name && tl.reachedEnd == false)
        {
            if (transform.localScale.x > 0.75f && transform.localScale.x <= 1f) //Way too early
            {
                tl.hitNote++;
                Destroy(transform.root.gameObject);
            }
            else if (transform.localScale.x > 0.75f && transform.localScale.x <= 1f) //Too early
            {
                FreezeTheRing = true;
                badHit = true;
            }
            else if (transform.localScale.x > 0.65f && transform.localScale.x <= 0.75f) //Okay
            {
                FreezeTheRing = true;
                goodHit = true;
            }
            else if (transform.localScale.x > 0.5f && transform.localScale.x <= 0.65f) //Perfect
            {
                FreezeTheRing = true;
                perfectHit = true;
            }
            else if (transform.localScale.x > 0.3f && transform.localScale.x <= 0.5f)
            {
                FreezeTheRing = true;
                badHit = true;
            }
        }
      
        if (transform.localScale.x <= 0.3f)//If the ring is smaller than 0.3f
        {
            tl.ImproperSliderRemove();//Calls Slider Remove
            Destroy(transform.root.gameObject);//Destroys the root of the gameobject
        }
    }
}
