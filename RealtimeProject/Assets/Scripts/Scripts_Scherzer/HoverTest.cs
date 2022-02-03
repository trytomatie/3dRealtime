using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HoverTest : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image target;
    public Color normalColor;
    public Color highlightedColor;
    public void OnPointerEnter(PointerEventData eventData)
    {
        target.color = highlightedColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        target.color = normalColor;
    }


}
