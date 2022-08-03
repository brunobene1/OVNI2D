using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruirLixo : MonoBehaviour
{
    [SerializeField]
    private float _tempoVida;
    private void Start()
    {
        Destroy(gameObject, _tempoVida);
    }
}
