using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int _score;
    public int _health;

    public bool _gameEnded;

    public TMP_Text _scoreText;
    public TMP_Text _healthText;
    public TMP_Text _highScoreText;
    public TMP_Text _scoreTextLoseScreen;
    public TMP_Text _highScoreTextLoseScreen;

    public GameObject _loseScreen;
    GameObject _player;

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");

        if (PlayerPrefs.GetInt("HighScore") <= 0)
        {
            PlayerPrefs.SetInt("HighScore", 0);
        }
    }

    void Update()
    {
        _scoreText.text = _score.ToString();
        _healthText.text = _health.ToString();
        _highScoreText.text = PlayerPrefs.GetInt("HighScore").ToString();

        if (_gameEnded == true)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(0);
            }
        }
    }

    public void TakeDamage()
    {
        _health--;

        if (_health <= 0)
        {
            _gameEnded = true;
            _loseScreen.SetActive(true);
            _scoreTextLoseScreen.text = "Score: " + _score.ToString();
            _highScoreTextLoseScreen.text = "Highscore " + PlayerPrefs.GetInt("HighScore");
            Destroy(_player);
        }
    }
}
