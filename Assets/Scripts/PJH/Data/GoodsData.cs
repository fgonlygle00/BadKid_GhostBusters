using UnityEngine;
using UnityEngine.UI;

public class GoodsData : MonoBehaviour
{
    [SerializeField] private Text _cookiesQuantity;
    public int _cookies;
    float timer;

    public static GoodsData instance;
    public void Awake()
    {
        instance = this;
    }

    void Start()
    {
        if (SaveAndLoadManager.Instance.gameData != null)
        {
            _cookies = SaveAndLoadManager.Instance.gameData.cookie;
        }
        else
        {
            _cookies = 150;
        }
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 0.75f)
        {
            _cookies++;
            timer = 0.0f;
        }
        _cookiesQuantity.text = _cookies.ToString("00");
    }
}
