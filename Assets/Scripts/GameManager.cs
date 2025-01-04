using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject boss;
    // Menu UIs
    [SerializeField] private GameObject MainMenu;
    [SerializeField] private GameObject PauseMenu;
    [SerializeField] private GameObject GameOverMenu;

    enum states
    {
        MENU,
        PLAY,
        PAUSE,
        OVER
    }

    private states _currentState;
    private states _prevState;
    void Start()
    {
        _currentState = states.MENU;
        _prevState = _currentState;
        EnterMenu();
    }

    void Update()
    {
        _prevState = _currentState;
        // Transitions
        if (Input.GetKeyUp(KeyCode.Return) && _currentState == states.MENU)
        {
            _currentState = states.PLAY;
        }
        else if (Input.GetKeyUp(KeyCode.Escape) && _currentState == states.PLAY)
        {
            _currentState = states.PAUSE;
        }
        else if (boss.GetComponent<EnemyBoss>().isDead && _currentState == states.PLAY)
        {
            _currentState = states.OVER;
        }
        else if (Input.GetKeyUp(KeyCode.Escape) && _currentState == states.PAUSE)
        {
            _currentState = states.PLAY;
        }
        else if (_currentState == states.OVER && Input.GetKeyUp(KeyCode.Escape))
        {
            Quit();
        }
        else if (_currentState == states.OVER && Input.GetKeyUp(KeyCode.Return))
        {
            PlayAgain();
        }

        // Handle the state changes
        if (_prevState != _currentState)
        {
            if (_currentState == states.MENU)
                EnterMenu();
            else if (_currentState == states.PLAY)
                EnterPlay();
            else if (_currentState == states.PAUSE)
                EnterPause();
            else if (_currentState == states.OVER)
                EnterOver();
        }

    }

    public void PlayAgain()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }

    public void Quit()
    {
        Application.Quit();
    }


    // State transitions
    private void EnterMenu()
    {
        MainMenu.SetActive(true);
        player.SetActive(false);
    }
    private void EnterPlay()
    {
        MainMenu.SetActive(false);
        PauseMenu.SetActive(false);
        player.SetActive(true);
        Time.timeScale = 1f;
    }
    private void EnterPause()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }
    private void EnterOver()
    {
        GameOverMenu.SetActive(true);
        player.GetComponent<PlayerMovement>().enabled = false;
    }
}
