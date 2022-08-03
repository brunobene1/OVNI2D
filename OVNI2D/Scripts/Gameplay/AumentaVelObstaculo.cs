using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AumentaVelObstaculo : MonoBehaviour
{
    public float velocidade;
    private float _tempoEntreAumento = 0;
    [SerializeField]
    private float _tempoDeStart;
    [SerializeField]
    private float _tempoMinimo;
    [SerializeField]
    private float _tempoDescendo;
    [SerializeField]
    private float _SpeedIncremento;
    public Animator vidroAnim;
    public Animator EtzaoAnim;
    public GameObject SomVidroAbrindo;
    public bool PodeAtivarSom = false;
    public int cntrlSom = 0;

    private void Start()
    {
        PodeAtivarSom = false;
        cntrlSom = 0;
    }


    private void Update()
    {
        AumentaVel();
        AnimarVidro();
        if (PodeAtivarSom == true && cntrlSom <1 )
        {
            Instantiate(SomVidroAbrindo, transform.position, Quaternion.identity);
            cntrlSom++;
        }
    }
    private void AumentaVel()
    {
        if(SceneManager.GetActiveScene().buildIndex == 1)
        {
            if (velocidade < 9.1f)
            {
                if (_tempoEntreAumento <= 0)
                {

                    velocidade += _SpeedIncremento;

                    _tempoEntreAumento = _tempoDeStart;
                    if (_tempoDeStart > _tempoMinimo)
                    {
                        // _tempoDeStart -= _tempoDescendo;
                        _tempoDeStart = _tempoDescendo;
                    }

                }
                else
                {
                    _tempoEntreAumento -= Time.deltaTime;
                }
            }
        }
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            if (velocidade < 11.6f)
            {
                if (_tempoEntreAumento <= 0)
                {

                    velocidade += _SpeedIncremento;

                    _tempoEntreAumento = _tempoDeStart;
                    if (_tempoDeStart > _tempoMinimo)
                    {
                        // _tempoDeStart -= _tempoDescendo;
                        _tempoDeStart = _tempoDescendo;
                    }

                }
                else
                {
                    _tempoEntreAumento -= Time.deltaTime;
                }
            }
        }
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            if (velocidade < 13f)
            {
                if (_tempoEntreAumento <= 0)
                {

                    velocidade += _SpeedIncremento;

                    _tempoEntreAumento = _tempoDeStart;
                    if (_tempoDeStart > _tempoMinimo)
                    {
                        // _tempoDeStart -= _tempoDescendo;
                        _tempoDeStart = _tempoDescendo;
                    }

                }
                else
                {
                    _tempoEntreAumento -= Time.deltaTime;
                }
            }
        }

    }
    private void AnimarVidro()
    {
        if (velocidade >= 9)
        {
            vidroAnim.SetBool("VidroAbrindo", true);
            PodeAtivarSom = true;
            EtzaoAnim.SetTrigger("EtAbriu");
        }

    }
}
