using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName = "Characters/New Character")]
public class CharacterInfo : ScriptableObject
{
    public string Name;
    public string Class;
    public string Details;

    public GameObject Object;
    public string PrefabName;
}
