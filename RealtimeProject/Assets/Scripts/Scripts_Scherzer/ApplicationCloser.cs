using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplicationCloser : MonoBehaviour
{

    /// <summary>
    /// Closes Application
    /// </summary>
    public void CloseApplication()
    {
        Application.Quit(0);
    }

}
