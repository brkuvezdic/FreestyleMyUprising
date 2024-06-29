/*using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{

    [Header("Game Over")]
    public GameObject gameOverScreen;
    public Button restartButton;
    public Button mainMenuButton;
    public Button quitButton;


    [Header("Pause")]
    public GameObject pauseScreen;

    void Start()
    {
        gameOverScreen.SetActive(false);
        pauseScreen.SetActive(false);

        restartButton.onClick.AddListener(RestartGame);
        mainMenuButton.onClick.AddListener(GoToMainMenu);
        quitButton.onClick.AddListener(QuitGame);
    }

    private void Update()
{
    if(Input.GetKeyDown(KeyCode.Escape)){
        if(pauseScreen.activeInHierarchy)
            PauseGame(false);
        else
            PauseGame(true);
    }
}
    #region Game Over

    public void ShowGameOverScreen()
    {
        gameOverScreen.SetActive(true);
        Time.timeScale = 0.25f; // Pause the game
    }

    void RestartGame()
    {
        Time.timeScale = 1f; // Resume the game
        if(playerController != null) // Provjerite da li je referenca na igrača postavljena
        {
            playerController.ResetPlayer();
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f; // Resume the game
        SceneManager.LoadScene("MainMenu"); // Make sure you have a scene named "MainMenu"
    }

    public void QuitGame()
    {
        Application.Quit();

#if UNITY_EDITOR
    UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
#endregion

    #region Pause
    public void PauseGame(bool status){
        pauseScreen.SetActive(status);

    if(status)
        Time.timeScale = 0;
    else
        Time.timeScale = 1;

    }

    public void SoundVolume()
    {

    }

    public void MusicVolume()
    {
        
    }
    #endregion
}*/


