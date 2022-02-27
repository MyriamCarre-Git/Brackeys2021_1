using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PressToContinueEnding : MonoBehaviour
{
    private bool isWaiting = true;

    [SerializeField] int sceneNumber;

    private void Start()
    {
       
        StartCoroutine(Wait());
    }

    void Update()
    {
        

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
        yield return new WaitForSeconds(4f);
        isWaiting = false;
    }
}
