using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class UnityAdsButton : MonoBehaviour
{
#if UNITY_IOS
    private string gameId = "1486551";
#elif UNITY_ANDROID
    private string gameId = "1486550";
#endif

    // Start is called before the first frame update
    void Start()
    {
        Advertisement.Initialize(gameId, true);
    }

    // Update is called once per frame
    public void ShowUnityAd()
    {
        Advertisement.Show();
    }
}
