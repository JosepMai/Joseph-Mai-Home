using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPosition : MonoBehaviour
{
    public float randY;
    public float randX;

    public GameObject gameManager;

    public KeyCode key;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void RandomizingPosition()//IEnumerator for randomizing position
    {
        randX = Random.Range(-7.6f, 7.7f);//sets randX to a random number on the x-axis
        randY = Random.Range(-4f, 4f);//sets randY to a random number on the y-axis
        transform.position = new Vector2(randX, randY);//makes the new position the new randX and randY
        //yield return new WaitForSeconds(1f);//Returns out for a second
    }
}
