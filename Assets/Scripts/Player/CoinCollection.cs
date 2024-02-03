using System.Collections;
using TMPro;
using UnityEngine;

public class CoinCollection : MonoBehaviour
{
    
    private int _coin = 0;
    [SerializeField] private TextMeshProUGUI _coinText;

    private void Start() {
    }

    private void OnTriggerEnter(Collider other)
    {
        //Coin Collection
        if(other.CompareTag("Coin"))
        {
            _coin++;
            _coinText.text = "Coin: " + _coin.ToString();
            Destroy(other.gameObject);
            return;
        }

        //Super Power Collection
        if(other.CompareTag("SuperPower"))
        {
            GameManager.IsSuperPowered = true;
            other.GetComponentInParent<SuperPower>().StartPower();
            Destroy(other.gameObject);
        }
    }
    

}
