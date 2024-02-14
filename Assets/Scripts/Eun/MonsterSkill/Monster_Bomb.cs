using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Bomb : MonoBehaviour
{
    public int[] bombIndex;



    void Start()
    {
        
    }

    public void BombPrefeb()
    {
        GameObject Cheak = Tower_Manager.Instance.Tower_Disposition_Arr[Random.Range(0, Tower_Manager.Instance.Tower_Disposition_Arr.Length)];

        if (true) 
        {
            // 여기에 게임 오브젝트가 서포터가 맞으면 서포터 제거? 메소드
        }

        Destroy(Tower_Manager.Instance.Tower_Disposition_Arr[Random.Range(0, Tower_Manager.Instance.Tower_Disposition_Arr.Length)]);
        
    }
}
