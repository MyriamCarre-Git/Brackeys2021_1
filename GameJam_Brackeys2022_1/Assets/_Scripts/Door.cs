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
    [SerializeField] GameObject textTrigger;
    [SerializeField] Animator anim;

    private bool isPressed = false;

    private void Start()
    {
        courageAndHealth = CourageAndHealth.GetComponent<Courage_Health>();
        gameManager = GameManager.GetComponent<GameManager>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            anim.SetBool("isInTrigger", true);

            if (Input.GetAxis("Submit") == 1 || Input.GetMouseButton(1))
            {
                Debug.Log("button pressed");
                if (!isPressed)
                {
                    if (gameManager.gotKey)
                    {
                        courageAndHealth.courageOnLastLevel = gameManager.player.currentCourage;
                        courageAndHealth.healthOnLastLevel = gameManager.player.currentHealth;
                        SceneManager.LoadScene(sceneNumber);
                    }
                    else
                    {
                        textTrigger.GetComponent<TextTrigger>().TriggerDialogue();
                        Debug.Log("Debug: Need the key");
                        isPressed = true;
                    }
                }
                
            }
            else if(Input.GetAxis("Submit") == 0)
            {
                isPressed = false;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            anim.SetBool("isInTrigger", false);
        }
    }



}
