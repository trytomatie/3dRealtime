using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public class AnimationControler : MonoBehaviour
{
    private Animator myAnimator;
    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();
    }

    public void SetBoolean(Toggle toggle )
    {
        myAnimator.SetBool("TriggerUI_Bool", !toggle.isOn);
    }
}
