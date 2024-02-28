using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public GameObject gameOverScreen, bronze, silver, gold, pauseButton;
    public bool blah = true, pause = false;
    public AudioSource src, src1, src2;
    public AudioClip die, hit, point, wing, bgmusic;
    public AudioClip paus;


    void Start()
    {
        src2.clip = bgmusic;
        src2.Play();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && blah)
        {
            if (pause == false)
            {
                Time.timeScale = 0;
                pause = true;
                
                src1.PlayOneShot(paus);
                src2.Pause();
                pauseButton.SetActive(true);
            }
            else
            {
                pauseButton.SetActive(false);
                Time.timeScale = 1;
                pause = false;
                
                src1.PlayOneShot(paus);
                src2.Play();
            }
        }
    }
    public void click()
    {
        Time.timeScale = 1;
        pause = false;
        
        src1.PlayOneShot(paus);
        src2.Play();
        pauseButton.SetActive(false);
    }
    [ContextMenu("Increase Score")]
    public void addScore()
    {
        if (blah)
        {
            playerScore++;
            scoreText.text = playerScore.ToString();
            src1.PlayOneShot(point);
        }
    }
    
    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);        
    }
    public void gameOver()
    {
        gameOverScreen.SetActive(true);
        if (blah)
        {
            src.clip = die;
            src.Play();
            src1.PlayOneShot(hit);
        }
        blah = false;
        if (playerScore < 6)
            bronze.SetActive(true);
        if (playerScore < 11 && playerScore > 5)
            silver.SetActive(true);
        if (playerScore > 10)
            gold.SetActive(true);
    }
}
