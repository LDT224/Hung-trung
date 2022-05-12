using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text txtScore;
    public Text txtHighScore;
    private int score;
    // Start is called before the first frame update
    void Start()
    {
        txtHighScore.text = "Highscore: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
    }
    public void GetPoint()
    {
        score++;
        txtScore.text = "Score: " + score.ToString();
        if (score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
            txtHighScore.text = score.ToString();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
