using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ScaleOnHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public TextMeshProUGUI text;

    public void OnPointerEnter(PointerEventData eventData)
    {
        text.fontSize = 60;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        text.fontSize = 50;
    }
}
