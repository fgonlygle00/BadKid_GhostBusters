using UnityEngine;

public class Summon_Prototype : MonoBehaviour
{
    public float creationTime;

    void Start()
    {
        Invoke("DestroySummon", creationTime);
    }

    void DestroySummon()
    {
        // ��ȯ���� �����ϰų� �ʿ��� �߰� ������ ���⿡ ����
        Destroy(gameObject);
    }
}
