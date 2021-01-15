using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RoomListItem : MonoBehaviour
{
    [SerializeField] private TMP_Text _roomNameLabel;
    [SerializeField] private TMP_Text _playerAmountLabel;

    private string _name;
    private int _playerAmount;
    
    public void SetRoomName(string roomName)
    {
        _roomNameLabel.text = roomName;
        _name = roomName;
    }

    public void SetPlayerAmount(int playerAmount, int playerMax)
    {
        _playerAmountLabel.text = $"{playerAmount}/{playerMax}";
        _playerAmount = playerAmount;
    }
    
    public void OnClick()
    {
        NetworkLauncher.Instance.JoinRoom(_name);
    }
}
