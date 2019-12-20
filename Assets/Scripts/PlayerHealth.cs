using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int _health = 1;

    public void TakeDamage()
    {
        _health--;

        if (_health <= 0)
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
