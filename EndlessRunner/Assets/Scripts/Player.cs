using UnityEngine;

public class Player : MonoBehaviour
{
    public float _speed;
    public float minX;
    public float maxX;

    void Update()
    {
        float inputX = Input.GetAxisRaw("Horizontal");

        transform.position += Vector3.right * inputX * _speed * Time.deltaTime;

        if (transform.position.x > maxX)
            transform.position = new Vector3(maxX, transform.position.y, transform.position.z);

        if (transform.position.x < minX)
            transform.position = new Vector3(minX, transform.position.y, transform.position.z);
    }
}
