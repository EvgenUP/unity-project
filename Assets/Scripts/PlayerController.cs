using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    bool gameEnded = false;

    [Header("Move Handling")]
    public float slowSpeed = 5;
    public float defaultSpeed = 10;
    public float rushSpeed = 15;
    public float currentSpeed = 0;

    [Header("Line Handling")]
    public int lineCount = 5;
    public GameObject[] linePositions;
    int currentLine = 0;

    [Header("Screen Handling")]
    public GameObject loseScreen;
    public GameObject playerUI;

    [Header("Score Handling")]
    int score = 0;
    public TextMeshProUGUI scoreUI;
    public TextMeshProUGUI scoreLose;

    void Start()
    {
        currentSpeed = defaultSpeed;
        currentLine = lineCount / 2;
    }

    void Update()
    {
        if (gameEnded)
        {
            return;
        }

        if (currentLine > 0 && (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)))
        {
            currentLine--;
        }
        else if (currentLine < lineCount - 1 && (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)))
        {
            currentLine++;
        }

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            currentSpeed = rushSpeed;
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) 
        { 
            currentSpeed = slowSpeed;
        }
        else
        {
            currentSpeed = defaultSpeed;
        }

        currentSpeed += Mathf.Min(score / 250, 15);
        
        transform.position = new(
            linePositions[currentLine].transform.position.x,
            transform.position.y,
            transform.position.z + currentSpeed * Time.deltaTime
        );
    }

    public void CollectCoin()
    {
        score++;
        scoreUI.text = "Score: " + score.ToString();
        scoreLose.text = "Score:\n" + score.ToString();
    }

    [System.Obsolete]
    public void HandleObstacle()
    {
        gameEnded = true;
        loseScreen.active = true;
        playerUI.active = false;
    }
}
