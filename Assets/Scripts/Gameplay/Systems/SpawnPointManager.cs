using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Photon.Pun;
using UnityEngine;

public class SpawnPointManager : MonoBehaviour
{
    public static SpawnPointManager Instance;
    
    [SerializeField] private List<Transform> _spawnPoints = new List<Transform>();

    private Dictionary<string, Transform> _playerList = new Dictionary<string, Transform>();

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
        SetCharacterSpawnPoints();
    }

    private void SetCharacterSpawnPoints()
    {
        var playerList = PhotonNetwork.PlayerList;

        for (int i = 0; i < playerList.Length; i++)
        {
            _playerList.Add(playerList[i].NickName, _spawnPoints[i]);
        }
    }

    public Vector3 GetSpawnPosition()
    {
        return _playerList[PhotonNetwork.LocalPlayer.NickName].position;
    }
}
