using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Gun_Tower : Tower_Prototype
{
    public override void Upgrade()  //업그레이드 메서드 // 권총 타워는 공속이 0.3초당 1발 → 0.2초당 1발
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
            //여기에 업그레이드가 불가능할 시 작동을 입력하세요
        }
    }
}
