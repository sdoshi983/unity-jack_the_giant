using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    [SerializeField]
    private AudioClip coinClip, lifeClip;

    private CameraScript cameraScript;

    private Vector3 previousPosition;
    private bool countScore;

    public static int scoreCount;
    public static int lifeCount;
    public static int coinCount;

    private bool gameStarted = true;

    private void Awake()
    {
        cameraScript = Camera.main.GetComponent<CameraScript>();
    }
    void Start()
    {
        previousPosition = transform.position;
        countScore = true;
    }

    void Update()
    {
        CountScore();
    }

    void CountScore()
    {
        if (countScore)
        {
            if (transform.position.y < previousPosition.y && !gameStarted)
            {
                scoreCount++;
            }
            else
                gameStarted = false;

            previousPosition = transform.position;
            GamePlayController.instance.SetScore(scoreCount);
        }
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "Coin")
        {
            coinCount++;
            scoreCount += 200;
            AudioSource.PlayClipAtPoint(coinClip, transform.position);
            target.gameObject.SetActive(false);
            GamePlayController.instance.SetScore(scoreCount);
            GamePlayController.instance.SetCoinScore(coinCount);
        }

        if(target.tag == "Life")
        {
            lifeCount++;
            scoreCount += 300;
            AudioSource.PlayClipAtPoint(lifeClip, transform.position);
            target.gameObject.SetActive(false);
            GamePlayController.instance.SetScore(scoreCount);
            GamePlayController.instance.SetLifeScore(lifeCount);
        }

        if(target.tag == "Bounds" || target.tag == "Deadly")
        {
            cameraScript.moveCamera = false;
            countScore = false;
            transform.position = new Vector3(500, 500, 0);
            lifeCount--;
            
            GameManager.instance.CheckGameStatus(scoreCount, coinCount, lifeCount);
            //GamePlayController.instance.GameOverShowPanel(scoreCount, coinCount);
        }
    }
}
