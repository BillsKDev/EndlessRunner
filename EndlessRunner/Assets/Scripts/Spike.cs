using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    public float _speedEasy;
    public float _speedHard;
    float _speed;
    Spawner _spawner;

    void Start()
    {
        _spawner = FindObjectOfType<Spawner>();
        _speed = Mathf.Lerp(_speedEasy, _speedHard, _spawner.GetDifficultyPercent());
    }

    void Update()
    {
        transform.position += Vector3.back * _speed * Time.deltaTime;
    }
}
