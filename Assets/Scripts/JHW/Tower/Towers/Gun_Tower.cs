using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Gun_Tower : Tower_Prototype
{
    public override void Upgrade()  //���׷��̵� �޼��� // ���� Ÿ���� ������ 0.3�ʴ� 1�� �� 0.2�ʴ� 1��
    {
        if (isUpgraded == false)
        {
            isUpgraded = true;
            Defalt_attackDamage *= upgrade_Factor;
            baseAttackRate = 0.2f;
            CancelInvoke("BasicAttack");
            InvokeRepeating("BasicAttack", 0f, baseAttackRate);
        }
        else
        {
            //���⿡ ���׷��̵尡 �Ұ����� �� �۵��� �Է��ϼ���
        }
    }
}
