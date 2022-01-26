using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainboardTextureChange : MonoBehaviour
{

    public Texture2D[] baseColorTexture;
    
    //public GameObject rgbPanel;
    //public GameObject mainboard;

    public Material mainboardShader;
    public Color[] rgbColor;
    public GameObject rgbPanelMainboard;

    public int basecolorIndex;

    private MeshRenderer mainboardRenderer;
    private bool showRgbPan = false;


    // Start is called before the first frame update
    void Start()
    {
        //setze zum start die Textur auf die Textur mit dem Index 0
        ChangeMaterial(0);
        
    }

    // Update is called once per frame
    void Update()
    {
       /* if (Input.GetKeyDown(KeyCode.UpArrow)==true)
        {
            ChangeMaterial(basecolorIndex);
        }*/
    }

    //verändere die Basecolor des Mainboards zu dem Index
    public void ChangeMaterial(int textureIndex)
    {
        mainboardShader.SetTexture("_BaseColor", baseColorTexture[textureIndex]);
    }

    public void rgbColorChange(int colorIndex)
    {
        //veränder die RGB Farbe der BaseColor für alle GrafikkartenTeile
        mainboardShader.SetColor("_RGBColor", rgbColor[colorIndex]);;
       
    }

    public void SetRgbPannel()
    {

        if (!showRgbPan)
        {
            showRgbPan = true;
        }
        else
        {
            showRgbPan = false;
        }
        rgbPanelMainboard.SetActive(showRgbPan);

    }
}
