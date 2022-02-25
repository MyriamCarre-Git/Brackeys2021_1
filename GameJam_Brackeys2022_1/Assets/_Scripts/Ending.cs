using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ending : MonoBehaviour
{
    GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();    
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameManager.isEnding = true;
        //SceneManager.LoadScene(6);

        Debug.Log("Ending");
    }
}
