using UnityEngine;

public class FrameSettings : MonoBehaviour
{
    private void Awake()
    {
        Time.timeScale = 1.0f;
        Application.targetFrameRate = 60; // 60 ���������� ����, Vsyn �����ؾ� �����
    }
}
