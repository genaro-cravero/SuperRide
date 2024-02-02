using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinCollection : MonoBehaviour
{
    
    private int _coin = 0;
    [SerializeField] private TextMeshProUGUI _coinText;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Coin"))
        {
            _coin++;
            _coinText.text = "Coin: " + _coin.ToString();
            Destroy(other.gameObject);
        }
    }
}
