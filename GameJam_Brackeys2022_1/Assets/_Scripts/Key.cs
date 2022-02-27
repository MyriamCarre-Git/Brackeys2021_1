using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    GameManager gameManager;
    [SerializeField] float chaseDistance = 2;
    [SerializeField] float speed = 2f;

   [SerializeField] AudioSource audioSource;

    private bool isCloseToPlayer => Vector2.Distance(transform.position, gameManager.player.transform.position) < chaseDistance;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
        
    }

    private void Update()
    {
        if (isCloseToPlayer)
        {
            transform.position = Vector2.MoveTowards(transform.position, gameManager.player.transform.position, speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            audioSource.Play();
            Debug.Log("Got key");
            gameManager.gotKey = true;
            Destroy(gameObject, 0.1f);
        }
    }
}
