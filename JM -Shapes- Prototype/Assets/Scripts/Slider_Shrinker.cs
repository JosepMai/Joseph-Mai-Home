using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slider_Shrinker : MonoBehaviour
{
    //IN PROGRESS
    public float BeatSpeed = 0.005f; //Adjust this value to control the shrinking speed
    private Vector3 originalScale; //Sets the vector 3 to its original Scale

    public GameObject Slider;
    public GameObject[] SliderAccuracy;

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
                Instantiate(SliderAccuracy[1], transform.position + new Vector3(0, -0.25f, 0), Quaternion.identity);
                PlayerPrefs.SetInt("Bad", PlayerPrefs.GetInt("Bad", 0) + 1);
                tl.hitNote++;
                Destroy(transform.root.gameObject);
                Timeline.instance.AccuracyCount += 0.25f;

            }
            else if (transform.localScale.x > 0.75f && transform.localScale.x <= 1f) //Too early
            {
                Instantiate(SliderAccuracy[2], transform.position + new Vector3(0, -0.25f, 0), Quaternion.identity);
                FreezeTheRing = true;
                badHit = true;
                PlayerPrefs.SetInt("Ok", PlayerPrefs.GetInt("Ok", 0) + 1);
                Timeline.instance.AccuracyCount += 0.50f;
                Timeline.instance.HitSoundEffect.Play();
            }
            else if (transform.localScale.x > 0.65f && transform.localScale.x <= 0.75f) //Okay
            {
                Instantiate(SliderAccuracy[3], transform.position + new Vector3(0, -0.25f, 0), Quaternion.identity);
                FreezeTheRing = true;
                goodHit = true;
                PlayerPrefs.SetInt("Good", PlayerPrefs.GetInt("Good", 0) + 1);
                Timeline.instance.AccuracyCount += 0.75f;
                Timeline.instance.HitSoundEffect.Play();
            }
            else if (transform.localScale.x > 0.5f && transform.localScale.x <= 0.65f) //Perfect
            {
                Instantiate(SliderAccuracy[4], transform.position + new Vector3(0, -0.25f, 0), Quaternion.identity);
                FreezeTheRing = true;
                perfectHit = true;
                PlayerPrefs.SetInt("Perfect", PlayerPrefs.GetInt("Perfect", 0) + 1);
                Timeline.instance.AccuracyCount += 1f;
                Timeline.instance.HitSoundEffect.Play();
            }
            else if (transform.localScale.x > 0.3f && transform.localScale.x <= 0.5f)
            {
                Instantiate(SliderAccuracy[0], transform.position + new Vector3(0, -0.25f, 0), Quaternion.identity);
                FreezeTheRing = true;
                badHit = true;
                Timeline.instance.AccuracyCount += 0.25f;
            }
        }
      
        if (transform.localScale.x <= 0.3f)//If the ring is smaller than 0.3f
        {
            tl.ImproperSliderRemove();//Calls Slider Remove
            PlayerPrefs.SetInt("Miss", PlayerPrefs.GetInt("Miss", 0) + 1);
            Destroy(transform.root.gameObject);//Destroys the root of the gameobject
            Timeline.instance.AccuracyCount += 0f;
        }
    }
}
