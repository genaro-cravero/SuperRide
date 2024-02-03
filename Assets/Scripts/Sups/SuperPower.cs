using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperPower : MonoBehaviour
{
    // Start is called before the first frame update
    protected string _name;
    protected float _duration;
    protected GameObject _player;
    public virtual void StartPower()
    {
        _player.GetComponent<BoxCollider>().size = new Vector3(2, 0.7045513f, 0.4281334f);
    }
    public virtual void EndPower()
    {
        _player.GetComponent<BoxCollider>().size = new Vector3(0.27f, 0.7045513f, 0.4281334f);
    }
    protected CameraHolder _cameraHolder;

    protected void Start()
    {
        _cameraHolder = FindObjectOfType<CameraHolder>();
        _player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
