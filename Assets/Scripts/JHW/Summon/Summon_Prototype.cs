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
        // 소환물을 제거하거나 필요한 추가 로직을 여기에 구현
        Destroy(gameObject);
    }
}
