using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Bomb : MonoBehaviour
{
    public int[] bombIndex;



    void Start()
    {
        
    }

    public void BombPrefeb()
    {
        GameObject Cheak = Tower_Manager.Instance.Tower_Disposition_Arr[Random.Range(0, Tower_Manager.Instance.Tower_Disposition_Arr.Length)];

        if (true) 
        {
            // ���⿡ ���� ������Ʈ�� �����Ͱ� ������ ������ ����? �޼ҵ�
        }

        Destroy(Tower_Manager.Instance.Tower_Disposition_Arr[Random.Range(0, Tower_Manager.Instance.Tower_Disposition_Arr.Length)]);
        
    }
}
