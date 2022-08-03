using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstaculo : MonoBehaviour
{
    private float _Dano = 1;
    public GameObject efeitoObstaculo;
    public GameObject obstaculoAudio;
    private GameObject AumentaVel;

    private void Start()
    {
        AumentaVel = GameObject.Find("AumentaVELOCIDADE");
        
    }

    private void Update()
    {
        
        transform.Translate(Vector2.left * AumentaVel.GetComponent<AumentaVelObstaculo>().velocidade * Time.deltaTime);
        
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            Instantiate(obstaculoAudio, transform.position, Quaternion.identity);
            Instantiate(efeitoObstaculo, transform.position, Quaternion.identity);
            collision.GetComponent<Player>()._Vida -= _Dano;
        
            Destroy(gameObject);
        }
    }
    
    
}
