using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RebindUI : MonoBehaviour
{
    [SerializeField] private InputActionReference _actionRef;

    [SerializeField] private string _scheme = "Keyboard";

    [SerializeField] private TMP_Text _pathText;

    [SerializeField] private GameObject _mask;

    private InputAction _action;
    private InputActionRebindingExtensions.RebindingOperation _rebindOperation;

    // Start is called before the first frame update
    private void Awake()
    {
        if (_actionRef == null) return;

        _action = _actionRef.action;

        RefreshDisplay();
    }

    private void OnDestroy()
    {
        CleanUpOperation();
    }


    public void StartRebinding()
    {
        if (_action == null) return;

        _rebindOperation?.Cancel();

        _action.Disable();

        var bindingIndex = _action.GetBindingIndex(
            InputBinding.MaskByGroup(_scheme)
            );

        if (_mask != null) _mask.SetActive(true);

        void onFinished()
        {
            CleanUpOperation();

            _action.Enable();

            if (_mask != null) _mask.SetActive(false);
        }



        _rebindOperation = _action.PerformInteractiveRebinding(bindingIndex)
            .OnComplete(_ =>
            {
                RefreshDisplay();
                onFinished();
            }).OnCancel(_ =>
            {
                onFinished();
            })
            .Start();
    }

    public void RefreshDisplay()
    {
        if (_action == null || _pathText == null) return;

        _pathText.text = _action.GetBindingDisplayString();
    }

    private void CleanUpOperation()
    {
        _rebindOperation?.Dispose();
        _rebindOperation = null;
    }
}
