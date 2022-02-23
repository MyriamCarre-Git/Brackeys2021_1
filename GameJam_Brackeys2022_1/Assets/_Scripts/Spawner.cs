using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject NotRealMonsterPrefab;

    private float time;
    float clampTime;
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
        //time = Random.Range(minTime * gameManager.player.currentCourage / 2 , maxTime * gameManager.player.currentCourage / 2);
        //clampTime = Mathf.Clamp(time, 1f, 2f);
        time = Random.Range(minTime, maxTime);

        /*
        if(gameManager.player.currentCourage <= 5)
        {
            minTime = minTime + (1 * Time.deltaTime);
            maxTime = maxTime + (1 * Time.deltaTime);
        }
        */

        if (!isCoroutine && gameManager.player.currentCourage <= 12)
        {
            StartCoroutine(Spawn());
        }
    }

    IEnumerator Spawn()
    {
        isCoroutine = true;
        Instantiate(NotRealMonsterPrefab, GeneratePosition(), Quaternion.identity);
        yield return new WaitForSeconds(time);

        isCoroutine = false;
    }

    private Vector2 GeneratePosition()
    {
        float x, y;

        x = gameManager.player.transform.position.x + Random.Range(-15, 15);
        y = gameManager.player.transform.position.y + Random.Range(-15, 15);

        return new Vector2(x, y);
    }

}
