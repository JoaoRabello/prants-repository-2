using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public static WaveManager Instance;
    
    [SerializeField] private List<WaveInfo> _waves = new List<WaveInfo>();
    [SerializeField] private Transform _spawnPoint;

    private WaveInfo _currentWave;
    private int _currentWaveIndex;
    private int _deadEnemyAmount;
    
    [SerializeField] private List<GameObject> _players = new List<GameObject>();

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
        StartCoroutine(WaveCooldown());
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
            enemySpawned.SetTarget(_players[0]);
        }
    }

    private IEnumerator WaveCooldown()
    {
        yield return new WaitForSeconds(2f);
        WaveInvoke(_waves[0]);
    }
    
    public void OnPlayerSpawned(GameObject playerObject)
    {
        _players.Add(playerObject);
    }

    private void OnEnemyDied()
    {
        _deadEnemyAmount++;
        
        if (_deadEnemyAmount < _currentWave.EnemyCount || _currentWaveIndex >= _waves.Count) return;
        
        WaveInvoke(_waves[_currentWaveIndex]);
        _deadEnemyAmount = 0;
    }
}
