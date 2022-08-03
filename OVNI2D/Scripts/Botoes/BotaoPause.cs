using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotaoPause : MonoBehaviour
{
   // public bool _isPaused = false;
    public GameObject PauseObjeto;
    public GameObject BotaoPauseVoltarParaVariavel;

    public void PauseBotao()
    {
        if (BotaoPauseVoltarParaVariavel.GetComponent<BotaoPauseParaVoltar>().isPaused == false)
        {
            Time.timeScale = 0;
            PauseObjeto.SetActive(true);
            BotaoPauseVoltarParaVariavel.GetComponent<BotaoPauseParaVoltar>().isPaused = true;
        }
       
    }
}
