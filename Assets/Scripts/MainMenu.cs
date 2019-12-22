using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Animator _animatorAuthorsPanel;

    public void PlayButtonClickHandler(string level)
    {
        SceneManager.LoadScene(level);
    }
    public void AuthorsPanelSetButtonClickHandler()
    {
        _animatorAuthorsPanel.SetBool("isAuthorsPanelDisplayed", true);
    }

    public void AuthorsPanelResetButtonClickHandler()
    {
        _animatorAuthorsPanel.SetBool("isAuthorsPanelDisplayed", false);
    }
    public void ExitButtonClickHandler()
    {
        Application.Quit();
    }
}
