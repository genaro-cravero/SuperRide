using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraHolder : MonoBehaviour
{
    private Transform _playerTransform;
    private Vector3 _initialRotation;
    [HideInInspector] public List<CinemachineVirtualCamera> _virtualCameras;

    void Start()
    {
        _playerTransform = GameObject.Find("Player").transform.parent;
        _initialRotation = transform.eulerAngles;

        foreach(Transform child in transform)
        {
            if(child.GetComponent<CinemachineVirtualCamera>())
            {
                _virtualCameras.Add(child.GetComponent<CinemachineVirtualCamera>());
            }
        }
    }
    void LateUpdate()
    {
        transform.position = new Vector3(_playerTransform.position.x, 
        _playerTransform.transform.position.y, _playerTransform.transform.position.z);

        transform.eulerAngles = new Vector3(_playerTransform.eulerAngles.x + _initialRotation.x,
         _playerTransform.eulerAngles.y + _initialRotation.y - 90, _initialRotation.z);

    }

    public void SwitchCamera(CinemachineVirtualCamera _cam)
    {
        CinemachineVirtualCamera[] _vcams = FindObjectsOfType(typeof(CinemachineVirtualCamera), true) as CinemachineVirtualCamera[];
        foreach (CinemachineVirtualCamera vcam in _vcams)
        {
            if (vcam == _cam)
            {
                vcam.Priority = 10;
                continue;
            }
            vcam.Priority = 0;
        }
    }   
}
