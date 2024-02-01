using System.Collections;
using UnityEngine;
using PathCreation.Examples;

public class ObstacleCollision : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
            other.GetComponent<PlayerMovement>().enabled = false;
            other.GetComponentInParent<PathFollower>().enabled = false;
        }
    }
        
    
}
