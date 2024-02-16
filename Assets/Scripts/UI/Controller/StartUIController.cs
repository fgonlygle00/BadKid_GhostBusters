using UnityEngine;
using UnityEngine.SceneManagement;

public class StartUIController : MonoBehaviour
{
    [SerializeField] private GameObject _description;
    [SerializeField] private GameObject _volumeSetting;
    [SerializeField] private GameObject[] _descriptionPage;
    int currentPageNum;

    // ���� ����
    public void GamePlay()
    {
        AudioManager.instance._audioSource.clip = AudioManager.instance._backGroundMusics[0];
        AudioManager.instance._audioSource.Play();
        SceneManager.LoadScene("MainScene");
    }

    // ���� ����
    public void GameDescription()
    {
        _description.SetActive(true);
    }
    // ���� ���� â �ݱ�
    public void GameDescriptionClose()
    {
        _description.SetActive(false);
    }
    // ������ �ѱ��
    public void NextPage(bool isRight)
    {
        // ������ �ѱ��
        if (isRight)
        {
            if (0 <= currentPageNum && currentPageNum < 5)
            {
                for (int i = 0; i < _descriptionPage.Length; i++)
                {
                    _descriptionPage[i].SetActive(false);
                }
                currentPageNum++;
                _descriptionPage[currentPageNum].SetActive(true);
            }
        }
        else
        {
            if (0 < currentPageNum && currentPageNum < 6)
            {
                for (int i = 0; i < _descriptionPage.Length; i++)
                {
                    _descriptionPage[i].SetActive(false);
                }
                currentPageNum--;
                _descriptionPage[currentPageNum].SetActive(true);
            }
        }
    }

    // ���� ���� ����
    public void VolumeSetting()
    {
        _volumeSetting.SetActive(true);
    }

    // â �ݱ�
    public void WindowClose()
    {
        _description.SetActive(false);
        _volumeSetting.SetActive(false);
    }

    // ���� ����
    public void GameExit()
    {
        // �ش� �ڵ�� �����Ϳ� ����� �����ϴ°�
        UnityEditor.EditorApplication.isPlaying = false;
        // ��¥ ������ �����ϴ°�
        Application.Quit();
    }
}
