using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEditor;
using UnityEngine;

public class CharacterSelectionManager : MonoBehaviour
{
    [SerializeField] private CurrentCharacter _currentCharacter;

    public void SetCurrentCharacter(CharacterInfo characterInfo)
    {
        _currentCharacter.PlayerName = PhotonNetwork.LocalPlayer.NickName;
        _currentCharacter.Info = characterInfo;
        
        MenuRenderer.Instance.RenderCharacterInfo(characterInfo);
    }
}
