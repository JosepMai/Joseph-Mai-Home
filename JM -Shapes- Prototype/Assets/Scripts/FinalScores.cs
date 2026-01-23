using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class FinalScores : MonoBehaviour
{
    public TextMeshProUGUI PerfectText;
    public TextMeshProUGUI GoodText;
    public TextMeshProUGUI OkText;
    public TextMeshProUGUI BadText;
    public TextMeshProUGUI MissText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        PerfectText.text = "Perfects: " + PlayerPrefs.GetInt("Perfect", 0).ToString();
        GoodText.text = "Goods: " + PlayerPrefs.GetInt("Good", 0).ToString();
        OkText.text = "Ok: " + PlayerPrefs.GetInt("Ok", 0).ToString();
        BadText.text = "Bad: " + PlayerPrefs.GetInt("Bad", 0).ToString();
        MissText.text = "Miss: " + PlayerPrefs.GetInt("Miss", 0).ToString();
    }
}
