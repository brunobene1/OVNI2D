using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnPoint : MonoBehaviour
{
    public GameObject obstaculo;
    public GameObject obstaculo2;
    private void Start()
    {
        if(SceneManager.GetActiveScene().buildIndex == 1)
        {
            Instantiate(obstaculo, transform.position, Quaternion.identity);
        }
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            Instantiate(obstaculo, transform.position, Quaternion.identity);
        }
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            Instantiate(obstaculo2, transform.position, Quaternion.identity);
        }



    }
    
}
