using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickups : MonoBehaviour
{
    GameManager gameManager;
    [SerializeField] float chaseDistance = 2;
    [SerializeField] float speed = 2f;
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
            gameManager.player.currentHealth = Mathf.Clamp(gameManager.player.currentHealth + 5, 0, gameManager.player.health);
            Destroy(gameObject);
        }
    }
}
