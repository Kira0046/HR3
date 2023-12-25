using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
//using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;
using UnityEngine.InputSystem;

public class notes : MonoBehaviour
{

    private NotesControl _notesControl;
    // Start is called before the first frame update
    private void Awake()
    {
        _notesControl = new NotesControl();



        _notesControl.Enable();
    }

    private void OnDestroy()
    {
        _notesControl?.Dispose();
    }

    private void Upnotes(InputAction.CallbackContext context)
    {
        if(context.started) {
            Debug.Log("a");
        }


    }

    private void DownNotes(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            Debug.Log("b");
        }
    }

    // Update is called once per frame
    void Update()
    {
        _notesControl.notes.upnotes.started += Upnotes;

        _notesControl.notes.downnotes.started += DownNotes;


        //if (upKey.wasPressedThisFrame) {
        //    Debug.Log("a");

        //}

        //if (downKey.isPressed)
        //{
        //    Debug.Log("b");
        //}

    }

    //private void GetKey()
    //{
    //    var current = Keyboard.current;

    //    if (current == null)
    //    {
    //        return;
    //    }

    //    var aKey = current.aKey;

    //    var bKey=current.bKey;

    //    var upKey = current.upArrowKey;
    //    var downKey=current.downArrowKey;
    //}

}
