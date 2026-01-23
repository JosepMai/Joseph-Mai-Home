using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOut : MonoBehaviour
{
    public float fadeDuration;
    public SpriteRenderer[] letters;
    float transparencyValue = 1;
    public float transparencyRate;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, fadeDuration);
    }

    // Update is called once per frame
    void Update()
    {
        transparencyValue -= Time.deltaTime * transparencyRate;
        for(int i = 0; i < letters.Length;i++)
        {
            letters[i].color = new Color(1, 1, 1, transparencyValue);
        }
    }
}
