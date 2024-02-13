using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Bullet_Prototype : MonoBehaviour
{
    public float bulletSpeed = 1f;
    public float bulletDamage; // Ÿ�� ���ݷ¿� ����ϴ� ��
    public float bulletWeight;
    public Monster_Controller targetMonster = null;

    public void SetAttackDamage(float damage)
    {
        bulletDamage = damage;
    }

    // Set the target monster for the bullet
    public void SetTargetMonster(Monster_Controller target)
    {
        targetMonster = target;
    }

    private void Update()
    {
        if (targetMonster != null)
        {
            Vector3 direction = (targetMonster.transform.position - transform.position).normalized;

            transform.Translate(direction * bulletSpeed * Time.deltaTime, Space.World);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("��ü�� �浹�߽��ϴ�.");
        if (other.CompareTag("Monster")) // �浹ü�� ���� �±��� ���
        {
            Debug.Log("���Ϳ� �浹�� �� Ȯ���߽��ϴ�.");
            Monster_Controller monsterStatus = other.GetComponent<Monster_Controller>(); // �ش� ������ �������ͽ��� ����
            if (monsterStatus != null)
            {
                monsterStatus.Hit(bulletDamage);
            }

            Debug.Log("�� ������!");
            Destroy(gameObject);
        }
    }
}
