using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Controller : MonoBehaviour  //�̵� ȸ�� ����
{
    [SerializeField]private Monster_Status Datas;
    public float moveDistanse;

    public float Attack()
    {
        return Datas.attack;
    }

}
