using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColliders : MonoBehaviour
{
    [SerializeField] private Vector3 feetPosition;


    ////Check if the player is grounded
    public bool IsGrounded()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position + feetPosition, 0.1f, LayerMask.GetMask("Ground"));
        bool isGrounded = colliders.Length > 0;
        GetComponent<Animator>().SetBool("IsGrounded", isGrounded);
        return isGrounded;
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + feetPosition, 0.1f);
    }
}
