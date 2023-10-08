using UnityEngine;

public class Environment : MonoBehaviour
{
    public float _speed;

    void Update()
    {
        transform.position += Vector3.back * _speed * Time.deltaTime;
    }
}

