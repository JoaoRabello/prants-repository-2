using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [SerializeField] private List<WaveInfo> _waves = new List<WaveInfo>();
    [SerializeField] private Transform _spawnPoint;

    private WaveInfo _currentWave;
    private int _currentWaveIndex;
    private int _deadEnemyAmount;
    
    //TODO: Remove this and make the enemies know how to find the player
    [SerializeField] private GameObject _playerTarget;
    
    private void Start()
    {
        WaveInvoke(_waves[0]);
    }

    private void WaveInvoke(WaveInfo wave)
    {
        if (wave.Equals(null)) return;
        
        _currentWaveIndex++;
        _currentWave = wave;
        
        foreach (var enemy in wave.Enemies)
        {
            var enemyObject = Instantiate(enemy, null);
            var enemySpawned = enemyObject.GetComponent<Enemy>();

            enemyObject.transform.position = _spawnPoint.position + new Vector3(Random.Range(-2f, 2f), 0, Random.Range(-2f, 2f));
            
            enemySpawned.OnDieEvent += OnEnemyDied;
            enemySpawned.SetTarget(_playerTarget);
        }
    }

    private void OnEnemyDied()
    {
        _deadEnemyAmount++;
        
        if (_deadEnemyAmount < _currentWave.EnemyCount || _currentWaveIndex >= _waves.Count) return;
        
        WaveInvoke(_waves[_currentWaveIndex]);
        _deadEnemyAmount = 0;
    }
}
