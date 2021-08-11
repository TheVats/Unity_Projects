using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    private bool _isGameOver;
    public AdsManager Ads;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1) && _isGameOver == true)
        {
            SceneManager.LoadScene(1);// current game scene
        }
    }
    public void GameOver()
    {
        _isGameOver = true;

    }
    public void Start()
    {
        Ads.ShowBanner();
    }
    public void PLayAd()
    {
        if (_isGameOver == true)
        {
            Ads.PlayAds();
        }

    }

}
