using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMovendo : MonoBehaviour
{
    [SerializeField]
    private float _SpeedBG;
    [SerializeField]
    private float _FinalBG;
    [SerializeField]
    private float _ComeçoBG;
    [SerializeField]
    private float _SpeedMax;

    private void Update()
    {
        transform.Translate(Vector2.left * _SpeedBG * Time.deltaTime);
        AumentaVel();

        if (transform.position.x <= _FinalBG)
        {
            Vector2 pos = new Vector2(_ComeçoBG, transform.position.y);
            transform.position = pos;
        }
    }
    private float _tempoEntreAumento = 0;
    [SerializeField]
    private float _tempoDeStart;
    [SerializeField]
    private float _tempoMinimo;
    [SerializeField]
    private float _tempoDescendo;
    [SerializeField]
    private float _SpeedIncremento;
    private void AumentaVel()
    {
        if (_SpeedBG < _SpeedMax)
        {
            if (_tempoEntreAumento <= 0)
            {

                _SpeedBG += _SpeedIncremento;

                _tempoEntreAumento = _tempoDeStart;
                if (_tempoDeStart > _tempoMinimo)
                {
                    _tempoDeStart -= _tempoDescendo;
                }

            }
            else
            {
                _tempoEntreAumento -= Time.deltaTime;
            }
        }
    }
}
