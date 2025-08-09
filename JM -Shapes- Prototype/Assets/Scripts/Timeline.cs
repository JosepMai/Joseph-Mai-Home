using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timeline : MonoBehaviour
{
    public GameObject Beat1;
    public GameObject Beat2;
    public GameObject Slider;
    public BeatManager beatManager;

    public float[] noteTimings = { 5, 6.5f, 7.3f, 9.5f, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22 }; // this is in charge of when to spawn the note
    public float[] sliderTimings = { 0, 0, 0, 0, 0, 0, 0, 2 };
    public GameObject[] notes; // this is in charge of the actual notes, it starts empty cause there are none
    public GameObject[] notePrefab;// this is in charge of holding the note prefabs
    public int currentNote;// this is in charge of the current note
    public int hitNote;
    public GameObject note1;
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
        else if (Input.GetKeyDown(KeyCode.Alpha2) && notes[hitNote].name == Beat1.name + "(Clone)")
        {

            MissedNote();
        }

        else if (Input.GetKeyDown(KeyCode.Alpha2) && notes[hitNote].name == Beat2.name + "(Clone)")
        {
            // add score, get rid of note, etc
            CheckHit();

        }

        else if (Input.GetKeyDown(KeyCode.Alpha1) && notes[hitNote].name == Beat2.name + "(Clone)") // u hit the wrong note
        {
            MissedNote();
        }
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
        // We spawn the note, in a random place with a random key associated with it, and we add it to the Notes
        int randomNote = Random.Range(0, notePrefab.Length);
        GameObject nextNote = Instantiate(notePrefab[randomNote], transform.position, Quaternion.identity);
        nextNote.GetComponent<RandomPosition>().RandomizingPosition();
        notes[currentNote] = nextNote;
        currentNote++;
    
    }
    // Update is called once per frame
    void Update()
    {
        HitNote();
        if (currentNote >= noteTimings.Length)
            return;
        if (Time.time >= noteTimings[currentNote] - 1 && Time.time <= noteTimings[currentNote] - 1 + 0.1f) // When its the right timing, we need to spawn the note
        {
            SpawnNext();
        }

    }
}
