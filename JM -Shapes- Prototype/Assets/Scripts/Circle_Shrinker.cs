using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Circle_Shrinker : MonoBehaviour
{
    //LAST UPDATED ON(AUG 16)
    public float BeatSpeed = 0.0035f; //Adjust this value to control the shrinking speed
    private Vector3 originalScale; //Sets the vector 3 to its original Scale

    public bool miss;
    public bool bad;
    public bool ok;
    public bool good;
    public bool perfect;

    public bool startCircleShrinking;
    void Start()
    {
        originalScale = transform.localScale; //Store the original scale
        Invoke("CircleCountdown", 0.15f);
    }

    void Update()
    {
        Circle_Missed();
    }
    private void FixedUpdate()
    {
        if (startCircleShrinking == true)
        {
            Debug.Log("Shrinking");
            Shrink(); //Calls "Shrink" Function
        }
    }

    public void CircleCountdown()
    {
        Debug.Log("Start Shrink");
        startCircleShrinking = true;
    }

    public void Shrink()
    {
        if (transform.localScale.x > 0.20f && transform.localScale.y > 0.20f) //Check if the object is already at the minimum size
        {
            transform.localScale -= new Vector3(BeatSpeed, BeatSpeed, 0) * Time.deltaTime; //Reduce the scale in both X and Y directions
        }
    }
    
    public void MissedNote()
    {
        if (transform.localScale.x <= 0.5f)
        {
            gameObject.GetComponent<Renderer>().material.color = new Color(1f, 0.3f, 0.3f);
        }
        else if (transform.localScale.x >= 0.5f)
        {
            gameObject.GetComponent<Renderer>().material.color = new Color(1, 1, 1);
        }
    }
    public void CheckingRadiusOfCircle()
    {       
        bad = transform.localScale.x >= 0.55f && transform.localScale.x <= 0.9f; //Bad is when the radius/ring of the circle is greater than 0.55f
        ok = transform.localScale.x >= 0.5f && transform.localScale.x <= 0.55f; //Ok is when the radius/ring of the circle is greater than 0.5f and less than 0.55f
        good = transform.localScale.x >= 0.45f && transform.localScale.x <= 0.5f; //Good is when the radius/ring of the circle is greater than 0.45f and less than 0.5f
        perfect = transform.localScale.x >= 0.20f && transform.localScale.x <= 0.45f; //Perfect is when the radius/ring of the circle is greater than 0.3f and less than 0.45f
        if(bad)
        {
            FindAnyObjectByType<BeatManager>().score += 0;
        }
        else if (ok)
        {
            FindAnyObjectByType<BeatManager>().score += 1;
        }
        else if (good)
        {
            FindAnyObjectByType<BeatManager>().score += 2;
        }
        else if (perfect)
        {
            FindAnyObjectByType<BeatManager>().score += 3;
        }

    }

    public void Circle_Missed()
    {
        miss = transform.localScale.x < 0.25f; //Miss is when the radius/ring of circle is less than 0.25f
        if (miss)
        {
            FindAnyObjectByType<Timeline>().hitNote++; //Finds timeline and increases hitNote by 1
            Destroy(transform.parent.gameObject.transform.parent.gameObject);//Destroys the biggest parent
        }

        if (transform.localScale.x <= 0.5f)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.green;//new Color(1f, 0.3f, 0.3f);
        }
        else if (transform.localScale.x >= 0.5f)
        {
            gameObject.GetComponent<Renderer>().material.color = new Color(1, 1, 1);
        }
    }
}
