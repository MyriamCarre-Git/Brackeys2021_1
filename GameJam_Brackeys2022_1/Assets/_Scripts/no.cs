using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class no : MonoBehaviour
{
    [SerializeField] GameObject NotRealMonsterPrefab;

    private float time;
    public float minTime;
    public float maxTime;

    private bool isCoroutine = false;
    [SerializeField] GameObject GameManager;
    GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.GetComponent<GameManager>();
    }


    private void Update()
    {
        time = Random.Range(minTime, maxTime);
        
        if (!isCoroutine)
        {
            StartCoroutine(Spawn());
        }

    }

    IEnumerator Spawn()
    {
        isCoroutine = true;
        yield return new WaitForSeconds(time);

        Instantiate(NotRealMonsterPrefab, GeneratePosition(), Quaternion.identity);
        isCoroutine = false;
    }

    private Vector2 GeneratePosition()
    {
        float x, y;

        x = gameManager.player.transform.position.x + Random.Range(-7, 7);
        y = gameManager.player.transform.position.y + Random.Range(-7, 7);

        return new Vector2(x, y);
    }

   
}
