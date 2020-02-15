using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Animator _animatorAuthorsPanel;

    public void OnPlayButtonClick(string level)
    {
        SceneManager.LoadScene(level);
    }
    public void OnAuthorsPanelSetButtonClick()
    {
        _animatorAuthorsPanel.SetBool("isAuthorsPanelDisplayed", true);
    }

    public void OnAuthorsPanelResetButtonClick()
    {
        _animatorAuthorsPanel.SetBool("isAuthorsPanelDisplayed", false);
    }
    public void OnExitButtonClick()
    {
        Application.Quit();
    }
}
