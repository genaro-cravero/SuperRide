
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Transform playerTransform;
    [SerializeField] private Vector2 limitValueX, limitValueY;
    private Vector2 _touchStartPos, _touchEndPos;
    [SerializeField]private Vector2 _hardnessToMove = new Vector2(0.25f,0.25f);
    bool moved;

    void Start()
    {
        playerTransform = transform.GetChild(0).GetComponent<Transform>();
    }
    void Update()
    {
        //! ESTA MAL PENSADO EL MOVIMIENTO, AHORA ES COMO UN JOYSTICK,
        //! DEBERÍA CALCULAR CUANDO TERMINA DE MOVERSE EN UNA DIRECCIÓN Y CUANDO EMPIEZA A HACERLO EN LA OTRA

        // Si se está tocando la pantalla
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                _touchStartPos = _touchEndPos = Input.GetTouch(0).position;
            }
            else if(Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                _touchStartPos = _touchEndPos = Vector2.zero;
            }
            if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                MovePlayer();
                moved = true;
            }
            if(Input.GetTouch(0).phase == TouchPhase.Stationary && moved)
            {
                //! Ojo aca podriamos detectar cuando cambia de direccion
                Debug.Log("Stationary");
            }
            if(Input.GetTouch(0).phase == TouchPhase.Canceled || Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                Debug.Log("Canceled");
                moved = false;
            }
        }


    }

    void MovePlayer()
    {
        _touchEndPos = Input.GetTouch(0).position;
        float zPos = (_touchEndPos.x - _touchStartPos.x) / (Screen.width * _hardnessToMove.x);
        float yPos = (_touchEndPos.y - _touchStartPos.y) / (Screen.height * _hardnessToMove.y);
        // Debug.Log(yPos);

        // Normalizar los valores para que estén entre -1 y 1
        zPos = Mathf.Clamp(zPos, -1f, 1f);
        yPos = Mathf.Clamp(yPos, -1f, 1f);

        float finalZPos = Mathf.Clamp(zPos + playerTransform.localPosition.z , limitValueX.x, limitValueX.y);
        float finalYPos = Mathf.Clamp(yPos + playerTransform.localPosition.y, limitValueY.x, limitValueY.y);

        playerTransform.localPosition = new Vector3(0, finalYPos, finalZPos);
    }
}
