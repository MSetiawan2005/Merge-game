using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameUI1 : MonoBehaviour
{
   
    [SerializeField] private float timer;

    //public static Text textScore;

    [SerializeField] private AudioSource GameOverSound;

    public static float timeLeft = 30;

    public Text timerText;

    public Text scoreText;
    public static int scoreCount;

    public static int timerCount;

    private bool isTimeouts;

    public GameObject winCanvas;
    private bool canClick;

    public Text Hiscore;
    public static int hiScoreCount;

    public bool GameAktif = true;
    public GameObject canvasKalah;

    private void Awake()
    {
        timeLeft = 30;
        scoreCount = 0;
    }
    void Start()
    {
        
       StartCoroutine("loseTime");

        if(PlayerPrefs.HasKey("HighScore"))
        {
            hiScoreCount = PlayerPrefs.GetInt("HighScore");
            
        }
    }


    float s;

    private void Update()
    {
        
        if (scoreCount > hiScoreCount)
        {
            hiScoreCount = scoreCount;
            PlayerPrefs.SetInt("HighScore", hiScoreCount);
        }

        //Timer();
        scoreText.text = " " + Mathf.Round(scoreCount);
        timerText.text = (" " + timeLeft);

        Hiscore.text = "  Hi-Score : " + hiScoreCount;


        if (GameAktif)
        {
            s += Time.deltaTime;
            if (s >= 1)
            {
                timeLeft--;
                s = 0;
            }
        }

        if(GameAktif && timeLeft <= 0)
        {
            canvasKalah.SetActive(true);
            Debug.Log("game over");
            GameAktif = false;
            GameOverSound.Play();
        }

       

    }

   IEnumerator loseTime()
    {
        while (true)
        {
            Timer();
            yield return new WaitForSeconds(1f);
            
        }
    }


    //MARKER This function will be called on Update Function
    private void Timer()
    {
       
          
            //timer += Time.deltaTime;
            //timerText.text = timer.ToString("F2");

            if (timeLeft <= 0)//TIME Expire
            {
                isTimeouts = true;
                timerText.text = " ";

                //winCanvas.SetActive(true);
            }
        
    }

    public void RestartGame()
    {
        
            SceneManager.LoadScene("New Scene");
    }









}
