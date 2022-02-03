using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

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
        SetColor(Color.white);
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

    /// <summary>
    /// Sets Light color and Matrial Color
    /// </summary>
    /// <param name="color"></param>
    public void SetColor(Color color)
    {
        material.SetColor("_Color", color * intensity);
        foreach (Light lightSource in lightSources)
        {
            lightSource.color = color * Mathf.Clamp(intensity * 0.1f, 0, 1);
        }

    }

    /// <summary>
    /// Sets color depending on image color
    /// </summary>
    /// <param name="img"></param>
    public void SetColor(Image img)
    {
        SetColor(img.color);
    }
}

#if (UNITY_EDITOR)
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

#endif