﻿using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    public GameObject hazard;
    public int hazardCount;
    public Vector3 spawnValues;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public GUIText scoreText;
    private int score;

    bool gameOver = false;

    // Use this for initialization
    void Start()
    {
        score = 0;
        UpdateScore();
        StartCoroutine(SpawnWaves());
    }

	IEnumerator SpawnWaves ()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            if (gameOver)
            {
                //restartText.text = "Press 'R' for Restart";
                //restart = true;
                break;
            }
        }
           
	}

    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    public void GameOver()
    {
        gameOver = true;
    }
	
	
}