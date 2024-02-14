using System;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Range_Enhance_Tower : Tower_Prototype
{

    // 추가 속성
    // public int level;
    // public float upgradeCost;
    // public float upgradedAttackDamage;
    // public float upgradedAttackRate;
    // public float upgradedSkillCastRate;

    private bool[] Buff_Target_Arr = new bool[18];
    public bool buffOn;

    private void Start()
    {
        InvokeRepeating("BasicAttack", 0f, baseAttackRate); //기본 공격 주기적으로 
        InvokeRepeating("Buff_Target_Selection", 0f, skillCastRate); //스킬 주기적으로
    }

    void Buff_Target_Selection()
    {
        if (arr_Index == 0)
        {
            UseBuff(1);
            UseBuff(4);
            UseBuff(5);
        }
        else if (arr_Index == 1)
        {
            UseBuff(0);
            UseBuff(2);
            UseBuff(4);
            UseBuff(5);
            UseBuff(6);
        }
        else if (arr_Index == 2)
        {
            UseBuff(1);
            UseBuff(3);
            UseBuff(5);
            UseBuff(6);
            UseBuff(7);
        }
        else if (arr_Index == 3)
        {
            UseBuff(2);
            UseBuff(6);
            UseBuff(7);
        }
        else if (arr_Index == 4)
        {
            UseBuff(0);
            UseBuff(1);
            UseBuff(5);
        }
        else if (arr_Index == 5)
        {
            UseBuff(0);
            UseBuff(1);
            UseBuff(2);
            UseBuff(4);
            UseBuff(6);
        }
        else if (arr_Index == 6)
        {
            UseBuff(1);
            UseBuff(2);
            UseBuff(3);
            UseBuff(5);
            UseBuff(7);
        }
        else if (arr_Index == 7)
        {
            UseBuff(2);
            UseBuff(3);
            UseBuff(6);
        }
        else if (arr_Index == 8)
        {
            UseBuff(9);
            UseBuff(10);
            UseBuff(11);
        }
        else if (arr_Index == 9)
        {
            UseBuff(8);
            UseBuff(10);
            UseBuff(11);
        }
        else if (arr_Index == 10)
        {
            UseBuff(8);
            UseBuff(9);
            UseBuff(11);
            UseBuff(12);
            UseBuff(13);
        }
        else if (arr_Index == 11)
        {
            UseBuff(8);
            UseBuff(9);
            UseBuff(10);
            UseBuff(12);
            UseBuff(13);
        }
        else if (arr_Index == 12)
        {
            UseBuff(10);
            UseBuff(11);
            UseBuff(13);
        }
        else if (arr_Index == 13)
        {
            UseBuff(10);
            UseBuff(11);
            UseBuff(12);
        }
        else if (arr_Index == 14)
        {
            UseBuff(15);
        }
        else if (arr_Index == 15)
        {
            UseBuff(14);
            UseBuff(16);
            UseBuff(17);
        }
        else if (arr_Index == 16)
        {
            UseBuff(15);
            UseBuff(17);
        }
        else if (arr_Index == 17)
        {
            UseBuff(15);
            UseBuff(16);
        }
        // 나머지 노드들에 대한 처리 추가 가능
    }


    void UseBuff(int i)
    {
       if (Tower_Manager.Instance.Tower_Coordinate_Arr[i] != null)
        {
            GameObject towerInstance = Tower_Manager.Instance.Tower_Coordinate_Arr[i];
            Tower_Prototype tower_script = towerInstance.GetComponent<Tower_Prototype>();
            if (Buff_Target_Arr[i] == false)
            {
                tower_script.Buffed(buffValue);
                Buff_Target_Arr[i] = true;
                return;
            }
            else
            {
                tower_script.BuffCanceled(buffValue);
                Buff_Target_Arr[i] = false;
            }

        }
        else
        {
            Buff_Target_Arr[i] = false;
        }
    }

    public void BuffCancel(int i)
    {
        if (Buff_Target_Arr[i] == true)
        { 
            if (Tower_Manager.Instance.Tower_Coordinate_Arr[i] != null)
            {
                GameObject towerInstance = Tower_Manager.Instance.Tower_Coordinate_Arr[i];
                Tower_Prototype tower_script = towerInstance.GetComponent<Tower_Prototype>();
                tower_script.BuffCanceled(buffValue);
                Buff_Target_Arr[i] = false;
            }
            else
            {
                Buff_Target_Arr[i] = false;
            }
        }
    }

    public void External_Delete_Reroll(int i)
    {
        Buff_Target_Arr[i] = false;
    }



    // void UniqueSkillEffect()
    // {
    //     고유한 스킬 효과 로직 추가
    // }
}
