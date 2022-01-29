using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MaterialColorToLightSource : MonoBehaviour
{

    public Material material;
    public List<Light> lightSources = new List<Light>();
    public float intensity = 1;
    public Color color;



    // Start is called before the first frame update
    void Start()
    {
        //Color = material.color;
    }

    public Color Color 
    { 
        get => color;
        set 
        {
            SetColor(value);
            color = value;
        } 
    }

    public void SetColor(Color color)
    {
        material.SetColor("Color_29a375e269434577a51ce698be68cd4b", color * intensity);
        foreach(Light lightSource in lightSources)
        {
            lightSource.color = color * Mathf.Clamp(intensity * 0.1f,0,1);
        }

    }

}

[CustomEditor(typeof(MaterialColorToLightSource))]
public class MaterialColorToLightSourceEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        MaterialColorToLightSource myTarget = (MaterialColorToLightSource)target;
        if (GUILayout.Button("Set Lightcolors"))
        {
            myTarget.SetColor(myTarget.color);
        }
    }

    
}