using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;

public class Looks : MonoBehaviour
{
    public Vector3 rotationSpeed = new Vector3(0,0,0);
    private Vector3 originalScale; //Sets the vector 3 to its original Scale
    // Start is called before the first frame update
    void Start()
    {
        originalScale = transform.localScale; //Store the original scale
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }
}
