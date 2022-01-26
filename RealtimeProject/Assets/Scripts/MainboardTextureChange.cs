using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainboardTextureChange : MonoBehaviour
{

    public Texture2D[] baseColorTexture;

    public int basecolorIndex;

    public Material mainboardShader;

    // Start is called before the first frame update
    void Start()
    {
        ChangeMaterial(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow)==true)
        {
            ChangeMaterial(basecolorIndex);
        }
    }


    public void ChangeMaterial(int textureIndex)
    {
        mainboardShader.SetTexture("_BaseColor", baseColorTexture[textureIndex]);
    }
}
