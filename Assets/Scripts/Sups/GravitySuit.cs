using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitySuit : SuperPower
{
    [SerializeField, Range(0.1f, 30)] private float _maxHeight = 7f;
    [SerializeField, Range(0.1f, 25f)] private float _gravityScale = 2.50f;
    [SerializeField, Range(2f, 255f)] private float _rotationSpeed = 12f;
    private int _direction = 1;
    private bool _isUp;
    [HideInInspector] public bool isUp
    {
        get { return _isUp; }
        set
        {
            _isUp = value;
            _direction = isUp ? -1 : 1;
        }
    }
    private bool _canTouch = true;
    

    private void Update()
    {
        if (!_isPowerActive) return;
        base.Execute();
        
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && _canTouch)
        {
            StartCoroutine(ChangeVertical());
        }
        // else if (Input.touchCount <= 0 && _player.transform.position.y >= _maxHeight)
        // {
        //     _rb.velocity = new Vector3(_rb.velocity.x, 0, _rb.velocity.z);
        //     _rb.AddForce(GameManager.GlobalGravity * _gravityScale * Vector3.up, ForceMode.Force);
        //     return;
        // }

    }
    private void FixedUpdate()
    {
        if (!_isPowerActive) return;

        // Apply gravity
        if(_player.transform.position.y > _maxHeight && isUp)
        {
            _rb.velocity = new Vector3(_rb.velocity.x, 0, _rb.velocity.z);
            return;
        }else if(_player.GetComponent<PlayerColliders>().IsGrounded() && !isUp)
        {
            _rb.velocity = new Vector3(_rb.velocity.x, 0, _rb.velocity.z);
            return;
        }
        Vector3 _gravity = GameManager.GlobalGravity * _gravityScale * Vector3.up * _direction;
        _rb.AddForce(_gravity, ForceMode.Acceleration);
    }


    private IEnumerator ChangeVertical()
    {
        //! Tengo que hacer que me permita girar cada vez que toco instantaneamente
        //! Pero ahora si hago eso queda en horizontal y no puedo volver a la normalidad
        _canTouch = false;

        //Slowly otate player 180 degrees on x

        float _targetRotationX = isUp ? 0 : 180;
        float _targetRotationY = isUp ? -90 : 90;
        Quaternion _targetRotation = Quaternion.Euler(_targetRotationX, _player.transform.rotation.y + _targetRotationX , 0);
        isUp = !isUp;

        _rb.velocity = new Vector3(_rb.velocity.x, 0, _rb.velocity.z);
        while (Quaternion.Angle(_player.transform.rotation, _targetRotation) > 1f)
        {
            Debug.Log(Quaternion.Angle(_player.transform.rotation, _targetRotation)) ;
            _player.transform.rotation = Quaternion.Slerp(_player.transform.rotation, _targetRotation, _rotationSpeed * Time.deltaTime);
            yield return null;
        }

        _player.transform.rotation = _targetRotation;
        _canTouch = true;
        yield return null;

    }

}
