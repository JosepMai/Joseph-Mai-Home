using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slider_Shrinker : MonoBehaviour
{
    
    public float BeatSpeed = 0.005f; //Adjust this value to control the shrinking speed
    public float randX;
    public float randY;
    private Vector3 originalScale; //Sets the vector 3 to its original Scale

    public GameObject gamemanager;
    public GameObject Slider;
    public GameObject Beat1;
    public GameObject Ring1;

    public bool FreezeTheRing = false;
    

    // Start is called before the first frame update
    void Start()
    {
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
        if (Input.GetKey(KeyCode.Alpha3))
        {
            FreezeTheRing = true;
            Ring1.GetComponent<Circle_Shrinker>().CheckingRadiusOfCircle();
            Destroy(transform.parent.gameObject);
        }
    }
}
