using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Score : MonoBehaviour
{

    public Text currentScore;
    public Text highScore;

    private int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        currentScore.text = "000" + score.ToString();
        highScore.text = currentScore.text;
    }
}
