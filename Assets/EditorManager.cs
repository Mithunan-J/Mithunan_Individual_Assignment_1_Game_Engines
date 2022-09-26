using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EditorManager : MonoBehaviour
{
    InputMaster inputAction;

    public GameObject mainCam;
    public GameObject editorCam;

    public bool editorMode = false;
    // Start is called before the first frame update
    void Awake()
    {
        //inputAction = Player.instance.controls;
        inputAction = new InputMaster();

        inputAction.Editor.EnableEditor.performed += cntxt => SwitchCamera();

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void SwitchCamera()
    {
        Debug.Log("Wow");
        if(mainCam.activeSelf == true)
        {
            mainCam.SetActive(false);
            editorCam.SetActive(true);
        }
        else
        {
            mainCam.SetActive(true);
            editorCam.SetActive(false);
        }
        
        
    }

    private void OnEnable()
    {
        inputAction.Enable();
    }

    private void OnDisable()
    {
        inputAction.Disable();
    }
}
