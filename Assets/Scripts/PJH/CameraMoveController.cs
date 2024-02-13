using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMoveController : MonoBehaviour
{
    public float speed = 30.0f;
    public float zoomSpeed = 10.0f;
    private Vector2 _curMoveInput;
    [SerializeField] private Camera _camera;

    private void Update()
    {
        Move();
        Zoom();
    }

    private void Move()
    {
        Vector3 movement = new Vector3(-_curMoveInput.y, 0, _curMoveInput.x);
        transform.Translate(movement * speed * Time.deltaTime, Space.World);
    }

    private void Zoom()
    {
        float scrollData = Mouse.current.scroll.ReadValue().y;
        if (scrollData < 0)  // ÁÜ¾Æ¿ô
        {
            float maxOrthographicSize = _camera.orthographicSize - scrollData * zoomSpeed * Time.deltaTime;
            if (maxOrthographicSize <= 130.0f)
                _camera.orthographicSize = maxOrthographicSize;
            else _camera.orthographicSize = 130.0f;
        }
        else if (scrollData > 0)  // ÁÜÀÎ
        {
            float minOrthographicSize = _camera.orthographicSize - scrollData * zoomSpeed * Time.deltaTime;
            if (minOrthographicSize >= 20.0f)
                _camera.orthographicSize = minOrthographicSize;
            else _camera.orthographicSize = 20.0f;
        }
    }

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
            _curMoveInput = context.ReadValue<Vector2>();
        else if (context.phase == InputActionPhase.Canceled)
            _curMoveInput = Vector2.zero;
    }
}
