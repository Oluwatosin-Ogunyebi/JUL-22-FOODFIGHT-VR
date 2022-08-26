using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int number;

    private int score;
    private float timer = 0;
    private bool isGameRunning = false;

    public GameObject[] foodItems;
    public Collider foodSpawnArea;
    public float gameTime;
    public TMP_Text scoreText;
    public TMP_Text timerText;

    private void Start()
    {
        timerText.text = "TIMER: " + gameTime;
    }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }

    }

    public int getScore()
    {
        return score;
    }

    public bool checkIsGameRunning()
    {
        return isGameRunning;
    }

    public int getTime()
    {
        return Mathf.FloorToInt(timer);
    }
    
    public void AddScore()
    {
        score++;
        scoreText.text = "SCORE: " + getScore().ToString();
        Debug.Log("Score: " + getScore());
    }
    //Display Score and Timer

    public void StartGame()
    {
        timer = gameTime;
        isGameRunning = true;
        ResetScore();
    }

    public void ResetScore()
    {
        score = 0;
    }

    public void SpawnFoodItems()
    {
        int randomValue = Random.Range(0, foodItems.Length);
        GameObject randomFoodItem = foodItems[randomValue];

        float x = Random.Range(foodSpawnArea.bounds.min.x, foodSpawnArea.bounds.max.x);
        float y = Random.Range(foodSpawnArea.bounds.min.y, foodSpawnArea.bounds.max.y);
        float z = Random.Range(foodSpawnArea.bounds.min.z, foodSpawnArea.bounds.max.z);

        Vector3 randomPosition = new Vector3(x, y, z);

        Instantiate(randomFoodItem, randomPosition, Quaternion.identity);
    }

    private void Update()
    {
        SetTimer();
    }

    public void SetTimer()
    {
        if (timer > 0 && isGameRunning)
        {
            timer -= Time.deltaTime;
            timerText.text = "TIMER: " + getTime();
            Debug.Log("Timer: " + getTime());
        }
        else
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        isGameRunning = false;
    }
}
