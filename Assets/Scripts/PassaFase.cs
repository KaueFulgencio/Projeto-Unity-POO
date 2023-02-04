using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PassaFase : MonoBehaviour
{
    [SerializeField] public string nomeLevelDoJogo;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(nomeLevelDoJogo);
            Debug.Log("ABC");
        }
    }
}
