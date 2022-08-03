using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    [SerializeField]
    private float _Speed;
    private Vector2 jogadorPos;
    public float _Vida = 3;
    [SerializeField]
    private float _y = 3.5f;
    public GameObject efeitoPlayer;
    public Animator canAnim;
    public GameObject playerAudio;
    public GameObject ETVida01;
    public GameObject ETVida02;
    public GameObject ETVida03;

    private void Update()
    {
        ContagemSemScale();
        ContagemSemScale2();
        //Debug.Log(tempoAnim);
        Movimento();
        Morrer();
    }
    private void Movimento()
    {
        transform.position = Vector2.MoveTowards(transform.position, jogadorPos, _Speed * Time.deltaTime);
        if((Input.GetKeyDown(KeyCode.UpArrow)||Input.GetKeyDown(KeyCode.W)) && transform.position.y < _y)
        {
            //som
            Instantiate(playerAudio, transform.position, Quaternion.identity);
            //camera shake
            canAnim.SetTrigger("shake");
            //particulas movimento
            Instantiate(efeitoPlayer, transform.position, Quaternion.identity);
            //movimento em si
            jogadorPos = new Vector2(transform.position.x, transform.position.y + _y);
        }
        else if ((Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)) && transform.position.y > -_y)
        {
            //som
            Instantiate(playerAudio, transform.position, Quaternion.identity);
            //camera shake
            canAnim.SetTrigger("shake");
            //particulas movimento
            Instantiate(efeitoPlayer, transform.position, Quaternion.identity);
            //movimento em si
            jogadorPos = new Vector2(transform.position.x, transform.position.y - _y);
        }
        else if (transform.position.y > _y)
        {
            transform.position = new Vector2(transform.position.x, _y);
        }
        else if (transform.position.y < -_y)
        {
            transform.position = new Vector2(transform.position.x, -_y);
        }

    }
    private void Start()
    {
        ETVida01.SetActive(true);
        contagemAnuncioIngame = 1;
        //-------------------------------
        BotaoPauseVoltarPreciso.GetComponent<BotaoPauseParaVoltar>().isPaused = false;
        //---------------------------------------
        Time.timeScale = 1;
    }
    //tela de morrer
    public GameObject gameOver;
    public GameObject gameOver2;
    public int contagemAnuncioIngame;
    //----------------------------------------------
    public PlayfabManager playfabManager;
    public GameObject ScoreManagerPrecisoPraPegarScore;
    private void Morrer()
    {
        if(_Vida == 2)
        {
            Destroy(ETVida03);
        }
        else if(_Vida == 1)
        {
            Destroy(ETVida02);
        }
        else if (_Vida == 0)
        {
            if(contagemAnuncioIngame == 1)
            {
                if(SceneManager.GetActiveScene().buildIndex == 1)
                {
                    playfabManager.SendLeaderboard(ScoreManagerPrecisoPraPegarScore.GetComponent<ScoreManager>().score);
                }
                if (SceneManager.GetActiveScene().buildIndex == 2)
                {
                    playfabManager.SendLeaderboard2(ScoreManagerPrecisoPraPegarScore.GetComponent<ScoreManager>().score);
                }
                if (SceneManager.GetActiveScene().buildIndex == 3)
                {
                    playfabManager.SendLeaderboard3(ScoreManagerPrecisoPraPegarScore.GetComponent<ScoreManager>().score);
                }


                gameOver.SetActive(true);
                gameObject.SetActive(false);
                //Destroy(ETVida01);
                ETVida01.SetActive(false);
                Time.timeScale = 0;
                
            }
            else if(contagemAnuncioIngame == 2)
            {
                if (SceneManager.GetActiveScene().buildIndex == 1)
                {
                    playfabManager.SendLeaderboard(ScoreManagerPrecisoPraPegarScore.GetComponent<ScoreManager>().score);
                }
                if (SceneManager.GetActiveScene().buildIndex == 2)
                {
                    playfabManager.SendLeaderboard2(ScoreManagerPrecisoPraPegarScore.GetComponent<ScoreManager>().score);
                }
                if (SceneManager.GetActiveScene().buildIndex == 3)
                {
                    playfabManager.SendLeaderboard3(ScoreManagerPrecisoPraPegarScore.GetComponent<ScoreManager>().score);
                }

                gameOver2.SetActive(true);
                gameObject.SetActive(false);
                //Destroy(ETVida01);
                ETVida01.SetActive(false);
            }
           
           
        }
       
    }
    public Animator Contagem;
    private float tempoAnim;
    private bool iniciarcontagemTempoAnim = false;
    public void BotaoMaisUmaChance()
    {
        gameOver.SetActive(false);
        gameObject.SetActive(true);
        //animação de tempo voltando
        Contagem.SetTrigger("Contagem");
        ETVida01.SetActive(true);
        _Vida++;
        contagemAnuncioIngame++;
        iniciarcontagemTempoAnim = true;
        
    }
    public void ContagemSemScale()
    {
        if (iniciarcontagemTempoAnim)
        {
            tempoAnim += Time.unscaledDeltaTime;
        }
        if (tempoAnim >= 2.5f)
        {
            iniciarcontagemTempoAnim = false;
            Time.timeScale = 1;
            tempoAnim = 0;
        }
    }

    
    public void BotaoCima()
    {
            transform.position = Vector2.MoveTowards(transform.position, jogadorPos, _Speed * Time.deltaTime);
            if (transform.position.y < _y)
            {
                //som
                Instantiate(playerAudio, transform.position, Quaternion.identity);
                //camera shake
                canAnim.SetTrigger("shake");
                //particulas movimento
                Instantiate(efeitoPlayer, transform.position, Quaternion.identity);
                //movimento em si
                jogadorPos = new Vector2(transform.position.x, transform.position.y + _y);
            }
            else if (transform.position.y > _y)
            {
                transform.position = new Vector2(transform.position.x, _y);
            }
            
        
    }
    public void BotaoBaixo()
    {
        if (transform.position.y > -_y)
        {
            //som
            Instantiate(playerAudio, transform.position, Quaternion.identity);
            //camera shake
            canAnim.SetTrigger("shake");
            //particulas movimento
            Instantiate(efeitoPlayer, transform.position, Quaternion.identity);
            //movimento em si
            jogadorPos = new Vector2(transform.position.x, transform.position.y - _y);
        }
        else if (transform.position.y < -_y)
        {
            transform.position = new Vector2(transform.position.x, -_y);
        }
    }
    //botao pause simpatia 

    public GameObject BotaoPauseVoltarPreciso;

    public void ContagemSemScale2()
    {
        //Debug.Log("entreiii");
        if (BotaoPauseVoltarPreciso.GetComponent<BotaoPauseParaVoltar>().iniciarcontagemTempoAnimPause)
        {
            //Debug.Log("ok entrou");
            BotaoPauseVoltarPreciso.GetComponent<BotaoPauseParaVoltar>().tempoAnimPause += Time.unscaledDeltaTime;
        }
        if (BotaoPauseVoltarPreciso.GetComponent<BotaoPauseParaVoltar>().tempoAnimPause >= 2.5f)
        {
            BotaoPauseVoltarPreciso.GetComponent<BotaoPauseParaVoltar>().iniciarcontagemTempoAnimPause = false;
            Time.timeScale = 1;
            BotaoPauseVoltarPreciso.GetComponent<BotaoPauseParaVoltar>().tempoAnimPause = 0;
        }
    }
}
