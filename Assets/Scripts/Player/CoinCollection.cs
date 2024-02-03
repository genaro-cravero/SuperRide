using System.Collections;
using TMPro;
using UnityEngine;

public class CoinCollection : MonoBehaviour
{
    
    private int _coin = 0;
    [SerializeField] private TextMeshProUGUI _coinText;
    private CameraHolder _cameraHolder;

    private void Start() {
        _cameraHolder = FindObjectOfType<CameraHolder>();
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
            _cameraHolder.SwitchCamera(_cameraHolder._virtualCameras[1]);
            other.GetComponent<SuperPower>().StartPower();
            Destroy(other.gameObject);
        }
    }
    

}
