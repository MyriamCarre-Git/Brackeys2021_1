using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    [SerializeField] int sceneNumber;
    [SerializeField] bool isFirstTime;

    [SerializeField] GameObject CourageAndHealth;
    Courage_Health courageAndHealth;
    [SerializeField] GameObject GameManager;
    GameManager gameManager;
    

    private void Start()
    {
        courageAndHealth = CourageAndHealth.GetComponent<Courage_Health>();
        gameManager = GameManager.GetComponent<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (gameManager.gotKey)
            {
                courageAndHealth.courageOnLastLevel = gameManager.player.currentCourage;
                courageAndHealth.healthOnLastLevel = gameManager.player.currentHealth;
                SceneManager.LoadScene(sceneNumber);
            }
            else if (isFirstTime)
            {
                Debug.Log("Need the key");
            }
        }
    }


}
