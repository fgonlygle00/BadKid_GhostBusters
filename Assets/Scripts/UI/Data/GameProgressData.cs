using UnityEngine;
using UnityEngine.UI;

public class GameProgressData : MonoBehaviour
{
    [SerializeField] private Text _waveData;
    [SerializeField] private Text _defendWaveData;
    public Invasion_Controller _monsterAtteck;

    void Update()
    {
        // ���� ���̺� ǥ��
        _waveData.text = Monster_Manager.Instanse.Wave.ToString("00");
        if (_waveData.text == "21") _waveData.text = "20";

        // ���Ͱ� ���� ������ ������ ���� �� ���̺� ��� ������ ����
        _defendWaveData.text = _monsterAtteck.ReturnHealth().ToString("00");
        if (_monsterAtteck.ReturnHealth() <= 0)
            _defendWaveData.text = "00";
    }
}
