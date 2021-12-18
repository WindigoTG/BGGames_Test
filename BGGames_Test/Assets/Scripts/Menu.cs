using UnityEngine;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class Menu : MonoBehaviour
{
    [SerializeField] private Button _pauseButton;
    [SerializeField] private Button _resumeButton;
    [SerializeField] private Button _quitButton;
    [SerializeField] private GameObject _menuPopUp;
    
    void Start()
    {
        _pauseButton.onClick.AddListener(OnPause);
        _resumeButton.onClick.AddListener(OnResume);
        _quitButton.onClick.AddListener(OnQuit);
    }

    private void OnPause()
    {
        Time.timeScale = 0;
        _menuPopUp.SetActive(true);
    }

    private void OnResume()
    {
        Time.timeScale = 1;
        _menuPopUp.SetActive(false);
    }

    private void OnQuit()
    {
        #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
        #else
            Application.Quit();
        #endif
    }
}
