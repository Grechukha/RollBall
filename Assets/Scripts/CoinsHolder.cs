using TMPro;
using UnityEngine;

public class CoinsHolder : MonoBehaviour
{
    [SerializeField] private TMP_Text _coinsText;

    private int _coins;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Coin>())
        {
            _coins++;
            _coinsText.text = _coins.ToString();

            Destroy(collision.gameObject);
        }
    }
}
