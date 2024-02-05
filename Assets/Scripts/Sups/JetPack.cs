using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetPack : SuperPower
{
    [SerializeField, Range(0.1f,30)] private float _maxHeight = 7f;
    [SerializeField, Range(5f,100)] private float _flyForce = 35f;
    [SerializeField, Range(0.1f, 25f)] private float _gravityScale = 2f;

    private void Update() {
        if(!_isPowerActive) return;
        
        if (Input.touchCount > 0 )
        {
            Fly();
        }else if(Input.touchCount <= 0 && _player.transform.position.y >= _maxHeight)
        {
            _rb.velocity = new Vector3(_rb.velocity.x, 0, _rb.velocity.z);
            _rb.AddForce(GameManager.GlobalGravity * _gravityScale * Vector3.up, ForceMode.Force);
            return;
        }

    }
    private void FixedUpdate ()
    {
        if(!_isPowerActive) return;

        // Apply gravity
        Vector3 _gravity = GameManager.GlobalGravity * _gravityScale * Vector3.up;
        _rb.AddForce(_gravity, ForceMode.Acceleration);
    }

    public override void StartPower()
    {
        base.StartPower();
        StartCoroutine(PowerDuration());
    }

    public override void EndPower()
    {
        base.EndPower();
        _player.GetComponent<Animator>().SetBool("JetPack", false);

    }

    IEnumerator PowerDuration()
    {
        yield return new WaitForSeconds(duration);
        EndPower();
    }

    void Fly()
    {
        if(_player.transform.position.y > _maxHeight)
        {
            _rb.velocity = new Vector3(_rb.velocity.x, 0, _rb.velocity.z);
            return;
        } 
            
        
        // Add force to jet
        _rb.AddForce(Vector3.up * _flyForce, ForceMode.Acceleration);

        //Play jet animation
        _player.GetComponent<Animator>().SetBool("JetPack", true);

    }

}
