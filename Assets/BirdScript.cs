using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float FlapStrength;
    public LogicScript logic;
    public bool birdAlive = true;
    public AudioSource src, src1, src2;
    public GameObject pauseButton;
    public AudioClip pau, bgmusic, wing;

    // Start is called before the first frame update
    void Start()
    {
        //src2.PlayOneShot(bgmusic);
        //logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && birdAlive)
        {
            myRigidbody.velocity = Vector2.up * FlapStrength;
            logic.src.PlayOneShot(wing);
        }
        //if (Input.GetKeyDown(KeyCode.P) && birdAlive)
        //{
        //    if (logic.pause == false)
        //    {
        //        pauseButton.SetActive(true);
        //        Time.timeScale = 0;
        //        logic.pause = true;
        //        src1.PlayOneShot(pau);
        //        //src2.Pause();
        //    }
        //    else
        //    {
        //        pauseButton.SetActive(false);
        //        Time.timeScale = 1;
        //        logic.pause = false;
                
        //        src1.PlayOneShot(pau);
        //        //src2.Play();

        //    }
        //}
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        birdAlive = false;
        logic.gameOver();
    }
}
