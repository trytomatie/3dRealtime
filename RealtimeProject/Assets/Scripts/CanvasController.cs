using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    public List<GameObject> ui = new List<GameObject>();
    public Image uiHideButtonGraphic;
    public Sprite hideSprite;
    public Sprite showSprite;
    
    public void UpdateCanvas(Toggle toggle)
    {
        foreach(GameObject go in ui)
        {
            go.SetActive(toggle.isOn);
        }
        if(toggle.isOn)
        {
            uiHideButtonGraphic.sprite = showSprite;
            uiHideButtonGraphic.color = new Color(1, 1, 1, 1);
        }
        else
        {
            uiHideButtonGraphic.sprite = hideSprite;
            uiHideButtonGraphic.color = new Color(1, 1, 1, 0.5f);
        }
    }
}
