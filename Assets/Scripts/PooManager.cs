using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PooManager : MonoBehaviour
{
    public TextMeshProUGUI display_player_name;

    public void Awake()
    {
        display_player_name.text = PlayerInfo.playerInfo.player_name;
    }
}
