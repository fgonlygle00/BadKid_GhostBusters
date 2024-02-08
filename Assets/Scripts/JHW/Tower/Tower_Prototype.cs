using UnityEngine;

public class Tower_Prototype : MonoBehaviour
{
    // �⺻ �Ӽ�
    public float attackDamage;
    public float skillDamage;
    public float baseAttackRate;
    public float skillCastRate;
    public float buffValue;
    public float installationCost;
    public string towerName;
    public string towerType;
    public string bulletType;
    public GameObject bulletPrefab;

    // �߰� �Ӽ�
    // public int level;
    // public float upgradeCost;
    // public float upgradedAttackDamage;
    // public float upgradedAttackRate;
    // public float upgradedSkillCastRate;

    private void Start()
    {
        InvokeRepeating("BasicAttack", 0f, baseAttackRate);
        InvokeRepeating("UseSkill", 0f, skillCastRate);
    }

    void BasicAttack()
    {
        MonsterTargeting();
        // �⺻ �߻� ���� �߰�
        // Instantiate(bulletPrefab, transform.position, Quaternion.identity);
    }

    void UseSkill()
    {
        MonsterTargeting();
        // ��ų ��� ���� �߰�
        // UniqueSkillEffect();
    }

    void MonsterTargeting()
    {
        // ���͸� Ÿ�����ϴ� ���� �߰�
    }

    // void UniqueSkillEffect()
    // {
    //     ������ ��ų ȿ�� ���� �߰�
    // }
}
