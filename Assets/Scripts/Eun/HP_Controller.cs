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
        // HP �̹����� �׻� ���� ī�޶��� ������ ���ϵ��� ����
        transform.LookAt(transform.position + mainCamera.transform.rotation * Vector3.forward,
                         mainCamera.transform.rotation * Vector3.up); //�ణ �򰥸��ϱ� ���� ���� �ٽ� �����ϱ�
    }
}
