using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperPower : MonoBehaviour
{
    // Start is called before the first frame update
    public float duration = 5f;
    protected GameObject _player;
    protected CameraHolder _cameraHolder;
    protected Rigidbody _rb;
    protected bool _isPowerActive = false;
    protected void Start()
    {
        _cameraHolder = FindObjectOfType<CameraHolder>();
        _player = GameObject.Find("Player");
        _rb = _player.GetComponent<Rigidbody>();
        StartCoroutine(PowerDuration());

    }
    public virtual void StartPower()
    {
        _isPowerActive = true;
        _cameraHolder.SwitchCamera(_cameraHolder._virtualCameras[1]);
        _player.GetComponent<BoxCollider>().size = new Vector3(2, 0.7045513f, 0.4281334f);
        _player.GetComponent<PlayerMovement>().enabled = false;
        StartCoroutine(WaitUntilCameraBlends());
    }
    protected virtual void Execute()
    {
        _player.GetComponent<PlayerColliders>().IsGrounded();
    }
    public virtual void EndPower()
    {
        _isPowerActive = false;
        _cameraHolder.SwitchCamera(_cameraHolder._virtualCameras[0]);
        _player.GetComponent<BoxCollider>().size = new Vector3(0.27f, 0.7045513f, 0.4281334f);
        Camera.main.orthographic = false;
        _player.GetComponent<PlayerMovement>().enabled = true;
        
    }

    private IEnumerator WaitUntilCameraBlends()
    {
        yield return new WaitForSeconds(0.7f);
        Camera.main.orthographic = true;
    }

    protected IEnumerator PowerDuration()
    {
        yield return new WaitForSeconds(duration);
        EndPower();
    }

}
