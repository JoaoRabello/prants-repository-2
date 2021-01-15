using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerListItem : MonoBehaviour
{
    [SerializeField] private TMP_Text _playerNameLabel;
    [SerializeField] private TMP_Text _characterNameLabel;

    public void SetPlayerName(string playerName)
    {
        _playerNameLabel.text = playerName;
    }

    public void SetCharacterName(string characterName)
    {
        _characterNameLabel.text = characterName;
    }
}
