using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<Transform> _spawnPointsStart;
    public List<Transform> _spawnPoints;

    public Transform[] _environmentSpawnPoints;
    public GameObject[] _environmentPrefabs;
    
    public int _numberOfSpawns;
    public float _timeBetweenSpawnsEasy;
    public float _timeBetweenSpawnsHard;
     
    public float _timeBetweenEnvironmentSpawnsMin;
    public float _timeBetweenEnvironmentSpawnsMax;
    
    public float _timeBetweenNextDifficulty;

    float _nextEnvironmentSpawnTime;
    float _nextSpawnTime;

    public GameObject _spikeBall;

    GameManager _gameManager;

    void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        if (_gameManager._gameEnded == true)
            return;

        if (Time.time > _nextSpawnTime)
        {
            _gameManager._score++;

            if (_gameManager._score > PlayerPrefs.GetInt("HighScore"))
            {
                PlayerPrefs.SetInt("HighScore", _gameManager._score);
            }

            for (int i = 0; i < _numberOfSpawns; i++)
            {
                Transform randomSpawnPoint = _spawnPoints[Random.Range(0, _spawnPoints.Count)];
                Instantiate(_spikeBall, randomSpawnPoint.position, randomSpawnPoint.rotation);
                _spawnPoints.Remove(randomSpawnPoint);
            }

            _spawnPoints.Clear();
            
            for (int i = 0; i < _spawnPointsStart.Count; i++)
            {
                _spawnPoints.Add(_spawnPointsStart[i]);
            }

            _nextSpawnTime = Time.time + Mathf.Lerp(_timeBetweenSpawnsEasy, _timeBetweenSpawnsHard, GetDifficultyPercent());
        }

        if (Time.time > _nextEnvironmentSpawnTime)
        {
            for (int i = 0; i < _environmentSpawnPoints.Length; i++)
            {
                GameObject randomPrefab = _environmentPrefabs[Random.Range(0, _environmentPrefabs.Length)];
                Instantiate(randomPrefab, _environmentSpawnPoints[i].position, _environmentSpawnPoints[i].rotation);
            }

            _nextEnvironmentSpawnTime = Time.time + Random.Range(_timeBetweenEnvironmentSpawnsMin, _timeBetweenEnvironmentSpawnsMax);
        }
    }

    public float GetDifficultyPercent()
    {
        return Mathf.Clamp01(Time.timeSinceLevelLoad / _timeBetweenNextDifficulty);
    }
}
