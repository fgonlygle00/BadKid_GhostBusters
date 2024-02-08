using UnityEngine;

public class Tower_Prototype : MonoBehaviour
{
    // 기본 속성
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

    // 추가 속성
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
        // 기본 발사 로직 추가
        // Instantiate(bulletPrefab, transform.position, Quaternion.identity);
    }

    void UseSkill()
    {
        MonsterTargeting();
        // 스킬 사용 로직 추가
        // UniqueSkillEffect();
    }

    void MonsterTargeting()
    {
        // 몬스터를 타겟팅하는 로직 추가
    }

    // void UniqueSkillEffect()
    // {
    //     고유한 스킬 효과 로직 추가
    // }
}
