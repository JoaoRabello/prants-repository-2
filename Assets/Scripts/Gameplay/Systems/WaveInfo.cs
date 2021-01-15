using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Wave", menuName = "Enemy Waves/WaveInfo")]
public class WaveInfo : ScriptableObject
{
    public List<GameObject> Enemies;
    public int EnemyCount => Enemies.Count;
}
