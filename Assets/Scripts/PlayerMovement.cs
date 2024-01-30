
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Transform playerTransform;
    [SerializeField] private Vector2 limitValueX;
    private Vector2 _touchStartPos, _touchEndPos, _auxPos;
    [SerializeField] private Vector2 _hardnessToMove = new Vector2(0.25f, 0.25f);
    private bool moved;
    private float _timeToStationary = 0.05f, _currentTimeToStationary = 0f;

    void Start()
    {
        playerTransform = transform.GetChild(0).GetComponent<Transform>();
    }
    void Update()
    {

        // If touching the screen
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                //?Start Touch
                _touchStartPos = _touchEndPos = Input.GetTouch(0).position;
            }
            else if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                //?End Touch
                _touchEndPos = Vector2.zero;
                moved = false;
                _currentTimeToStationary = 0f;

            }
            if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                //?Move Touch
                if (_currentTimeToStationary >= _timeToStationary)
                {
                    //If goes in the opposite direction reset the start pos
                    if (_auxPos.x - _touchStartPos.x < 0 && Input.GetTouch(0).position.x - _auxPos.x > 0)
                        _touchStartPos = _touchEndPos = Input.GetTouch(0).position;
                    else if (_auxPos.x - _touchStartPos.x > 0 && Input.GetTouch(0).position.x - _auxPos.x < 0)
                        _touchStartPos = _touchEndPos = Input.GetTouch(0).position;

                    _currentTimeToStationary = 0f;

                }
                MovePlayer();
                moved = true;
                _currentTimeToStationary = 0f;
            }
            if (Input.GetTouch(0).phase == TouchPhase.Stationary && moved)
            {
                //?Touch Stay in the same position
                _currentTimeToStationary += Time.deltaTime;
                _auxPos = Input.GetTouch(0).position;
            }
            if (Input.GetTouch(0).phase == TouchPhase.Canceled || Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                //?Touch Cancelled
                _currentTimeToStationary = 0f;
                moved = false;
            }
        }


    }

    void MovePlayer()
    {
        _touchEndPos = Input.GetTouch(0).position;
        float zPos = (_touchEndPos.x - _touchStartPos.x) / (Screen.width * _hardnessToMove.x);

        // Clamp the values between -1 y 1
        zPos = Mathf.Clamp(zPos, -1f, 1f);

        float finalZPos = Mathf.Clamp(zPos + playerTransform.localPosition.z, limitValueX.x, limitValueX.y);

        playerTransform.localPosition = new Vector3(0, 0, finalZPos);
    }
}
