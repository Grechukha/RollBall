using TMPro;
using UnityEngine;

public class CoinsHolder : MonoBehaviour
{
    [SerializeField] private TMP_Text _countOfCoinsText;

    private int _countOfCoins;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Coin>())
        {
            _countOfCoins++;
            _countOfCoinsText.text = _countOfCoins.ToString();

            Destroy(collision.gameObject);
        }
    }
}
