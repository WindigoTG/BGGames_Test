using UnityEngine;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class Menu : MonoBehaviour
{
    #region Fields

    [SerializeField] private Button _pauseButton;
    [SerializeField] private Button _resumeButton;
    [SerializeField] private Button _quitButton;
    [SerializeField] private GameObject _menuPopUp;

    #endregion


    #region UnityMethods

    void Start()
    {
        _pauseButton.onClick.AddListener(OnPauseClick);
        _resumeButton.onClick.AddListener(OnResumeClick);
        _quitButton.onClick.AddListener(OnQuitClick);
    }

    private void OnDestroy()
    {
        _pauseButton.onClick.RemoveAllListeners();
        _resumeButton.onClick.RemoveAllListeners();
        _quitButton.onClick.RemoveAllListeners();
    }

    #endregion


    #region Methods

    private void OnPauseClick()
    {
        Time.timeScale = 0;
        _menuPopUp.SetActive(true);
    }

    private void OnResumeClick()
    {
        Time.timeScale = 1;
        _menuPopUp.SetActive(false);
    }

    private void OnQuitClick()
    {
        #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
        #else
            Application.Quit();
        #endif
    }

    #endregion
}
