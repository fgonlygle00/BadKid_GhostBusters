using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Bullet_Prototype : MonoBehaviour
{
    public float bulletSpeed;
    public float bulletDamage; // Ÿ�� ���ݷ¿� ����ϴ� ��
    public float bulletWeight;
    public Monster_Controller targetMonster = null;

    public virtual void SetAttackDamage(float damage)
    {
        bulletDamage = damage;
    }

    public virtual void SetTargetMonster(Monster_Controller target)
    {
        targetMonster = target;
    }

    public virtual void Upgraded()
    {

    }

    private void Update()
    {
        if (targetMonster != null)
        {
            Vector3 direction = (targetMonster.transform.position - transform.position).normalized;

            transform.Translate(direction * bulletSpeed * Time.deltaTime, Space.World);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Monster")) // �浹ü�� ���� �±��� ���
        {
            Monster_Controller monsterStatus = other.GetComponent<Monster_Controller>(); // �ش� ������ �������ͽ��� ����
            if (monsterStatus != null)
            {
                monsterStatus.Hit(bulletDamage);
            }

            Destroy(gameObject);
        }
    }
}
