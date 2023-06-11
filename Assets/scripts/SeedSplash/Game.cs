using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public int lives=5;
    public Text livesText;
    public int score = 0;
    public Text scoreText;
    public float timeLeft = 0.0f;
    [SerializeField]
    private int _buildSceneIndex;
    // Start is called before the first frame update
    void Start()
    {
        livesText = GameObject.Find("LiveText").GetComponent<Text>();
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
    }
    public void GetDamage() 
    {
        lives--;
        livesText.text = lives.ToString();
        if (lives == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    public void GetPoint()
    {
        score++;
        scoreText.text = score.ToString();
        if (score == 65)
        {
            SceneManager.LoadScene(_buildSceneIndex, LoadSceneMode.Single);
        }
    }
    // Update is called once per frame
    void Update()
    {
        timeLeft += Time.deltaTime; // вычитаем время, прошедшее с последнего кадра
    }
}
