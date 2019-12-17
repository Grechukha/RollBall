using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Animator _animatorAuthorsPanel;

    public void Play(string level)
    {
        SceneManager.LoadScene(level);
    }
    public void AuthorsPanelSet()
    {
        _animatorAuthorsPanel.SetBool("isAuthorsPanelDisplayed", true);
    }

    public void AuthorsPanelReset()
    {
        _animatorAuthorsPanel.SetBool("isAuthorsPanelDisplayed", false);
    }
    public void Exid()
    {
        Application.Quit();
    }
}
