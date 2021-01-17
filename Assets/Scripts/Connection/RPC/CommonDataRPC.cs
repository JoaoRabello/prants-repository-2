using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

[CreateAssetMenu(fileName = "Common Data", menuName = "Data/Common Character Data")]
public class CommonDataRPC : MonoBehaviour
{
    [SerializeField] private PhotonView _photonView;
    public Dictionary<string, string> PlayerCharacterDictionary = new Dictionary<string, string>();

    [PunRPC]
    public void SetPlayerCharacterInfo(string playerName, string characterName)
    {
        var knownPlayer = PlayerCharacterDictionary.ContainsKey(playerName);

        if (knownPlayer)
        {
            var sameCharacter = PlayerCharacterDictionary[playerName].Equals(characterName);

            if (!sameCharacter)
            {
                PlayerCharacterDictionary[playerName] = characterName;
            }
        }
        else
        {
            PlayerCharacterDictionary.Add(playerName, characterName);
        }
        
        _photonView.RPC("UpdateRoomData", RpcTarget.All);
    }
}
