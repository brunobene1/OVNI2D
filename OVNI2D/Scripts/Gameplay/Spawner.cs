using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject [] padroesObstaculo;
    private float _tempoEntreSpawn;
    [SerializeField]
    private float _tempoDeStart;
    [SerializeField]
    private float _tempoDescendo;
    [SerializeField]
    private float _tempoMinimo;

    private void Update()
    {
        if(_tempoEntreSpawn <= 0)
        {
            int rand = Random.Range(0, padroesObstaculo.Length);
            Instantiate(padroesObstaculo[rand], transform.position, Quaternion.identity);
            _tempoEntreSpawn = _tempoDeStart;
            if(_tempoDeStart > _tempoMinimo)
            {
                _tempoDeStart -= _tempoDescendo;
            }
           
        }
        else
        {
            _tempoEntreSpawn -= Time.deltaTime;
        }
    }
}
