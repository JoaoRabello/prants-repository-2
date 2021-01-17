using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;

public class MenuRenderer : MonoBehaviour
{
    public static MenuRenderer Instance;

    [SerializeField] private CommonDataRPC _commonDataRPC;
    [SerializeField] private TMP_InputField _createRoomNameInputField;
    
    [SerializeField] private TMP_Text _characterNameLabel;
    [SerializeField] private TMP_Text _characterClassLabel;
    [SerializeField] private TMP_Text _characterDetailsLabel;
    
    [SerializeField] private GameObject _roomListItemPrefab;
    [SerializeField] private Transform _roomListContainer;
    
    [SerializeField] private GameObject _playerListItemPrefab;
    [SerializeField] private Transform _playerListContainer;

    [SerializeField] private TMP_Text _roomNameLabel;
    [SerializeField] private GameObject _startGameButton;
    
    private List<PlayerListItem> _playerList = new List<PlayerListItem>();
    private List<RoomListItem> _roomList = new List<RoomListItem>();
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    public string GetRoomNameFromInputField()
    {
        return _createRoomNameInputField.text;
    }
    
    public void SetRoomName(string roomName)
    {
        _roomNameLabel.text = roomName;
    }

    public void SetStartGameButton(bool value)
    {
        _startGameButton.SetActive(value);
    }
    
    public void UpdatePlayerList(Player[] players)
    {
        foreach (Transform transformToCheck in _playerListContainer)
        {
            Destroy(transformToCheck.gameObject);
        }
        
        foreach (var player in players)
        {
            var newPlayer = Instantiate(_playerListItemPrefab, _playerListContainer).GetComponent<PlayerListItem>();
            
            newPlayer.SetPlayerName(player.NickName);
            if(_commonDataRPC.PlayerCharacterDictionary.ContainsKey(player.NickName))
                newPlayer.SetCharacterName(_commonDataRPC.PlayerCharacterDictionary[player.NickName]);
            _playerList.Add(newPlayer);
        }
    }
    
    public void UpdateRoomList(List<RoomInfo> roomInfos)
    {
        foreach (Transform transformToCheck in _roomListContainer)
        {
            Destroy(transformToCheck.gameObject);
        }
        
        foreach (var room in roomInfos)
        {
            var newRoom = Instantiate(_roomListItemPrefab, _roomListContainer).GetComponent<RoomListItem>();
            
            newRoom.SetRoomName(room.Name);
            newRoom.SetPlayerAmount(room.PlayerCount, room.MaxPlayers);
            _roomList.Add(newRoom);
        }
    }

    public void RenderCharacterInfo(CharacterInfo info)
    {
        _characterNameLabel.text = info.Name;
        _characterDetailsLabel.text = info.Details;
        _characterClassLabel.text = info.Class;
    }
}
