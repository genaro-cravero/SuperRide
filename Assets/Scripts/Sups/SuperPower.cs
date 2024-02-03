using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperPower : MonoBehaviour
{
    // Start is called before the first frame update
    public float duration = 5f;
    protected GameObject _player;
    protected CameraHolder _cameraHolder;
    protected void Start()
    {
        _cameraHolder = FindObjectOfType<CameraHolder>();
        _player = GameObject.Find("Player");
    }
    public virtual void StartPower()
    {
        _cameraHolder.SwitchCamera(_cameraHolder._virtualCameras[1]);
        _player.GetComponent<BoxCollider>().size = new Vector3(2, 0.7045513f, 0.4281334f);
        StartCoroutine(WaitUntilCameraBlends());
    }
    public virtual void EndPower()
    {
        _cameraHolder.SwitchCamera(_cameraHolder._virtualCameras[0]);
        _player.GetComponent<BoxCollider>().size = new Vector3(0.27f, 0.7045513f, 0.4281334f);
        Camera.main.orthographic = false;


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator WaitUntilCameraBlends()
    {
        yield return new WaitForSeconds(0.7f);
        Camera.main.orthographic = true;
    }

}
