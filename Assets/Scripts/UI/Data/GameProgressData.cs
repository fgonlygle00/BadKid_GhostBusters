using UnityEngine;
using UnityEngine.UI;

public class GameProgressData : MonoBehaviour
{
    [SerializeField] private Text _waveData;
    [SerializeField] private Text _defendWaveData;
    public Invasion_Controller _monsterAtteck;

    void Update()
    {
        // 현재 웨이브 표시
        _waveData.text = Monster_Manager.Instanse.Wave.ToString("00");
        if (_waveData.text == "21") _waveData.text = "20";

        // 몬스터가 최종 목적지 도착시 현재 내 웨이브 방어 데이터 감소
        _defendWaveData.text = _monsterAtteck.ReturnHealth().ToString("00");
        if (_monsterAtteck.ReturnHealth() <= 0)
            _defendWaveData.text = "00";
    }
}
