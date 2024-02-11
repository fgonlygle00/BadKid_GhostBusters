using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Controller : MonoBehaviour  //이동 회전 로직
{
    [SerializeField]private Monster_Status Datas;
    public float moveDistanse;

    public float Attack()
    {
        return Datas.attack;
    }

}
