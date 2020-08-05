using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public GameObject pup;

    public static GameOverScreen instance;

    public bool powerup = false;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        powerup = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ContinueGame()
    {
        Time.timeScale = 1f;

    }

    public void PowerUp()
    {
        powerup = true;
        Time.timeScale = 1f;
        pup.SetActive(true);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Game");
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Example 1");
    }
}
