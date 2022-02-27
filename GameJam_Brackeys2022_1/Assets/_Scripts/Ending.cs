using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ending : MonoBehaviour
{
    GameManager gameManager;

    [SerializeField] Animator highlightBed;


    void Start()
    {
        gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();    
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            highlightBed.SetBool("isInTrigger", true);
            SceneManager.LoadScene("_WIN");
            /*
            if (Input.GetAxis("Submit") == 1 || Input.GetMouseButton(1))
            {
                Debug.Log("fjdksla");
                SceneManager.LoadScene("_WIN");
                gameManager.isEnding = true;
            }*/
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            highlightBed.SetBool("isInTrigger", false);
        }
    }
}
