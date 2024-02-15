using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Bomb : MonoBehaviour
{
    public int[] bombIndex;

    GameObject BombObject;

    public GameObject magicCircle;

    public GameObject bombPaticle;
    GameObject _paticle;
    void Start()
    {
        magicCircle.SetActive(false);
    }

    public void BombPrefeb(int a)
    {
        while(true)
        {
            BombObject = Tower_Manager.Instance.Tower_Disposition_Arr
                [Random.Range(0, Tower_Manager.Instance.Tower_Disposition_Arr.Length)];

            if (BombObject != null) break;
        }


        if (BombObject.GetComponent<Range_Enhance_Tower>() != null) 
        {
            BombObject.GetComponent<Range_Enhance_Tower>().Ex_BuffCancel();
        }
        if (BombObject.GetComponent<Density_Enhance_Tower>() != null)
        {
            BombObject.GetComponent<Density_Enhance_Tower>().Ex_BuffCancel();
        }

        magicCircle.SetActive(true);
        _paticle = Instantiate(bombPaticle);
        _paticle.transform.position = BombObject.transform.position;
        Invoke("DestroyTowal", 0.5f);
    }

   

    void DestroyTowal()
    {
        magicCircle.SetActive(false);
        Destroy(BombObject);
        Destroy(_paticle);
    }
}
