using UnityEngine;

public class Environment : MonoBehaviour
{
    float _speed;
    public float _speedEasy;
    public float _speedHard;
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

