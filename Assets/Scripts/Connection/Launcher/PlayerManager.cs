using System.Collections;
using System.Collections.Generic;
using System.IO;
using Photon.Pun;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private CurrentCharacter _currentCharacter;
    private PhotonView _photonView;

    private void Awake()
    {
        _photonView = GetComponent<PhotonView>();
    }

    private void Start()
    {
        if (_photonView.IsMine)
        {
            CreateController(_currentCharacter.Info.PrefabName);
        }
    }

    private void CreateController(string characterName)
    {
        var playerObject = PhotonNetwork.Instantiate(Path.Combine("CharacterPrefabs", characterName), SpawnPointManager.Instance.GetSpawnPosition(), Quaternion.identity);
        WaveManager.Instance.OnPlayerSpawned(playerObject);
    }
}
