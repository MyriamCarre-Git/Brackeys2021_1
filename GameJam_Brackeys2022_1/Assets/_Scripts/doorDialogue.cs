using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorDialogue : MonoBehaviour
{
    [SerializeField] TextTrigger textTrigger;
    private GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Trigger");

            if (Input.GetAxis("Submit") == 1 || Input.GetMouseButton(1))
            {
                textTrigger.TriggerDialogue();
                if (!gameManager.gotKey)
                {
                    //textTrigger.TriggerDialogue();
                }
            }
        }
    }
}
