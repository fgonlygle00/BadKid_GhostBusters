using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Gun_Tower : Tower_Prototype
{

    public override void BasicAttack() //�⺻����
    {
        Monster_Controller targetMonster = MonsterTargeting(); //Ÿ�� ���͸� ���Ϲ޴´�

        if (targetMonster != null)
        {
            Vector3 direction = targetMonster.transform.position - transform.position;
            direction.y = 0f;
            transform.rotation = Quaternion.LookRotation(direction);

            Vector3 currentPosition = transform.position;
            currentPosition.y += 5f;

            GameObject bullet = Instantiate(bulletPrefab, currentPosition, Quaternion.identity); //�Ѿ� ������ �ν��Ͻ� ����

            Bullet_Prototype bulletScript = bullet.GetComponent<Bullet_Prototype>(); //�Ѿ� �ν��Ͻ��� �Ҹ� ������Ÿ�� ��ũ��Ʈ�� �����´�

            if (bulletScript != null)
            {

                bulletScript.SetAttackDamage(attackDamage); //�Ҹ��� ���ݷ��� Ÿ�� ���ݷ����� ����
                bulletScript.SetTargetMonster(targetMonster); //�Ҹ��� Ÿ���� Ÿ�� ���ͷ� ����
            }
            else
            {
            }

        if( isUpgraded == true)   //���׷��̵��, �Ѿ� 2��
            {
                Vector3 currentPosition2 = transform.position;
                currentPosition2.y += 25f;

                GameObject bullet2 = Instantiate(bulletPrefab, currentPosition2, Quaternion.identity); //�Ѿ� ������ �ν��Ͻ� ����

                Bullet_Prototype bulletScript2 = bullet2.GetComponent<Bullet_Prototype>(); //�Ѿ� �ν��Ͻ��� �Ҹ� ������Ÿ�� ��ũ��Ʈ�� �����´�

                if (bulletScript2 != null)
                {

                    bulletScript2.SetAttackDamage(attackDamage * upgrade_Factor); //�Ҹ��� ���ݷ��� Ÿ�� ���ݷ����� ����
                    bulletScript2.SetTargetMonster(targetMonster); //�Ҹ��� Ÿ���� Ÿ�� ���ͷ� ����
                }
                else
                {
                }
            }
        }
    }

}
