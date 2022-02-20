using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] GameObject Player;
    PlayerController player;
    [SerializeField] GameObject LightObject;
    LightScript lightScript;


    private void Awake()
    {
        //LightObject = FindObjectOfType<GameObject LightObject>();
        player = Player.GetComponent<PlayerController>();
        //lightScript = LightObject.GetComponent<LightScript>();
    }

    private void Update()
    {
        //InLight();
        //player.CourageDepletion();
    }

   
}
