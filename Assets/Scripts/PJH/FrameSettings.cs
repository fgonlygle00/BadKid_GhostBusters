using UnityEngine;

public class FrameSettings : MonoBehaviour
{
    private void Awake()
    {
        Application.targetFrameRate = 60; // 60 ���������� ����, Vsyn �����ؾ� �����
    }
}
