using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitText : MonoBehaviour
{
    public SpriteRenderer sprite;
    public float decayRate;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        Destroy(gameObject, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        Color currentColor = sprite.color;
        currentColor.a -= Time.deltaTime * decayRate; // Adjust speed as needed
        sprite.color = currentColor;
    }
}
