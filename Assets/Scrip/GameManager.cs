using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    //Remember change to true
    public bool IsGameActive = false;
    public int Score = 0;
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI GameOverText;
    public Button StartButton;
    public Button Restart;
    public List<GameObject> Target;
    public float XRange = 8;

    void Start()
    {
        IsGameActive = false;
    }
    public void StartGame()//Remember delete
    {
        StartButton.gameObject.SetActive(false);
        ScoreText.gameObject.SetActive(true);
        IsGameActive = true;
        ScoreText.text = "Score: " + Score;
        StartCoroutine(SpawnTarget());//put back in start
    }
    public void UpdateScore(int addToScore)
    {
        Score += addToScore;
        Debug.Log("Score: " + Score.ToString());
        ScoreText.text = "Score: " + Score.ToString();
    }

    public void GameOver()
    {
        IsGameActive = false;
        GameOverText.gameObject.SetActive(true);
        Restart.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    IEnumerator SpawnTarget()
    {
        while(IsGameActive)
        {
        float xPos = Random.Range(XRange, -XRange);
        float yPos = -9;
        Vector2 spawnPos = new Vector2(xPos, yPos);
        yield return new WaitForSeconds(1);
        int index = Random.Range(0,Target.Count);
        Instantiate(Target[index], spawnPos, Target[index].transform.rotation);
        }
    }
}
