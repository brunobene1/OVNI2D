using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    public int score;
    public Text scoreDisplay;
    public GameObject JogadorParaPegarAvida;
    public Text scoreDisplay2;
    public Text scoreDisplay3;
    //--------------------------------------
    
    
    
    private void FixedUpdate()
    {
        if (JogadorParaPegarAvida.GetComponent<Player>()._Vida > 0)
        {
            scoreDisplay.text = score.ToString();
            scoreDisplay2.text = scoreDisplay.text;
            scoreDisplay3.text = scoreDisplay.text;
        }
        
        
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstaculo"))
        {
            score++;
            
        }
    }
}
