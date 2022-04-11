using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject pauseMenuGameObject;

    public bool setPaused = false;

    void Start()
    {
       
    }

    void Update()
    {
        if (setPaused)
        {
            setPaused = false;
            
            if (gameIsPaused == true)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            Time.timeScale = 0f;
            gameIsPaused = true;

            if (Input.GetKeyDown(KeyCode.P))
            {
                Resume();
            }
        }
    }

    public void Resume()
    {
        pauseMenuGameObject.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuGameObject.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void ReturnToMainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Title");
    }

    public void Retry()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

}
