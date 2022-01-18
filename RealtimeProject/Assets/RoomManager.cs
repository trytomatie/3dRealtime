using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class RoomManager : MonoBehaviour
{

    public List<GameObject> rooms = new List<GameObject>();
    public int roomIndex = 0;
    public Image transitionImage;
    public float transitionSpeed = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ChangeRoom(int index)
    {
        StartCoroutine(ChangeRoomAnimation(index));
    }

    IEnumerator ChangeRoomAnimation(int index)
    {


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
            transitionImage.color = new Color(transitionImage.color.r, transitionImage.color.g, transitionImage.color.b, alphaValue);
            if(alphaValue > 1f && !roomChanged)
            {
                foreach (GameObject room in rooms)
                {
                    room.gameObject.SetActive(false);
                }
                rooms[index].SetActive(true);
                yield return new WaitForSeconds(0.2f);
                direction = -1;
                roomChanged = true;
            }
            i++;
            yield return new WaitForEndOfFrame();
        }
        while (i < 4020 && alphaValue > 0);

    }

}

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