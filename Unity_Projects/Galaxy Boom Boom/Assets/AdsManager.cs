using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour, IUnityAdsListener
{
    // Start is called before the first frame update
    void Start()
    {
        Advertisement.Initialize("4256499");
        Advertisement.AddListener(this);
        ShowBanner();
    }

    public void PlayAds()
    {
        if (Advertisement.IsReady("Interstitial_Android"))
        {
            Advertisement.Show("Interstitial_Android");
        }
    }
    public void PlayRewardedAds()
    {
        if (Advertisement.IsReady("Rewarded_Android"))
        {
            Advertisement.Show("Rewarded_Android");
        }
        else
        {
            Debug.Log("Ad is not ready");
        }
    }
    public void ShowBanner()
    {
        if (Advertisement.IsReady("Banner_Android"))
        {
            Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
            Advertisement.Banner.Show("Banner_Android");
        }
        else
        {
            StartCoroutine(RepeatShowBanner());
        }
        
    }

    IEnumerator RepeatShowBanner()
    {
        yield return new WaitForSeconds(1);
        ShowBanner();
    }
    public void HideBanner()
    {
        Advertisement.Banner.Hide();
    }

    public void OnUnityAdsReady(string placementId)
    {
        Debug.Log("Ad is ready");
    }

    public void OnUnityAdsDidError(string message)
    {
        Debug.Log("ERROR: " + message);
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        Debug.Log("Ad Started");
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if (placementId == "Rewarded_Android" && showResult == ShowResult.Finished)
        {
            Debug.Log("player rewarded");
        }   
    }
}
