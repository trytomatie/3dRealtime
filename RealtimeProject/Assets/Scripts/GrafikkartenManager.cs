using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrafikkartenManager : MonoBehaviour
{
    public GameObject[] grafikkartenteile;
    public GameObject rgbPanel;
    public Texture2D[] baseColorGrafikkarten;
    public Color[] rgbColor;

    private bool showRgbPan = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TextureChange(int textureIndex)
    {
        //veränder die Textur der BaseColor für alle GrafikkartenTeile
        for (int i = 0; i < grafikkartenteile.Length; i++)
        {
            MeshRenderer graKaRenderer = grafikkartenteile[i].GetComponent<MeshRenderer>();
            graKaRenderer.material.SetTexture("_DiffuseTexture", baseColorGrafikkarten[textureIndex]);

        }
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
        rgbPanel.SetActive(showRgbPan);
       
    }



    public void rgbColorChange(int colorIndex)
    {
        //veränder die RGB Farbe der BaseColor für alle GrafikkartenTeile
        for (int i = 0; i < grafikkartenteile.Length; i++)
        {
            MeshRenderer ramRenderer = grafikkartenteile[i].GetComponent<MeshRenderer>();
            ramRenderer.material.SetColor("_RGBEmissionColor", rgbColor[colorIndex]);

        }
    }

}
