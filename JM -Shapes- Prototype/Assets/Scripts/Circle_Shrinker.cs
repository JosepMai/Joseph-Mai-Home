using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Circle_Shrinker : MonoBehaviour
{
    //LAST UPDATED ON(AUG 16)
    public float beatSpeed = 0.0035f; //Adjust this value to control the shrinking speed
    private Vector3 originalScale; //Sets the vector 3 to its original Scale

    public int misscounter;
    public int badcounter;
    public int okcounter;
    public int goodcounter;
    public int perfectcounter;
    public bool miss;
    public bool bad;
    public bool ok;
    public bool good;
    public bool perfect;
    public GameObject[] accuracyText;
    public GameObject badText;
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
            Shrink(); //Calls "Shrink" Function
        }
    }

    public void CircleCountdown()
    {
        startCircleShrinking = true;
    }

    public void Shrink()
    {
        if (transform.localScale.x > 0.20f && transform.localScale.y > 0.20f) //Check if the object is already at the minimum size
        {
            transform.localScale -= new Vector3(beatSpeed, beatSpeed, 0) * Time.deltaTime; //Reduce the scale in both X and Y directions
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
            Instantiate(accuracyText[1], transform.position + new Vector3(0, -0.25f, 0), Quaternion.identity);
            FindAnyObjectByType<BeatManager>().score += 0;
            PlayerPrefs.SetInt("Bad", PlayerPrefs.GetInt("Bad", 0) + 1);
        }
        else if (ok)
        {
            Instantiate(accuracyText[2], transform.position + new Vector3(0, -0.25f, 0), Quaternion.identity);
            FindAnyObjectByType<BeatManager>().score += 1;
            PlayerPrefs.SetInt("Ok", PlayerPrefs.GetInt("Ok", 0) + 1);
        }
        else if (good)
        {
            Instantiate(accuracyText[3], transform.position + new Vector3(0, -0.25f, 0), Quaternion.identity);
            FindAnyObjectByType<BeatManager>().score += 2;
            PlayerPrefs.SetInt("Good", PlayerPrefs.GetInt("Good", 0) + 1);
        }
        else if (perfect)
        {
            Instantiate(accuracyText[4], transform.position + new Vector3(0, -0.25f, 0), Quaternion.identity);
            FindAnyObjectByType<BeatManager>().score += 3;
            PlayerPrefs.SetInt("Perfect", PlayerPrefs.GetInt("Pefect", 0) + 1);
        }

    }

    public void Circle_Missed()
    {
        miss = transform.localScale.x < 0.25f; //Miss is when the radius/ring of circle is less than 0.25f
        if (miss)
        {
            FindAnyObjectByType<Timeline>().hitNote++; //Finds timeline and increases hitNote by 1
            FindAnyObjectByType<BeatManager>().score += -1;
            PlayerPrefs.SetInt("Miss", PlayerPrefs.GetInt("Miss", 0) + 1);
            misscounter += 1;
            Instantiate(accuracyText[0], transform.position + new Vector3(0, -0.25f, 0), Quaternion.identity);
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
