using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotoesLB : MonoBehaviour
{
    public Button BotaoLB1;
    public Button BotaoLB2;
    public Button BotaoLB3;
    public GameObject GOLB1;
    public GameObject GOLB2;
    public GameObject GOLB3;
    //----------------------
    public PlayfabManager pfm;

    private void Start()
    {
        BotaoLB1.interactable = false;
    }

    public void LB1Apertar()
    {
        BotaoLB1.interactable = false;
        BotaoLB2.interactable = true;
        BotaoLB3.interactable = true;
        GOLB1.SetActive(true);
        GOLB2.SetActive(false);
        GOLB3.SetActive(false);
        pfm.GetLeaderboard();
    }
    public void LB2Apertar()
    {
        BotaoLB1.interactable = true;
        BotaoLB2.interactable = false;
        BotaoLB3.interactable = true;
        GOLB1.SetActive(false);
        GOLB2.SetActive(true);
        GOLB3.SetActive(false);
        pfm.GetLeaderboard2();
    }
    public void LB3Apertar()
    {
        BotaoLB1.interactable = true;
        BotaoLB2.interactable = true;
        BotaoLB3.interactable = false;
        GOLB1.SetActive(false);
        GOLB2.SetActive(false);
        GOLB3.SetActive(true);
        pfm.GetLeaderboard3();
    }
}
