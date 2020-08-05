using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    [SerializeField] Image CircleImg;
    [SerializeField] Text textProgress;

    [SerializeField] [Range(0, 1)] float progress = 0f;
    int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        count++;
        //Debug.Log(count);
        progress = (float)count/(float)70;
        CircleImg.fillAmount = progress;
        textProgress.text = Mathf.Floor(progress*100).ToString();
        if (progress == 1.0f)
            SceneManager.LoadScene("Game");

    }
}
