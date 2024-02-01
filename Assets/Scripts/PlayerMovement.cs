
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Transform playerTransform;
    [SerializeField, Range(0.1f, 5f)] private float _limitValueX = 1.2f;
    void Start()
    {
        playerTransform = GetComponent<Transform>();
    }
    void Update()
    {

        // If touching the screen
        if (Input.touchCount > 0)
        {
    
            if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                MovePlayer();
            }
            
        }


    }

    void MovePlayer()
    {
        float halfScreen = Screen.width / 2;
        float zPos = (Input.GetTouch(0).position.x - halfScreen) / Screen.width;

        // Limit the value of the player's position
        float finalZPos = Mathf.Clamp(zPos * _limitValueX, -_limitValueX, _limitValueX);

        playerTransform.localPosition = new Vector3(0, 0, finalZPos);
    }
}
