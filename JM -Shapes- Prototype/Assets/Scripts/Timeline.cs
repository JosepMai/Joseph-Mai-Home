using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timeline : MonoBehaviour
{
    //IN PROGRESS
    public GameObject Beat1;
    public GameObject Beat2;
    public GameObject Beat3;
    public GameObject Slider;
    public BeatManager beatManager;

    public bool checkingIfKey3IsPressed;

    public float[] noteTimings; // this is in charge of when to spawn the note
    public float[] sliderTimings;
    public float[] stack;
    public bool[] stackStart;
    public float[] sliderSpeeds;
    public Vector3 stackPos;
    public GameObject stackNote;
    public GameObject[] notes; // this is in charge of the actual notes, it starts empty cause there are none
    public GameObject[] notePrefab;// this is in charge of holding the note prefabs
    public int currentNote;// this is in charge of the current note
    public int hitNote;
    public bool holdingSlider;
    public bool reachedEnd;
    // Start is called before the first frame update
    void Start()
    {
        notes = new GameObject[noteTimings.Length];  // Initialize array to the same length
        for (int i = 0; i < notes.Length; i++)
        {
            notes[i] = null; // Make it explicitly empty
        }
    }

    public void HitNote()
    {
        if (hitNote == notes.Length || notes[hitNote] == null)
            return;
        // When we press a key, we check to see if it aligns with the current note and current time
        if (Input.GetKeyDown(KeyCode.Alpha1) && notes[hitNote].name == Beat1.name + "(Clone)")
        {
            CheckHit();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && notes[hitNote].name == Beat1.name + "(Clone)" || Input.GetKeyDown(KeyCode.Alpha3) && notes[hitNote].name == Beat1.name + "(Clone)")
        {
            MissedNote();
        }

        else if (Input.GetKeyDown(KeyCode.Alpha2) && notes[hitNote].name == Beat2.name + "(Clone)")
        {
            // add score, get rid of note, etc
            CheckHit();
        }

        else if (Input.GetKeyDown(KeyCode.Alpha1) && notes[hitNote].name == Beat2.name + "(Clone)" || Input.GetKeyDown(KeyCode.Alpha3) && notes[hitNote].name == Beat2.name + "(Clone)") // u hit the wrong note
        {
            MissedNote();
        }

        else if (Input.GetKeyDown(KeyCode.Alpha3) && notes[hitNote].name == Beat3.name + "(Clone)")
        {
            CheckHit();
        }

        else if (Input.GetKeyDown(KeyCode.Alpha1) && notes[hitNote].name == Beat3.name + "(Clone)" || Input.GetKeyDown(KeyCode.Alpha2) && notes[hitNote].name == Beat3.name + "(Clone)") // u hit the wrong note
        {
            MissedNote();
        }

        else if (Input.GetKey(KeyCode.C) && notes[hitNote].name == Slider.name + "(Clone)" + hitNote && reachedEnd == false)
        {
            HitSlider(); // This checks the initial press for sliders
        }
    }

    public void HitSlider() // This checks the initial press for sliders
    {
        holdingSlider = true;//Sets holdingSlider to true
        notes[hitNote].GetComponentInChildren<SliderMove>().MovingSlider();//Calls Moving Slider in SliderMove
    }

    public void CheckHit()
    {
        notes[hitNote].GetComponentInChildren<Circle_Shrinker>().CheckingRadiusOfCircle();
        Destroy(notes[hitNote]);
        hitNote++;
    }

    public void MissedNote()
    {
        notes[hitNote].GetComponentInChildren<Circle_Shrinker>().MissedNote();
        Destroy(notes[hitNote]);
        hitNote++;
    }

    public void SpawnNext() // Spawns the next note
    {
        float randomZRotation = Random.Range(0f, 360f);
        Quaternion randomRotation = Quaternion.Euler(0f, 0f, randomZRotation);
        // We spawn the note, in a random place with a random key associated with it, and we add it to the Notes
        if (sliderTimings[currentNote] == 0) // Regular notes
        {
            if(stack[currentNote] > 0 && stackStart[currentNote])
            {
                int randomNote = Random.Range(0, notePrefab.Length);// Randomize beat 1 or 2
                stackNote = notePrefab[randomNote]; // Store randomly picked one into stackNote which is public and can be reused
                GameObject nextNote = Instantiate(stackNote, transform.position, Quaternion.identity);
                nextNote.GetComponent<RandomPosition>().RandomizingPosition();
                stackPos = nextNote.transform.position; // Stores the randomly set position into stackPos which is public and can be reused
                stack[currentNote + 1] = stack[currentNote] - 1;
                notes[currentNote] = nextNote;
            }
            else if (stack[currentNote] > 0 && !stackStart[currentNote])
            {
                GameObject nextNote = Instantiate(stackNote, stackPos, Quaternion.identity);
                stack[currentNote + 1] = stack[currentNote] - 1;
                notes[currentNote] = nextNote;
            }
            else
            {
                int randomNote = Random.Range(0, notePrefab.Length);
                GameObject nextNote = Instantiate(notePrefab[randomNote], transform.position, Quaternion.identity);
                nextNote.GetComponent<RandomPosition>().RandomizingPosition();
                notes[currentNote] = nextNote;
            }
            currentNote++;
        }
        else if (sliderTimings[currentNote] == 1) // Slider
        {
            GameObject nextNote = Instantiate(Slider, transform.position, randomRotation);
            nextNote.GetComponent<RandomPosition>().RandomizingPosition();
            nextNote.name = nextNote.name + currentNote;
            nextNote.GetComponent<RandomPosition>().sliderSpeedRef.sliderDuration = sliderSpeeds[currentNote];
            notes[currentNote] = nextNote;
            currentNote++;
        }
    }

    public void SliderRemove()
    {
        holdingSlider = false;
        notes[hitNote].GetComponentInChildren<SliderMove>().ExitSlider();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.C) && holdingSlider/*&& tl.notes[tl.hitNote].name == gameObject.name*/)//If it gets key 3 and holding Slider = true
        {
            SliderRemove();
            reachedEnd = false;

        }
        else if (Input.GetKeyUp(KeyCode.C) && !holdingSlider)//If it gets key 3 and holdingSlider = false
        {
            reachedEnd = false;
            SliderRemove();
        }
        HitNote();
        Debug.Log("testA");
        if (currentNote >= noteTimings.Length)
            return;
        Debug.Log("testB");
        if (Time.time >= noteTimings[currentNote] - 1.15 && Time.time <= noteTimings[currentNote] - 1.15 + 0.15f) // When its the right timing, we need to spawn the note
        {
            Debug.Log("Test1");
            SpawnNext();
        }
    }
}
