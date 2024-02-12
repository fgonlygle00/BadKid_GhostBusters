using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameUITextAnimation : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Text _gameUITextAnimation;
    public void OnPointerDown(PointerEventData eventData)
    {
        _gameUITextAnimation.rectTransform.anchoredPosition = new Vector2(0, -5f);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _gameUITextAnimation.rectTransform.anchoredPosition = new Vector2(0, 10f);
    }
}
