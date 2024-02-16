using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP_Controller : MonoBehaviour
{
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void LateUpdate()
    {
        // HP 이미지를 항상 메인 카메라의 방향을 향하도록 설정
        transform.LookAt(transform.position + mainCamera.transform.rotation * Vector3.forward,
                         mainCamera.transform.rotation * Vector3.up); //약간 헷갈리니까 백터 곱셈 다시 공부하기
    }
}
