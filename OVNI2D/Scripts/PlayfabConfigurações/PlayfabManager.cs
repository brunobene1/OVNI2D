using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayfabManager : MonoBehaviour
{
    [Header("Display name window")]
    public GameObject nameWindow;
    public GameObject nameError;  // ainda não sei pra que serve esse
    public InputField nameInput;
    public GameObject telaERROnome;


    [Header("NomeJogador")]
    public Text nomeDoJogador;
    public string apelidoDoJogadorAtivo;

    void Start()
    {

        //Login();

        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            Login();
            
            nomeDoJogador.text = apelidoDoJogadorAtivo;
        }

    }

     void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            nomeDoJogador.text = apelidoDoJogadorAtivo;
        }
    }

    void Login()
    {
        var request = new LoginWithCustomIDRequest
        {
            CustomId = SystemInfo.deviceUniqueIdentifier,
            CreateAccount = true,
            InfoRequestParameters = new GetPlayerCombinedInfoRequestParams
            {
                GetPlayerProfile = true
            }

        };
        PlayFabClientAPI.LoginWithCustomID(request, OnSucces, OnError);
    }
    [Header("Botao Leaderboard Menu")]
    public Button BotaoLBPreciso;

    void OnSucces(LoginResult result)
    {
        Debug.Log("Succesful login/account create!");

        string name = null;
        if(result.InfoResultPayload.PlayerProfile != null)
        {
            name = result.InfoResultPayload.PlayerProfile.DisplayName;
            apelidoDoJogadorAtivo = name;
        }
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            if (name == null)
            {
                nameWindow.SetActive(true);

            }
            else
            {
                nameWindow.SetActive(false);
            }
        }
        


        //--------------------BOTAO LB
        if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            BotaoLBPreciso.interactable = true;
        }
    }
    //----------------------------BOTAO MANDAR APELIDO ---------------------------------------
    public void SubmitNameButton()
    {
        var request = new UpdateUserTitleDisplayNameRequest
        {
            DisplayName = nameInput.text,
        };
        PlayFabClientAPI.UpdateUserTitleDisplayName(request, OnDisplayNameUpdate, OnErrornome);
    }

    void OnErrornome( PlayFabError error)
    {
        telaERROnome.SetActive(true);
    }
    
    public void BotaoTelaErroNome()
    {
        telaERROnome.SetActive(false);
    }


    void OnDisplayNameUpdate( UpdateUserTitleDisplayNameResult result)
    {
        Debug.Log("Updated display name!");
        if(SceneManager.GetActiveScene().buildIndex == 0)
            nameWindow.SetActive(false);
    }

    void OnError(PlayFabError error)
    {
        Debug.Log("Error while logging in/creating account!");
        Debug.Log(error.GenerateErrorReport());
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            BotaoLBPreciso.interactable = false;
        }
    }

    public void SendLeaderboard(int scoreF1)
    {
        var request = new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>
            {
                new StatisticUpdate
                {
                    StatisticName = "Fase1LB",
                    Value = scoreF1
                }
            }
        };
        PlayFabClientAPI.UpdatePlayerStatistics(request, OnLeaderboardUpdate, OnError);
    }
    public void SendLeaderboard2(int scoreF2)
    {
        var request = new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>
            {
                new StatisticUpdate
                {
                    StatisticName = "Fase2LB",
                    Value = scoreF2
                }
            }
        };
        PlayFabClientAPI.UpdatePlayerStatistics(request, OnLeaderboardUpdate, OnError);
    }
    public void SendLeaderboard3(int scoreF3)
    {
        var request = new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>
            {
                new StatisticUpdate
                {
                    StatisticName = "Fase3LB",
                    Value = scoreF3
                }
            }
        };
        PlayFabClientAPI.UpdatePlayerStatistics(request, OnLeaderboardUpdate, OnError);
    }

    void OnLeaderboardUpdate(UpdatePlayerStatisticsResult result)
    {
        Debug.Log("Successfull leaderboard sent");
    }
    //------------------------------------ CHAMAR AS LEADERBOARDS -------------------------------------------
    public void GetLeaderboard()
    {
        var request = new GetLeaderboardRequest
        {
            StatisticName = "Fase1LB",
            StartPosition = 0,
            MaxResultsCount = 7
        };
        PlayFabClientAPI.GetLeaderboard(request, OnLeaderboardGet, OnError);
    }
    public void GetLeaderboard2()
    {
        var request = new GetLeaderboardRequest
        {
            StatisticName = "Fase2LB",
            StartPosition = 0,
            MaxResultsCount = 7
        };
        PlayFabClientAPI.GetLeaderboard(request, OnLeaderboardGet2, OnError);
    }
    public void GetLeaderboard3()
    {
        var request = new GetLeaderboardRequest
        {
            StatisticName = "Fase3LB",
            StartPosition = 0,
            MaxResultsCount = 7
        };
        PlayFabClientAPI.GetLeaderboard(request, OnLeaderboardGet3, OnError);
    }

    //---------------------------------------------VARIAVEIS--------------------------
    [Header("Display Leaderboard")]
    public GameObject RowPrefab;
    public Transform LeaderboardInfo1;
    public Transform LeaderboardInfo2;
    public Transform LeaderboardInfo3;
    void OnLeaderboardGet(GetLeaderboardResult result)
    {
        foreach(Transform item in LeaderboardInfo1)
        {
            Destroy(item.gameObject);
        }


        foreach(var item in result.Leaderboard)
        {

            GameObject newGo = Instantiate(RowPrefab, LeaderboardInfo1);
            //pegar os elementos de texto na ordem que aparecem na hierarquia
            Text[] texts = newGo.GetComponentsInChildren<Text>();
            texts[0].text = (item.Position + 1).ToString();
            texts[1].text = item.DisplayName;
            texts[2].text = item.StatValue.ToString();


            Debug.Log("Place :  " + item.Position + "  |  Name :  " + item.DisplayName + "  |  Score :  " + item.StatValue);
        }
    }
    void OnLeaderboardGet2(GetLeaderboardResult result)
    {
        foreach (Transform item in LeaderboardInfo2)
        {
            Destroy(item.gameObject);
        }


        foreach (var item in result.Leaderboard)
        {

            GameObject newGo = Instantiate(RowPrefab, LeaderboardInfo2);
            //pegar os elementos de texto na ordem que aparecem na hierarquia
            Text[] texts = newGo.GetComponentsInChildren<Text>();
            texts[0].text = (item.Position + 1).ToString();
            texts[1].text = item.DisplayName;
            texts[2].text = item.StatValue.ToString();


            Debug.Log("Place :  " + item.Position + "  |  Name :  " + item.DisplayName + "  |  Score :  " + item.StatValue);
        }
    }
    void OnLeaderboardGet3(GetLeaderboardResult result)
    {
        foreach (Transform item in LeaderboardInfo3)
        {
            Destroy(item.gameObject);
        }


        foreach (var item in result.Leaderboard)
        {

            GameObject newGo = Instantiate(RowPrefab, LeaderboardInfo3);
            //pegar os elementos de texto na ordem que aparecem na hierarquia
            Text[] texts = newGo.GetComponentsInChildren<Text>();
            texts[0].text = (item.Position + 1).ToString();
            texts[1].text = item.DisplayName;
            texts[2].text = item.StatValue.ToString();


            Debug.Log("Place :  " + item.Position + "  |  Name :  " + item.DisplayName + "  |  Score :  " + item.StatValue);
        }
    }


    



}
