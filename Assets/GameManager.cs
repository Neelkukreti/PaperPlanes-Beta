using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] Text scoreText;
    [SerializeField] Text scoreText2;
    public GameObject howtoPlay;
    public static GameManager instance;
    
    public Text highScore;

    float cpt = 0f;
    int scr = 0;
    
    void Start()
    {
        instance = this;
        highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        Time.timeScale = 1f;
        howtoPlay.SetActive(true);
        Invoke("HowTo", 3f);
    }

    
    void Update()
    {
        if (scr > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", scr);
            highScore.text = scr.ToString();
        }
        
    }

    public void SetScore()
    {
        cpt += Time.deltaTime;
        if (cpt >= .5f)
        {
            cpt = 0f;
            scr++;
            scoreText.text = scr.ToString();
            scoreText2.text = scr.ToString();
        }
    }

    public void HowTo()
    {
        howtoPlay.SetActive(false);
    }
}
