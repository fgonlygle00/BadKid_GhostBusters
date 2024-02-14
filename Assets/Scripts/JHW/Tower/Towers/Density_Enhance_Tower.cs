using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Density_Enhance_Tower : Tower_Prototype
{

    // 추가 속성
    // public int level;
    // public float upgradeCost;
    // public float upgradedAttackDamage;
    // public float upgradedAttackRate;
    // public float upgradedSkillCastRate;

    public bool buffOn;

    private void Start()
    {
        InvokeRepeating("BasicAttack", 0f, baseAttackRate); //기본 공격 주기적으로 
        InvokeRepeating("Buff_Target_Selection", 0f, skillCastRate); //스킬 주기적으로
    }

    void Buff_Target_Selection()
    {
        if (buffOn == false)
        {
            buffOn = true;
            Ex_UseBuff();
        }
        else
        {
            Ex_BuffCancel();
        }
        // 나머지 노드들에 대한 처리 추가 가능
    }

    void Ex_UseBuff()
    {
        if (arr_Index == 0)
        {
            UseBuff(1);
            UseBuff(4);
        }
        else if (arr_Index == 1)
        {
            UseBuff(0);
            UseBuff(2);
            UseBuff(5);
        }
        else if (arr_Index == 2)
        {
            UseBuff(1);
            UseBuff(3);
            UseBuff(6);
        }
        else if (arr_Index == 3)
        {
            UseBuff(2);
            UseBuff(7);
        }
        else if (arr_Index == 4)
        {
            UseBuff(0);
            UseBuff(5);
        }
        else if (arr_Index == 5)
        {
            UseBuff(1);
            UseBuff(4);
            UseBuff(6);
        }
        else if (arr_Index == 6)
        {
            UseBuff(2);
            UseBuff(5);
            UseBuff(7);
        }
        else if (arr_Index == 7)
        {
            UseBuff(3);
            UseBuff(6);
        }
        else if (arr_Index == 8)
        {
            UseBuff(9);
            UseBuff(10);
        }
        else if (arr_Index == 9)
        {
            UseBuff(8);
            UseBuff(11);
        }
        else if (arr_Index == 10)
        {
            UseBuff(8);
            UseBuff(11);
            UseBuff(12);
        }
        else if (arr_Index == 11)
        {
            UseBuff(9);
            UseBuff(10);
            UseBuff(13);
        }
        else if (arr_Index == 12)
        {
            UseBuff(10);
            UseBuff(13);
        }
        else if (arr_Index == 13)
        {
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
            UseBuff(17);
        }
        else if (arr_Index == 16)
        {
            UseBuff(17);
        }
        else if (arr_Index == 17)
        {
            UseBuff(15);
            UseBuff(16);
        }
    }

    public void Ex_BuffCancel()
    {
        if (buffOn == true)
        {
            buffOn = false;
            if (arr_Index == 0)
            {
                BuffCancel(1);
                BuffCancel(4);
            }
            else if (arr_Index == 1)
            {
                BuffCancel(0);
                BuffCancel(2);
                BuffCancel(5);
            }
            else if (arr_Index == 2)
            {
                BuffCancel(1);
                BuffCancel(3);
                BuffCancel(6);
            }
            else if (arr_Index == 3)
            {
                BuffCancel(2);
                BuffCancel(7);
            }
            else if (arr_Index == 4)
            {
                BuffCancel(0);
                BuffCancel(5);
            }
            else if (arr_Index == 5)
            {
                BuffCancel(1);
                BuffCancel(4);
                BuffCancel(6);
            }
            else if (arr_Index == 6)
            {
                BuffCancel(2);
                BuffCancel(5);
                BuffCancel(7);
            }
            else if (arr_Index == 7)
            {
                BuffCancel(3);
                BuffCancel(6);
            }
            else if (arr_Index == 8)
            {
                BuffCancel(9);
                BuffCancel(10);
            }
            else if (arr_Index == 9)
            {
                BuffCancel(8);
                BuffCancel(11);
            }
            else if (arr_Index == 10)
            {
                BuffCancel(8);
                BuffCancel(11);
                BuffCancel(12);
            }
            else if (arr_Index == 11)
            {
                BuffCancel(9);
                BuffCancel(10);
                BuffCancel(13);
            }
            else if (arr_Index == 12)
            {
                BuffCancel(10);
                BuffCancel(13);
            }
            else if (arr_Index == 13)
            {
                BuffCancel(11);
                BuffCancel(12);
            }
            else if (arr_Index == 14)
            {
                BuffCancel(15);
            }
            else if (arr_Index == 15)
            {
                BuffCancel(14);
                BuffCancel(17);
            }
            else if (arr_Index == 16)
            {
                BuffCancel(17);
            }
            else if (arr_Index == 17)
            {
                BuffCancel(15);
                BuffCancel(16);
            }
        }
    }


    void UseBuff(int i)
    {
        Tower_Manager.Instance.SetBuffValue(i, Tower_Manager.Instance.Buff_Value_Arr[i] + buffValue);
    }

    public void BuffCancel(int i)
    {
        Tower_Manager.Instance.SetBuffValue(i, Tower_Manager.Instance.Buff_Value_Arr[i] - buffValue);
    }




    // void UniqueSkillEffect()
    // {
    //     고유한 스킬 효과 로직 추가
    // }
}

