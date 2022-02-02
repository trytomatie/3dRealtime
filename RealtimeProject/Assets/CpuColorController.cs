using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class CpuColorController : MonoBehaviour
{
    public Material cpuMaterial;
    public float intensity;

    public Color color;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SetColor(Image image)
    {
        SetColor(image.color);
    }

    public void SetColor(Color color)
    {
        cpuMaterial.SetColor("_CustomColor", color * intensity);
    }

    [CustomEditor(typeof(CpuColorController))]
    public class CpuColorControllerEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            CpuColorController myTarget = (CpuColorController)target;
            if (GUILayout.Button("Set Color"))
            {
                myTarget.SetColor(myTarget.color);
            }
        }


    }
}
