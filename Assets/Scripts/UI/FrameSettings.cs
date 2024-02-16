using UnityEngine;

public class FrameSettings : MonoBehaviour
{
    private void Awake()
    {
        Time.timeScale = 1.0f;
        Application.targetFrameRate = 60; // 60 프레임으로 고정, Vsyn 사용안해야 적용됨
    }
}
