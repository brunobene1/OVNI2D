using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class BotoesDoMenu : MonoBehaviour, IUnityAdsListener
{
    string GooglePlay_ID = "";//Google play id
    bool GameMode = true;
    string mySurfacingId = "rewardedVideo";



    bool Fase2 = false;
    public Button Fase2Botao;
    public GameObject AddBotao;

    //----------------------------------------------------------REWARDED VIDEO AD --------------------------------------------------------------------------------
    public void ShowRewardedVideo()
    {
        // Check if UnityAds ready before calling Show method:
        if (Advertisement.IsReady(mySurfacingId))
        {
            Advertisement.Show(mySurfacingId);
        }
        else
        {
            Debug.Log("Rewarded video is not ready at the moment! Please try again later!");
        }
    }

    // Implement IUnityAdsListener interface methods:
    public void OnUnityAdsDidFinish(string surfacingId, ShowResult showResult)
    {
        // Define conditional logic for each ad completion status:
        if (showResult == ShowResult.Finished)
        {
            AddBotao.SetActive(false);
            Fase2 = true;
            // Reward the user for watching the ad to completion.
        }
        else if (showResult == ShowResult.Skipped)
        {
            // Do not reward the user for skipping the ad.
        }
        else if (showResult == ShowResult.Failed)
        {
            Debug.LogWarning("The ad did not finish due to an error.");
        }
    }

    public void OnUnityAdsReady(string surfacingId)
    {
        // If the ready Ad Unit or legacy Placement is rewarded, show the ad:
        if (surfacingId == mySurfacingId)
        {
            // Optional actions to take when theAd Unit or legacy Placement becomes ready (for example, enable the rewarded ads button)
        }
    }

    public void OnUnityAdsDidError(string message)
    {
        // Log the error.
    }

    public void OnUnityAdsDidStart(string surfacingId)
    {
        // Optional actions to take when the end-users triggers an ad.
    }

    // When the object that subscribes to ad events is destroyed, remove the listener:
    public void OnDestroy()
    {
        Advertisement.RemoveListener(this);
    }
    // --------------------------------------------------------------------------------------------------------------------------------------------------------------
    private void Update()
    {
        /*
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            if (Fase2 == false)
            {
                Fase2Botao.interactable = false;
            }
            else if (Fase2 == true)
            {
                Fase2Botao.interactable = true;
            }
        }
         */

        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            if (Fase2 == false)
            {
                Fase2Botao.interactable = false;
            }
            else if (Fase2 == true)
            {
                Fase2Botao.interactable = true;
            }
        }
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            if (Fase2 == false)
            {
                Fase2Botao.interactable = false;
            }
            else if (Fase2 == true)
            {
                Fase2Botao.interactable = true;
            }
        }
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            if (Fase2 == false)
            {
                Fase2Botao.interactable = false;
            }
            else if (Fase2 == true)
            {
                Fase2Botao.interactable = true;
            }
        }
       
    }

    private void Start()
    {
        Advertisement.Initialize(GooglePlay_ID, GameMode);
        Advertisement.AddListener(this);






        Fase2 = false;
        
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            //AddBotao.SetActive(true);
        }
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            AddBotao.SetActive(true);
        }
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            AddBotao.SetActive(true);
        }
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            AddBotao.SetActive(true);
        }
        
    }


    public void DisplayAD()
    {
        Advertisement.Show();
        Fase2 = true;
        AddBotao.SetActive(false);

    }
    //-------------------------------










    public void BotaoJogar()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void BotaoJogar2()
    {
        
        SceneManager.LoadScene("Fase2");
    }
    public void BotaoJogar3()
    {

        SceneManager.LoadScene("Fase3");
    }
    public void VoltarMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
