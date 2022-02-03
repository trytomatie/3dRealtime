using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuefterDrehung : MonoBehaviour
{

    public GameObject[] luefter;        //Array of Luefter falls irgendwann welche dazu kommen
    
    public void LuefterSet(bool luefterBool)        
    {
        for (int i=0; i < luefter.Length; i++)      //für Gehe das Array der Luefter durch und setze für jeden Luefter die Animator Variable Luefter an den übergebenen Wert
        {
            Animator luefterAnimator = luefter[i].GetComponent<Animator>();
            luefterAnimator.SetBool("LuefterAn", luefterBool);
        }
    }
}
