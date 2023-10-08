using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int _score;
    public int _health;

    public TMP_Text _scoreText;
    public TMP_Text _healthText;

    void Update()
    {
        _scoreText.text = _score.ToString();
        _healthText.text = _health.ToString();
    }

    public void TakeDamage()
    {
        _health--;

        if (_health <= 0 )
        {
            SceneManager.LoadScene(0);
        }
    }
}
