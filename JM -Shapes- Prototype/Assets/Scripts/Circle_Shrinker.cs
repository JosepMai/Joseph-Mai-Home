using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Circle_Shrinker : MonoBehaviour
{
    //LAST UPDATED ON(AUG 16)
    public float BeatSpeed = 0.005f; //Adjust this value to control the shrinking speed
    private Vector3 originalScale; //Sets the vector 3 to its original Scale

    public bool Miss;
    public bool Bad;
    public bool Ok;
    public bool Good;
    public bool Perfect;



    void Start()
    {
        originalScale = transform.localScale; //Store the original scale
    }

    void Update()
    {
        Shrink(); //Calls "Shrink" Function
        Circle_Missed();
    }
    
    public void Shrink()
    {
        if (transform.localScale.x > 0.20f && transform.localScale.y > 0.20f) //Check if the object is already at the minimum size
        {
            transform.localScale -= new Vector3(BeatSpeed, BeatSpeed, 0); //Reduce the scale in both X and Y directions
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
        Bad = transform.localScale.x >= 0.55f && transform.localScale.x <= 0.9f; //Bad is when the radius/ring of the circle is greater than 0.55f
        Ok = transform.localScale.x >= 0.5f && transform.localScale.x <= 0.55f; //Ok is when the radius/ring of the circle is greater than 0.5f and less than 0.55f
        Good = transform.localScale.x >= 0.45f && transform.localScale.x <= 0.5f; //Good is when the radius/ring of the circle is greater than 0.45f and less than 0.5f
        Perfect = transform.localScale.x >= 0.30f && transform.localScale.x <= 0.45f; //Perfect is when the radius/ring of the circle is greater than 0.3f and less than 0.45f
        if(Bad)
        {
            FindAnyObjectByType<BeatManager>().score += 1;
        }
        else if (Ok)
        {
            FindAnyObjectByType<BeatManager>().score += 3;
        }
        else if (Good)
        {
            FindAnyObjectByType<BeatManager>().score += 4;
        }
        else if (Perfect)
        {
            FindAnyObjectByType<BeatManager>().score += 5;
        }
    }

    public void Circle_Missed()
    {
        Miss = transform.localScale.x < 0.3f; //Miss is when the radius/ring of circle is less than 0.25f
        if (Miss)
        {
            FindAnyObjectByType<Timeline>().hitNote++;
            Destroy(transform.parent.gameObject.transform.parent.gameObject);
        }

        if (transform.localScale.x <= 0.5f)
        {
            gameObject.GetComponent<Renderer>().material.color = new Color(1f, 0.3f, 0.3f);
        }
        else if (transform.localScale.x >= 0.5f)
        {
            gameObject.GetComponent<Renderer>().material.color = new Color(1, 1, 1);
        }
    }
}
