using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PressToContinue : MonoBehaviour
{
    [SerializeField] GameObject CourageHealth;
    Courage_Health courageHealth;
    [SerializeField] GameObject Player;
    PlayerController player;
    private bool isWaiting = true;

    [SerializeField] int sceneNumber;

    private void Start()
    {
        courageHealth = CourageHealth.GetComponent<Courage_Health>();
        player = Player.GetComponent<PlayerController>();
        StartCoroutine(Wait());
    }

    void Update()
    {
        courageHealth.courageOnLastLevel = player.baseCourage;
        courageHealth.healthOnLastLevel = player.health;

        if (!isWaiting)
        {
            if (Input.GetAxis("Submit") == 1 || Input.GetMouseButton(1))
            {
                SceneManager.LoadScene(sceneNumber);
            }
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.1f);
        isWaiting = false;
    }
}
