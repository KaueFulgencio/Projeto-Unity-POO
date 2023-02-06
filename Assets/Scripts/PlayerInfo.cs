using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour
{
    public static PlayerInfo playerInfo;
    public TMP_InputField inputField;
    public string player_name;
    

    private void Awake()
    {
        if (playerInfo == null)
        {
            playerInfo = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetPlayerName()
    {
        player_name = inputField.text;
        SceneManager.LoadSceneAsync("main");
    }

}
