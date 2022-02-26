using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] GameObject Player;
    [HideInInspector] public PlayerController player;

    [SerializeField] GameObject CourageHealth;
    [HideInInspector] public Courage_Health courageHealth;

    public bool gotKey = false;
    public bool isSafe = false;
    public bool isEnding = false;
    

    private void Awake()
    {
        player = Player.GetComponent<PlayerController>();
        courageHealth = CourageHealth.GetComponent<Courage_Health>();
    }

    private void Start()
    {
        gotKey = false;
    }

   


}
