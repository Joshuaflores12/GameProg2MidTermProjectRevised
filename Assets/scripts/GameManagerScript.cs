using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool isGameOver = false;

    public void GameOver()
    {
        if (!isGameOver)
        {
            isGameOver = true;


            Debug.Log("Game Over");


            Time.timeScale = 0f;
            SceneManager.LoadScene("GameOver");


        }
    }
}