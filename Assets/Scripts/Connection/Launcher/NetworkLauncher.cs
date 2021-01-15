using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class NetworkLauncher : MonoBehaviourPunCallbacks
{
    public static NetworkLauncher Instance;

    [SerializeField] private int _minimalPlayerCountToStart;
    
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

    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }
    
    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    public override void OnMasterClientSwitched(Player newMasterClient)
    {
        CheckIfMinimumPlayersInRoom();
    }
    
    public override void OnJoinedLobby()
    {
        PhotonNetwork.NickName = "Player " + Random.Range(0, 1000).ToString("0000");
        MenuManager.Instance.OpenWindow("mainMenu");
    }

    public void CreateRoom()
    {
        var inputFieldText = MenuRenderer.Instance.GetRoomNameFromInputField();
        
        if (string.IsNullOrEmpty(inputFieldText)) return;
        
        PhotonNetwork.CreateRoom(inputFieldText);
        
        MenuManager.Instance.OpenWindow("loading");
    }

    public override void OnCreatedRoom()
    {
        PhotonNetwork.CurrentRoom.MaxPlayers = 3;
    }

    public void JoinRoom(string roomName)
    {
        PhotonNetwork.JoinRoom(roomName);
        
        MenuManager.Instance.OpenWindow("loading");
    }
    
    public override void OnJoinedRoom()
    {
        MenuRenderer.Instance.SetRoomName(PhotonNetwork.CurrentRoom.Name);

        var playerList = PhotonNetwork.PlayerList;
        MenuRenderer.Instance.UpdatePlayerList(playerList);
        
        CheckIfMinimumPlayersInRoom();
        
        MenuManager.Instance.OpenWindow("room");
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        var playerList = PhotonNetwork.PlayerList;
        MenuRenderer.Instance.UpdatePlayerList(playerList);
        
        CheckIfMinimumPlayersInRoom();
    }
    
    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        var playerList = PhotonNetwork.PlayerList;
        MenuRenderer.Instance.UpdatePlayerList(playerList);
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        MenuRenderer.Instance.UpdateRoomList(roomList);
    }

    private void CheckIfMinimumPlayersInRoom()
    {
        if(PhotonNetwork.CurrentRoom.PlayerCount >= _minimalPlayerCountToStart)
            MenuRenderer.Instance.SetStartGameButton(PhotonNetwork.IsMasterClient);
    }
    
    public void StartGame()
    {
        if (PhotonNetwork.CurrentRoom.PlayerCount < 2)
            return;
        
        PhotonNetwork.LoadLevel(1);
    }
}
