using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CurrentCharacter", menuName = "Characters/Current Character")]
public class CurrentCharacter : ScriptableObject
{
    public string PlayerName;
    public CharacterInfo Info;
}
