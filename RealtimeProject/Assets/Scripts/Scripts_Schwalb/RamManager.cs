using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RamManager : MonoBehaviour
{

    public GameObject[] ramType;
    public GameObject rgbButton;
    public GameObject rgbPanel;
    public Color[] rgbColor;


    private GameObject[] ramSlots = new GameObject[4];
    private int currentRamType;
    private string channelType;

    private bool initialize;
    private bool showRgbPan = false;

    // Start is called before the first frame update
    void Start()
    {
        initialize = true;
        showRgbPan = false;


        SetRamType(1);
        channelType = "Dual";
        rgbPanel.SetActive(showRgbPan);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetRamType(int ramTypeIndex)
    {
        //setze die Den Wert fürs current ramtype aufs Ram
        currentRamType = ramTypeIndex;

        //setze alle Ramtypes auf off
        for (int i = 0; i < ramType.Length; i++)
        {
            ramType[i].SetActive(false);
        }

        //Aktiviere das aktuelle ram type
        ramType[ramTypeIndex].SetActive(true);

        //print(currentRamType);

        //initialisiere die Ramslots für den Aktuellen Ramtypen
        for (int i = 0; i < ramSlots.Length; i++)
        {
           // print(ramType[currentRamType].transform.GetChild(i).gameObject.name);
            ramSlots[i] = ramType[currentRamType].transform.GetChild(i).gameObject;
        }

        

        //Setze die Rams in Channel Mode

        if (channelType== "Quad")
        {
            QuadChannel();
        } else if (channelType == "Dual")
        {
            DualChannel();
        } else if (channelType== "Single")
        {
            SingleChannelRam();
        }

        if (currentRamType == 1)
        {
            rgbButton.SetActive(true);
        }
        else
        {
            rgbButton.SetActive(false);
        }


    }

    public void SingleChannelRam()
    {
        //setze alle RamSlots auf aus und Schalte den Slot 2 wieder an
        if (initialize)
        {
            SetAllRamSlots(false);
            ramSlots[1].SetActive(true);
            
        }
        rgbPanel.SetActive(false);

        channelType = "Single";
    }

    public void DualChannel()
    {
        //setze alle RamSlots auf aus und Schalte den Slot 2und 4 wieder an
        if (initialize)
        {
            SetAllRamSlots(false);
            ramSlots[1].SetActive(true);
            ramSlots[3].SetActive(true);
        }
       

        channelType = "Dual";
    }

    public void QuadChannel()
    {
        //setze alle Ramslots auf true
        if (initialize)
        {
            SetAllRamSlots(true);
        }
        
        channelType = "Quad";
    }
    
    private void SetAllRamSlots(bool valueBool)
    {
        //setze alle Ramslots auf den Wert valueBool
        for (int i = 0; i < ramSlots.Length; i++)
        {
            ramSlots[i].SetActive(valueBool);
        }
    }

    public void SetRgbPannel()
    {
        //toggle das Farb Panel
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

    public void ChangeRgbColor(int colorIndex)
    {
        //setze die RGB Farbe für alle Ram Sticks
        print(colorIndex);
        for (int i = 0; i < ramSlots.Length; i++)
        {
            MeshRenderer ramRenderer = ramSlots[i].GetComponent<MeshRenderer>();
            ramRenderer.material.SetColor("_RGBEmissionColor", rgbColor[colorIndex]);
            
        }
    }

}
