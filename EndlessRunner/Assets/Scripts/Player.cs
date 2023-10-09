using UnityEngine;

public class Player : MonoBehaviour
{
    public float _speed;
    public float minX;
    public float maxX;

    public GameObject _damageEffect;

    GameManager _gameManager;

    void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        if (_gameManager._gameEnded == true)
            return;

        float inputX = Input.GetAxisRaw("Horizontal");

        transform.position += Vector3.right * inputX * _speed * Time.deltaTime;

        if (transform.position.x > maxX)
            transform.position = new Vector3(maxX, transform.position.y, transform.position.z);

        if (transform.position.x < minX)
            transform.position = new Vector3(minX, transform.position.y, transform.position.z);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "SpikeBall")
        {
            _gameManager.TakeDamage();
            Instantiate(_damageEffect, transform.position, Quaternion.identity);
            Destroy(other.gameObject);
        }
    }
}
