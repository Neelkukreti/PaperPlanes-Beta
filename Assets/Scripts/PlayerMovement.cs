using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float rotationSpeed;

    public GameObject GameOverPanel;
    
    public adButtons adButtons;
    public GameObject GameOverPanel2;

    public  GameManager gameManager;
    bool gameover = false;

    //public GameOverScreen gm;

    public GameObject pup;

    Rigidbody2D rb;

  
    Camera cam;

    public AudioClip audC;
    public AudioSource audS;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;
        pup.SetActive(false);
        GameOverPanel.SetActive(false);
        
    }
 
    void Update()
    {
        //get player input
        gameManager.SetScore();
        
    }

    void FixedUpdate()
    {
        //move the player(push the rigidbody)
        if (!gameover)
        {
            rb.AddRelativeForce(new Vector3(moveSpeed * Time.fixedDeltaTime, 0f, 0f));
        }
    }

    void LateUpdate()
    {
        //move the player(push the rigidbody)
        
            cam.transform.position = new Vector3(transform.position.x, transform.position.y, cam.transform.position.z);
        if (GameOverScreen.instance.powerup == true)
        {
            //Debug.Log("Power off will happen");
            Invoke("poweroff", 8.0f);
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy")
        {
            Time.timeScale = 0f;
            
            if(adButtons.counter>0)
            {
                GameOverPanel2.SetActive(true);
            }
            else
            {
                GameOverPanel.SetActive(true);
            }
            audS.PlayOneShot(audC);
        }
    }

    void poweroff()
    {
        pup.SetActive(false);
        GameOverScreen.instance.powerup = false;
        
    }
}
