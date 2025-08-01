using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject chapterMenu;
    [SerializeField] GameObject howToMenu;
    [SerializeField] GameObject mainFocus;
    [SerializeField] GameObject chapterFocus;
    [SerializeField] GameObject howToFocus;

    private EventSystem es;

    void Start()
    {
        es = FindFirstObjectByType<EventSystem>();
        es.SetSelectedGameObject(mainFocus);
    }

    void Update()
    {
        if (Input.GetButtonDown("Cancel")) BackToMain();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("SampleScene");
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
        es.SetSelectedGameObject(howToFocus);
    }

    public void BackToMain()
    {
        howToMenu.SetActive(false);
        chapterMenu.SetActive(false);
        mainMenu.SetActive(true);
        es.SetSelectedGameObject(mainFocus);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
