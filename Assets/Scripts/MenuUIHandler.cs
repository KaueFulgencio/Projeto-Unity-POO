using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    [SerializeField] private string nomeDoLevelDeJogo;
    public void StartNew()
    {
        SceneManager.LoadScene(nomeDoLevelDeJogo);  
    }
    
    public void BackToMenu()
    {
        SceneManager.LoadScene(nomeDoLevelDeJogo);
    }

    public void ExitApplication()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); 
#endif
    }



}
