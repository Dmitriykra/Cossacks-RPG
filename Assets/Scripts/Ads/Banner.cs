using GoogleMobileAds.Api;
using UnityEngine;

public class Banner : MonoBehaviour
{

    BannerView _bannerView;
    #if UNITY_ANDROID
    private string _adUnitId = "ca-app-pub-8881364117451669/2315589416";
    #elif UNITY_IPHONE
                  private string _adUnitId = "ca-app-pub-3940256099942544/2934735716";
    #else
                  private string _adUnitId = "unused";
    #endif
    public void Start()
    {
        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(initStatus => {});
        RequestBanner();
    }

    private void RequestBanner()
    {
        _bannerView = new BannerView(_adUnitId, AdSize.Banner, AdPosition.Bottom);
        
        // create our request used to load the ad.
        var adRequest = new AdRequest();

        // send the request to load the ad.
        Debug.Log("Loading banner ad.");
        _bannerView.LoadAd(adRequest);

    }
    // These ad units are configured to always serve test ads.
}
