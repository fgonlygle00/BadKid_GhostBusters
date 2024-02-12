using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Wave_Manager
{
    int wave;
    public float Time; //웨이브 종료 시간
    [SerializeField] float delay;
    [SerializeField] int[] monsterPersent;

    public void setWave(int W,float T,float D, int M1, int M2, int M3, int M4)
    {
        Time = T;
        wave = W;
        delay = D;
        monsterPersent = new int[] { M1, M2, M3, M4 };
    }

    public int ReturnWave()
    {
        return wave;
    }

    public float ReturnDelay()
    {
        return delay;
    }

    public int[] ReturnPersent()
    {
        return monsterPersent;
    }

}



public class Monster_Manager : MonoBehaviour
{

    //밖에서 적용되는지 보기위해서 잠깐 이렇게 설정
    [SerializeField] Wave_Manager waveManager;
    [Header("Wave")]
    [SerializeField] int Wave;
    [SerializeField] float time;
    private bool _runTime;

    //---------------------------------

    [Header("Spwan")]
    [SerializeField] private Transform _spwanPos;
    [SerializeField] private float _delay; //생성되는 시간
    private float _curDelay;  //변화할때 사용
    public GameObject[] monsterPrefap;
    [HideInInspector] public List<Monster_Controller> _monsters = new List<Monster_Controller>();

    private int[] _monsterPersent;

    [Header("Path")]
    public Transform[] Points;

    [Header("Datas")]
    [SerializeField] private Monster_Status[] Datas;


    static public Monster_Manager Instanse; //싱글톤


    void Start()
    {
        waveManager.setWave(1, 40f, 1.2f, 90, 93, 96, 100);//웨이브1
        Instanse = this;

        SetWave();

        _curDelay = _delay;
    }


    void Update()
    {



        if(_runTime)
        {
            if (_curDelay <= 0)
            {
                RandomMonster(_monsterPersent[0], _monsterPersent[1], _monsterPersent[2], _monsterPersent[3]);
                _monsters[_monsters.Count - 1].SetPos(_spwanPos);
                _curDelay = _delay;
            }
            else
            {
                _curDelay -= Time.deltaTime;
            }
            time -= Time.deltaTime;
        }
        if(time <=0&& _runTime)
        {
            _runTime = false;
            time = 0;
            Wave++;

            //여기서 다음웨이브까지 몇초간 쉬는 타이밍 있으면 좋겠음, 때문에 인보크로 다음 웨이브 조절
            Invoke("SetWaveManager", 3f); //임시 딜레이
        }


    }


    void SetWaveManager()
    {
        switch (Wave)
        {
            case 1:
                waveManager.setWave(1, 40f, 1.2f, 90, 93, 96, 100);
                break;
            case 2:
                waveManager.setWave(2, 40f, 1f, 90, 93, 96, 100);
                break;
            case 3:
                waveManager.setWave(3, 40f, 0.8f, 90, 93, 96, 100);
                break;
            case 4:
                waveManager.setWave(4, 40f, 0.8f, 80, 90, 95, 100);
                break;
            case 5:
                waveManager.setWave(5, 30f, 5.5f, 90, 100, 101, 102);
                //보스소환로직
                break;
            case 6:
                Monster_HealthUP(1.5f);
                waveManager.setWave(6, 40f, 1.2f, 80, 90, 95, 100);
                break;
            case 7:
                waveManager.setWave(7, 40f, 1f, 80, 90, 95, 100);
                break;
            case 8:
                waveManager.setWave(8, 40f, 1f, 70, 85, 95, 100);
                break;
            case 9:
                waveManager.setWave(9, 40f, 0.8f, 70, 85, 95, 100);
                break;
            case 10:
                waveManager.setWave(10, 20f, 4f, 85, 100, 101, 102);
                //보스소환로직
                break;
            case 11:
                Monster_HealthUP(1.6f);
                waveManager.setWave(11, 40f, 1.2f, 60, 85, 95, 100);
                break;
            case 12:
                waveManager.setWave(12, 40f, 1f, 60, 85, 95, 100);
                break;
            case 13:
                waveManager.setWave(13, 40f, 1f, 40, 70, 90, 100);
                break;
            case 14:
                waveManager.setWave(14, 40f, 0.8f, 40, 70, 90, 100);
                break;
            case 15:
                waveManager.setWave(15, 10f, 4f, 0, 0, 100, 101);
                //보스소환로직
                break;
            case 16:
                Monster_HealthUP(1.7f);
                waveManager.setWave(16, 40f, 1.2f, 40, 70, 90, 100);
                break;
            case 17:
                waveManager.setWave(17, 40f, 1f, 40, 70, 90, 100);
                break;
            case 18:
                waveManager.setWave(18, 40f, 1f, 30, 60, 85, 100);
                break;
            case 19:
                waveManager.setWave(19, 40f, 0.8f, 30, 60, 85, 100);
                break;
            case 20:
                waveManager.setWave(20, 20f, 4f, 40, 70, 90, 100);
                //보스소환로직
                break;
            case 21:
                //클리어 판정
                break;

        }

        SetWave();
    }
    

    void SetWave()
    {
        Wave = waveManager.ReturnWave();
        _delay = waveManager.ReturnDelay();
        time = waveManager.Time;
        _runTime = true;
        _monsterPersent = waveManager.ReturnPersent();
    }

    void RandomMonster(int M1, int M2, int M3, int M4)
    {
        int RInt = Random.Range(0, 101);

        if(RInt<= M1)
        {
            SpwanMonster(monsterPrefap[0]);
        }
        else if (RInt <= M2)
        {
            SpwanMonster(monsterPrefap[1]);
        }
        else if (RInt <= M3)
        {
            SpwanMonster(monsterPrefap[2]);
        }
        else if (RInt <= M4)
        {
            SpwanMonster(monsterPrefap[3]);
        }
    }


    void SpwanMonster(GameObject gameObject)
    {
        _monsters.Add(Instantiate(gameObject, _spwanPos).GetComponent<Monster_Controller>());
    }


    void Monster_HealthUP(float UP)
    {
        foreach (var monster in Datas)
        {
            float HP = monster.hp;
            HP *= UP;
            monster.hp = HP;

        }
    }
}
