using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enlarge : MonoBehaviour
{
    public float regularsize; //Adjust this value to control the shrinking speed
    public float smallersize;
    public float speed;
    private Vector3 originalScale; //Sets the vector 3 to its original Scale
    // Start is called before the first frame update
    void Start()
    {
        speed = (regularsize - smallersize) / 0.15f;
        originalScale = transform.localScale; //Store the original scale
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localScale.x < 0.5f && transform.localScale.y < 0.5f) //Check if the object is already at the minimum size
        {
            transform.localScale += new Vector3(1,1,1) * speed * Time.deltaTime; //Reduce the scale in both X and Y directions
        }

    }
}
