using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotaoPauseParaVoltar : MonoBehaviour
{
    public bool isPaused;
    public GameObject PauseObjeto;
    //--------------------------------
    public Animator Contagemm;
    public float tempoAnimPause;
    public bool iniciarcontagemTempoAnimPause = false;

    private void Update()
    {
        //ContagemSemScale2();
        //Debug.Log(tempoAnimPause);
    }
    /*
    public void ContagemSemScale2()
    {
        Debug.Log("entreiii");
        if (iniciarcontagemTempoAnimPause)
        {
            Debug.Log("ok entrou");
            tempoAnimPause += Time.unscaledDeltaTime;
        }
        if (tempoAnimPause >= 2.5f)
        {
            iniciarcontagemTempoAnimPause = false;
            Time.timeScale = 1;
        }
    }
     */

    private void Start()
    {
        
            
       
       
    }

    public void VoltarBotao()
    {
        if (isPaused == true)
        {
            isPaused = false;
            PauseObjeto.SetActive(false);
            Contagemm.SetTrigger("Contagem");
            iniciarcontagemTempoAnimPause = true;
           // Debug.Log("oi");
       
        }
        
    }
}
