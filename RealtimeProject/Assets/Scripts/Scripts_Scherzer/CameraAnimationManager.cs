using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAnimationManager : MonoBehaviour
{
    public Animator cameraAnimator;

    /// <summary>
    /// Controlls Cameras via Index
    /// </summary>
    /// <param name="i"></param>
    public void SetCameraIndex(int i)
    {
        cameraAnimator.SetInteger("cameraIndex", i);
    }

}
