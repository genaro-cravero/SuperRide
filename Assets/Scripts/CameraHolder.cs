using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHolder : MonoBehaviour
{
    private Transform _playerTransform;
    private Vector3 _initialRotation;

    void Start()
    {
        _playerTransform = GameObject.Find("Player").transform.parent;
        _initialRotation = transform.eulerAngles;
    }
    void LateUpdate()
    {
        transform.position = new Vector3(_playerTransform.position.x, 
        _playerTransform.transform.position.y, _playerTransform.transform.position.z);

        transform.eulerAngles = new Vector3(_playerTransform.eulerAngles.x + _initialRotation.x,
         _playerTransform.eulerAngles.y + _initialRotation.y - 90, _initialRotation.z);

    }
}
