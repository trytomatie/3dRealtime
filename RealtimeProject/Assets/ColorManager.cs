using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ColorManager : MonoBehaviour
{

    public List<Material> metalMaterials = new List<Material>();
    public Color changeColor;
    public float animationSpeed = 0.5f;

    private float minAnimValue = -0.05f;
    private float maxAnimValue = 1.05f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeColor(Color newColor)
    {

            StartCoroutine(ChangeColorAnimation(newColor));
    }

    IEnumerator ChangeColorAnimation(Color newColor)
    {
        float value = metalMaterials[0].GetFloat("_ColorChangeAnimationValue");
        int direction = 1;
        if(value > 0.5f)
        {
            foreach (Material m in metalMaterials)
            {
                m.SetColor("_Color", newColor);
            }
            direction = -1;
        }
        else
        {
            foreach (Material m in metalMaterials)
            {
                m.SetColor("_ChangeColor", newColor);
            }
            direction = 1;
        }
        print(direction);
        int i = 0; // Breakout index

        do
        {
            foreach (Material m in metalMaterials)
            {
                value = Mathf.Clamp(value + Time.deltaTime * direction * animationSpeed, minAnimValue, maxAnimValue);
                m.SetFloat("_ColorChangeAnimationValue", value);
            }
            i++;
            yield return new WaitForEndOfFrame();
        }
        while (i < 400 && value != maxAnimValue && value != maxAnimValue);
    }

    [CustomEditor(typeof(ColorManager))]
    public class ColorManagerEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            ColorManager myTarget = (ColorManager)target;
            if (GUILayout.Button("Set Lightcolors"))
            {
                myTarget.ChangeColor(myTarget.changeColor);
            }
        }


    }
}
