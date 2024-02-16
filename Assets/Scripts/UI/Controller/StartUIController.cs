using UnityEngine;
using UnityEngine.SceneManagement;

public class StartUIController : MonoBehaviour
{
    [SerializeField] private GameObject _description;
    [SerializeField] private GameObject _volumeSetting;
    [SerializeField] private GameObject[] _descriptionPage;
    int currentPageNum;

    // 게임 시작
    public void GamePlay()
    {
        AudioManager.instance._audioSource.clip = AudioManager.instance._backGroundMusics[0];
        AudioManager.instance._audioSource.Play();
        SceneManager.LoadScene("MainScene");
    }

    // 게임 설명
    public void GameDescription()
    {
        _description.SetActive(true);
    }
    // 게임 설명 창 닫기
    public void GameDescriptionClose()
    {
        _description.SetActive(false);
    }
    // 페이지 넘기기
    public void NextPage(bool isRight)
    {
        // 페이지 넘기기
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

    // 게임 볼륨 조절
    public void VolumeSetting()
    {
        _volumeSetting.SetActive(true);
    }

    // 창 닫기
    public void WindowClose()
    {
        _description.SetActive(false);
        _volumeSetting.SetActive(false);
    }

    // 게임 종료
    public void GameExit()
    {
        // 해당 코드는 에디터에 재생을 중지하는거
        UnityEditor.EditorApplication.isPlaying = false;
        // 진짜 게임을 종료하는거
        Application.Quit();
    }
}
