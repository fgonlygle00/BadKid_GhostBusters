using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invasion_Controller : MonoBehaviour  //�浹ü ���� ����
{
    public int Health;

    void Start()
    {
        
    }

    void Update()
    {
        
    }


    public void FinalCheckpoint()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        //�±� ������ ���  
        //���� ��ũ��Ʈ�� ���� Attack (���ݷ�)�� �����ͼ� HP�� �׸�ŭ �����ſ���
        //if (other.CompareTag == CompareTag("Enemy"))
        //{

        //}

        if(Health<=0)
        {
            //FinalCheckpoint();
            //�������� ��ũ��Ʈ�� �ۺ��̶�� �� ���� ȣ��(����ȯ �Լ�����) �� ���⼭ �θ���ʹ�
        }
    }
}
