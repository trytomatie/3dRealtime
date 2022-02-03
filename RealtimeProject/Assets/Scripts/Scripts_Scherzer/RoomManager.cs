using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class RoomManager : MonoBehaviour
{

    public List<GameObject> rooms = new List<GameObject>();
    public List<Camera> cameras = new List<Camera>();
    public int roomIndex = 0;
    public Image transitionImage;
    public float transitionSpeed = 1;

    private bool isTransitioning = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    /// <summary>
    /// Changes room
    /// </summary>
    /// <param name="index"></param>
    public void ChangeRoom(int index)
    {
        StartCoroutine(ChangeRoomAnimation(index));
    }

    /// <summary>
    /// Initiates Room Changing Animation
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    IEnumerator ChangeRoomAnimation(int index)
    {
        // Checks if room is already tranitioning
        if(!isTransitioning)
        {
            
        
            isTransitioning = true;
            int i = 0; // Breakout index
            bool roomChanged = false;
            float alphaValue = 0;
            float timer = 0;
            int direction = 1;
            do
            {
                timer += Time.deltaTime;
                alphaValue += Time.deltaTime * transitionSpeed * direction;
                // print(alphaValue);

                // Fades to black
                transitionImage.color = new Color(transitionImage.color.r, transitionImage.color.g, transitionImage.color.b, alphaValue);

                // Check if screen is black and room hasn't changed
                if(alphaValue > 1f && !roomChanged)
                {
                    // Disable all rooms
                    foreach (GameObject room in rooms)
                    {
                        room.gameObject.SetActive(false);
                    }
                    // enable room to be changed to
                    rooms[index].SetActive(true);

                    // enable right Camera
                    if(rooms[index].CompareTag("SkyBoxOn"))
                    {
                        foreach(Camera camera in cameras)
                        {
                            camera.enabled = false;
                        }
                        cameras[1].enabled = true;
                    }
                    else
                    {
                        foreach (Camera camera in cameras)
                        {
                            camera.enabled = false;
                        }
                        cameras[0].enabled = true;

                    }
                    // small delay
                    yield return new WaitForSeconds(0.2f);
                    // Changes direction of animation
                    direction = -1;
                    roomChanged = true;
                }
                i++;
                yield return new WaitForEndOfFrame();
            }
            while (i < 4020 && alphaValue > 0);
            isTransitioning = false;
        }

    }

}

#if (UNITY_EDITOR)

[CustomEditor(typeof(RoomManager))]
public class RoomManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        RoomManager myTarget = (RoomManager)target;
        if (GUILayout.Button("ChangeRoom"))
        {
            myTarget.ChangeRoom(myTarget.roomIndex);
        }
    }


}

#endif
