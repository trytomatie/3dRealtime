using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ColorManager : MonoBehaviour
{

    public List<Material> metalMaterials = new List<Material>();
    public Color changeColor;
    public float animationSpeed = 0.5f;

    private float minAnimValue = -0.05f;
    private float maxAnimValue = 1.05f;

    private bool interuptAnimaton = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    /// <summary>
    /// Changes color depending on image color
    /// </summary>
    /// <param name="image"></param>
    public void ChangeColor(Image image)
    {
        Color newColor = image.color;
        interuptAnimaton = true;
        StartCoroutine(ChangeColorAnimation(newColor));
    }

    /// <summary>
    /// Changes Color
    /// </summary>
    /// <param name="newColor"></param>
    public void ChangeColor(Color newColor)
    {
        interuptAnimaton = true;
        StartCoroutine(ChangeColorAnimation(newColor));
    }

    /// <summary>
    /// Starts Color Chaning Animation
    /// </summary>
    /// <param name="newColor"></param>
    /// <returns></returns>
    IEnumerator ChangeColorAnimation(Color newColor)
    {
        if(interuptAnimaton == true)
        {
            yield return new WaitForEndOfFrame();
        }
        interuptAnimaton = false;
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
        while (i < 1000 && value != maxAnimValue && value != maxAnimValue && !interuptAnimaton);
    }

}

#if (UNITY_EDITOR) 

[CustomEditor(typeof(ColorManager))]
public class ColorManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        ColorManager myTarget = (ColorManager)target;
        if (GUILayout.Button("Set Colors"))
        {
            myTarget.ChangeColor(myTarget.changeColor);
        }
    }


}
#endif
