using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Test : MonoBehaviour
{
    [SerializeField] private InputActionReference _LeftactionRef;
    [SerializeField] private InputActionReference _DownactionRef;
    [SerializeField] private InputActionReference _UpactionRef;
    [SerializeField] private InputActionReference _RightactionRef;

    // Start is called before the first frame update
    void Awake()
    {
        _LeftactionRef.action.Enable();
        _DownactionRef.action.Enable();
        _UpactionRef.action.Enable();
        _RightactionRef.action.Enable();
    }

    private void OnDestroy()
    {
        _LeftactionRef.action.Dispose();
        _DownactionRef.action.Dispose();
        _UpactionRef.action.Dispose();
        _RightactionRef.action.Dispose();
    }

    // Update is called once per frame
    void Update()
    {
        TestBind();
    }

    private void TestBind()
    {
        _LeftactionRef.action.started += action1;
        _DownactionRef.action.started += action2;
        _UpactionRef.action.started += action3;
        _RightactionRef.action.started += action4;
    }

    private void action4(InputAction.CallbackContext context)
    {
        Debug.Log("4");
    }

    private void action3(InputAction.CallbackContext context)
    {
        Debug.Log("3");
    }

    private void action2(InputAction.CallbackContext context)
    {
        Debug.Log("2");
    }

    private void action1(InputAction.CallbackContext context)
    {
        Debug.Log("1");
    }
}
