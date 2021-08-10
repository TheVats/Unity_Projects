using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UI : MonoBehaviour
{
    [SerializeField]
    private Text _scoreText;
    private int Score;
    [SerializeField]
    private Image _livesImg;
    [SerializeField]
    private Text _gameOverText;
    [SerializeField]
    private Sprite[] _livesSprites;
    [SerializeField]
    private Text _restartText;
    private GameManager _gameManager;


    // Start is called before the first frame update
    void Start()
    {
        _gameManager = GameObject.Find("Game_Manager").GetComponent<GameManager>();

        _restartText.gameObject.SetActive(false);
        _gameOverText.gameObject.SetActive(false);
        _scoreText.text = "Score: " + 0;
    }

    // Update is called once per frame
    void Update()
    {
 
    }
    public void Points()
    {
        _scoreText.text = "Score: " + (Score += 10);
    }
    public void UpdateLives(int currentLives)
    {
        _livesImg.sprite = _livesSprites[currentLives];

        if(currentLives == 0)
        {
            GameOverSequence();
        }
    }
    void GameOverSequence()
    {
        _gameManager.GameOver();
        _restartText.gameObject.SetActive(true);
        _gameOverText.gameObject.SetActive(true);
        StartCoroutine(GameOverFlickerRoutine());
    }
    IEnumerator GameOverFlickerRoutine()
    {
        while(true)
        {
            _gameOverText.text = "YOU DED :)";
            yield return new WaitForSeconds(0.2f);
            _gameOverText.text = "";
            yield return new WaitForSeconds(0.2f);
        }
    }

}
