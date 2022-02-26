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

    [SerializeField] int sceneNumber;

    private void Start()
    {
        courageHealth = CourageHealth.GetComponent<Courage_Health>();
        player = Player.GetComponent<PlayerController>();

    }

    void Update()
    {
        courageHealth.courageOnLastLevel = player.baseCourage;
        courageHealth.healthOnLastLevel = player.health;

        if (Input.GetAxis("Submit") == 1 || Input.GetMouseButton(1))
        {
            SceneManager.LoadScene(sceneNumber);
        }
    }
}
