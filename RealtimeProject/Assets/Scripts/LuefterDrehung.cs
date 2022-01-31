using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuefterDrehung : MonoBehaviour
{

    public GameObject[] luefter;
    
    public void LuefterSet(bool luefterBool)
    {
        for (int i=0; i < luefter.Length; i++)
        {
            Animator luefterAnimator = luefter[i].GetComponent<Animator>();
            luefterAnimator.SetBool("LuefterAn", luefterBool);
        }
    }
}
