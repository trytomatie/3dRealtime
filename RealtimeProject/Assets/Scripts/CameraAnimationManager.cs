using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAnimationManager : MonoBehaviour
{
    public Animator cameraAnimator;

    public void SetCameraIndex(int i)
    {
        cameraAnimator.SetInteger("cameraIndex", i);
    }

}
