using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UI : MonoBehaviour
{
    [SerializeField]
    private Text _scoreText;
    public Text BestScoreText;
    private int BestScore;
    public int Score;
    [SerializeField]
    private Image _livesImg;
    [SerializeField]
    private Text _gameOverText;
    [SerializeField]
    private Sprite[] _livesSprites;
    [SerializeField]
    private Text _restartText;
    private GameManager _gameManager;
    public Text LOL;


    // Start is called before the first frame update
    void Start()
    {
        BestScore = PlayerPrefs.GetInt("Best");
        _gameManager = GameObject.Find("Game_Manager").GetComponent<GameManager>();
        BestScoreText.text = "Best Score: " + BestScore;
        _restartText.gameObject.SetActive(false);
        _gameOverText.gameObject.SetActive(false);
        _scoreText.text = "Score: " + 0;
        LOL.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Points()
    {
        _scoreText.text = "Score: " + (Score += 10);
    }

    public void AsteroidPoints()
    {
        _scoreText.text = "Score: " + (Score += 100);
    }
    public void BestScorePoints()
    {
        if (Score > BestScore)
        {
            BestScore = Score;
            PlayerPrefs.SetInt("Best", BestScore);
            BestScoreText.text = "Best Score: " + BestScore;
        }
       
    }
    public void UpdateLives(int currentLives)
    {
        _livesImg.sprite = _livesSprites[currentLives];

        if(currentLives == 0)
        {
            GameOverSequence();
        }
    }
    public void GameOverSequence()
    {
        BestScorePoints();
        _gameManager.GameOver();
        _restartText.gameObject.SetActive(true);
        _gameOverText.gameObject.SetActive(true);
        LOL.gameObject.SetActive(true);
        StartCoroutine(GameOverFlickerRoutine());
    }
    IEnumerator GameOverFlickerRoutine()
    {
        while(true)
        {
            _gameOverText.text = "YOU DIED :)";
            yield return new WaitForSeconds(0.2f);
            _gameOverText.text = "";
            yield return new WaitForSeconds(0.2f);
        }
    }

}
