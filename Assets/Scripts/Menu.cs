using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject chapterMenu;
    [SerializeField] GameObject howToMenu;
    [SerializeField] GameObject mainFocus;
    [SerializeField] GameObject pauseFocus;
    [SerializeField] GameObject chapterFocus;
    [SerializeField] GameObject howToFocus;
    [SerializeField] GameObject menuBackground;

    private EventSystem es;
    private bool gamePaused = false;
    private bool gameStarted = false;

    public bool useMouse = true;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        es = FindFirstObjectByType<EventSystem>();
        es.SetSelectedGameObject(mainFocus);
    }

    void Update()
    {
        if (!gameStarted && Input.GetButtonDown("Cancel")) BackToMain();
        if (gamePaused && Input.GetButtonDown("Cancel")) UnPauseGame();
        if (gameStarted && !gamePaused && Input.GetButtonDown("Pause")) PauseGame();
    }

    public void PlayGame()
    {
        mainMenu.SetActive(false);
        menuBackground.SetActive(false);
        gameStarted = true;
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Additive);
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        gamePaused = true;
        pauseMenu.SetActive(true);
        menuBackground.SetActive(true);
        es.SetSelectedGameObject(pauseFocus);
    }

    public void UnPauseGame()
    {
        Time.timeScale = 1f;
        gamePaused = false;
        pauseMenu.SetActive(false);
        menuBackground.SetActive(false);
    }

    public void Chapters()
    {
        chapterMenu.SetActive(true);
        mainMenu.SetActive(false);
        es.SetSelectedGameObject(chapterFocus);
    }

    public void HowToPlay()
    {
        howToMenu.SetActive(true);
        mainMenu.SetActive(false);
        pauseMenu.SetActive(false);
        es.SetSelectedGameObject(howToFocus);
    }

    public void BackToMain()
    {
        howToMenu.SetActive(false);
        chapterMenu.SetActive(false);
        pauseMenu.SetActive(false);
        mainMenu.SetActive(true);
        es.SetSelectedGameObject(mainFocus);
    }

    public void UseMouse()
    {
        useMouse = true;
        howToMenu.SetActive(false);
        mainMenu.SetActive(true);
        es.SetSelectedGameObject(mainFocus);
    }

    public void UseController()
    {
        useMouse = false;
        howToMenu.SetActive(false);
        mainMenu.SetActive(true);
        es.SetSelectedGameObject(mainFocus);
    }

    public void QuitGame()
    {
        if (gameStarted)
        {
            SceneManager.UnloadSceneAsync("SampleScene");
            Time.timeScale = 1f;
            gameStarted = false;
            gamePaused = false;
            pauseMenu.SetActive(false);
            mainMenu.SetActive(true);
            es.SetSelectedGameObject(mainFocus);
        }
        else Application.Quit();
    }
}
