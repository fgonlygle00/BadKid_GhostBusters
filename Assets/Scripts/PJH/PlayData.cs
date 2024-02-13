using UnityEngine;
using UnityEngine.UI;

public class PlayData : MonoBehaviour
{
    [SerializeField] private Text _waveData;
    [SerializeField] private Text _defendWaveData;
    public Invasion_Controller _monsterAtteck;

    void Update()
    {
        // ���� ���̺� ǥ��
        _waveData.text = Monster_Manager.Instanse.Wave.ToString("00");

        // ���Ͱ� ���� ������ ������ ���� �� ���̺� ��� ������ ����
        _defendWaveData.text = _monsterAtteck.ReturnHealth().ToString("00");
    }
}
