using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private Button newGameButton;
    [SerializeField] private Button quitButton;

    private void Start()
    {
        // Bind button events
        newGameButton.onClick.AddListener(OnNewGameClicked);
        quitButton.onClick.AddListener(OnQuitClicked);
    }

    private void OnNewGameClicked()
    {
        Debug.Log("New Game Started!");
        // Load the main game scene
        SceneManager.LoadScene("GameScene");
    }

    private void OnQuitClicked()
    {
        Debug.Log("Game Quit");
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}