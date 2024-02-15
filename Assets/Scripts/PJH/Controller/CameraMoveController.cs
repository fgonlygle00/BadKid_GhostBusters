using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMoveController : MonoBehaviour
{
    public float speed = 100.0f;
    public float zoomSpeed = 10.0f;
    private Vector2 _curMoveInput;
    [SerializeField] private Camera _camera;

    private float minZoom = 20f;
    private float maxZoom = 180f;
    private Vector2 _zoomMinX, _zoomMaxX;
    private Vector2 _zoomMinZ, _zoomMaxZ;

    private void Start()
    {
        _zoomMinX = new Vector2(180.0f, 630.0f); // ���� �ּ��� ���� x ����
        _zoomMaxX = new Vector2(400.0f, 400.0f); // ���� �ִ��� ���� x ����
        _zoomMinZ = new Vector2(-50.0f, 350.0f); // ���� �ּ��� ���� z ����
        _zoomMaxZ = new Vector2(150.0f, 150.0f); // ���� �ִ��� ���� z ����
    }

    private void Update()
    {
        Move();
        Zoom();
    }

    private void Move()
    {
        float zoomLevel = (_camera.orthographicSize - minZoom) / (maxZoom - minZoom); // �� ������ 0�� 1 ������ ������ ����մϴ�.

        Vector2 zoomInPosX = Vector2.Lerp(_zoomMinX, _zoomMaxX, zoomLevel);
        Vector2 zoomInPosZ = Vector2.Lerp(_zoomMinZ, _zoomMaxZ, zoomLevel);

        // ���� ī�޶� �̵���ŵ�ϴ�.
        Vector3 movement = new Vector3(-_curMoveInput.y, 0, _curMoveInput.x);
        transform.Translate(movement * speed * Time.deltaTime, Space.World);

        // �̵� �Ŀ� ī�޶� ��ġ�� ������ ������ ������� Ȯ���մϴ�.
        Vector3 currentPosition = _camera.transform.position;
        float clampedX = Mathf.Clamp(currentPosition.x, zoomInPosX.x, zoomInPosX.y);
        float clampedZ = Mathf.Clamp(currentPosition.z, zoomInPosZ.x, zoomInPosZ.y);

        // ������ ����ٸ� ��ġ�� �����մϴ�.
        if (currentPosition.x != clampedX || currentPosition.z != clampedZ)
        {
            _camera.transform.position = new Vector3(clampedX, currentPosition.y, clampedZ);
        }
    }

    private void Zoom()
    {
        float scrollData = Mouse.current.scroll.ReadValue().y;
        if (scrollData < 0)  // �ܾƿ�
        {
            float maxOrthographicSize = _camera.orthographicSize - scrollData * zoomSpeed * Time.deltaTime;
            if (maxOrthographicSize <= 180.0f)
                _camera.orthographicSize = maxOrthographicSize;
            else _camera.orthographicSize = 180.0f;
        }
        else if (scrollData > 0)  // ����
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
