//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.6.3
//     from Assets/EditScene/Control/EditControl.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @EditControl: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @EditControl()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""EditControl"",
    ""maps"": [
        {
            ""name"": ""edit"",
            ""id"": ""6b90bc1a-bc4e-4424-998a-2bf9adb0e659"",
            ""actions"": [
                {
                    ""name"": ""left"",
                    ""type"": ""Button"",
                    ""id"": ""9cd7d2e8-3655-445e-b331-989b4ce61bfb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""down"",
                    ""type"": ""Button"",
                    ""id"": ""92c594bc-4020-4a10-bdcb-33e836c83c5b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""up"",
                    ""type"": ""Button"",
                    ""id"": ""3c002634-47f5-41ad-80e1-1ff1da9c22aa"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""right"",
                    ""type"": ""Button"",
                    ""id"": ""655884ad-74c8-4ef4-a047-2dd278ecc950"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""startandstopchart"",
                    ""type"": ""Button"",
                    ""id"": ""0d565469-b794-4e54-8c79-35c12312a5fe"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""backchart"",
                    ""type"": ""Button"",
                    ""id"": ""7d841192-cd99-4351-b4ab-125d8ce0d0f3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""deletenote"",
                    ""type"": ""Button"",
                    ""id"": ""a49a0e10-e2a7-40ad-a75d-f293b72ce500"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""switch"",
                    ""type"": ""Button"",
                    ""id"": ""9f565d12-ca53-4afa-bc1e-08e72d35beb9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Complete"",
                    ""type"": ""Button"",
                    ""id"": ""e6dd5e62-9e81-40fa-94df-b220878dff1c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""4ee14e4d-ee25-4ac1-b721-28401106fc6f"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4819fd4c-7af4-4510-b48a-dabd8c285441"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d959731a-a078-49ba-9c9b-c2e1aef9cb5f"",
                    ""path"": ""<Keyboard>/k"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""004bbb89-faab-4410-b61f-97d78cfcc3f1"",
                    ""path"": ""<Keyboard>/l"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""def3aaaf-9ab4-4fb4-a66d-f84db6c49223"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""startandstopchart"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f5dfb59d-15e6-4783-b32b-9a5ed24d7e78"",
                    ""path"": ""<Keyboard>/backspace"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""deletenote"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f2565a87-d7da-46aa-83cf-161ed55c9a63"",
                    ""path"": ""<Keyboard>/tab"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""switch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bd1ec0bf-0310-4625-ba0f-a82ada422072"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Complete"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""038eaf91-6e69-4c5e-80a4-2f13377aeea3"",
                    ""path"": ""<Keyboard>/b"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""backchart"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // edit
        m_edit = asset.FindActionMap("edit", throwIfNotFound: true);
        m_edit_left = m_edit.FindAction("left", throwIfNotFound: true);
        m_edit_down = m_edit.FindAction("down", throwIfNotFound: true);
        m_edit_up = m_edit.FindAction("up", throwIfNotFound: true);
        m_edit_right = m_edit.FindAction("right", throwIfNotFound: true);
        m_edit_startandstopchart = m_edit.FindAction("startandstopchart", throwIfNotFound: true);
        m_edit_backchart = m_edit.FindAction("backchart", throwIfNotFound: true);
        m_edit_deletenote = m_edit.FindAction("deletenote", throwIfNotFound: true);
        m_edit_switch = m_edit.FindAction("switch", throwIfNotFound: true);
        m_edit_Complete = m_edit.FindAction("Complete", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // edit
    private readonly InputActionMap m_edit;
    private List<IEditActions> m_EditActionsCallbackInterfaces = new List<IEditActions>();
    private readonly InputAction m_edit_left;
    private readonly InputAction m_edit_down;
    private readonly InputAction m_edit_up;
    private readonly InputAction m_edit_right;
    private readonly InputAction m_edit_startandstopchart;
    private readonly InputAction m_edit_backchart;
    private readonly InputAction m_edit_deletenote;
    private readonly InputAction m_edit_switch;
    private readonly InputAction m_edit_Complete;
    public struct EditActions
    {
        private @EditControl m_Wrapper;
        public EditActions(@EditControl wrapper) { m_Wrapper = wrapper; }
        public InputAction @left => m_Wrapper.m_edit_left;
        public InputAction @down => m_Wrapper.m_edit_down;
        public InputAction @up => m_Wrapper.m_edit_up;
        public InputAction @right => m_Wrapper.m_edit_right;
        public InputAction @startandstopchart => m_Wrapper.m_edit_startandstopchart;
        public InputAction @backchart => m_Wrapper.m_edit_backchart;
        public InputAction @deletenote => m_Wrapper.m_edit_deletenote;
        public InputAction @switch => m_Wrapper.m_edit_switch;
        public InputAction @Complete => m_Wrapper.m_edit_Complete;
        public InputActionMap Get() { return m_Wrapper.m_edit; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(EditActions set) { return set.Get(); }
        public void AddCallbacks(IEditActions instance)
        {
            if (instance == null || m_Wrapper.m_EditActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_EditActionsCallbackInterfaces.Add(instance);
            @left.started += instance.OnLeft;
            @left.performed += instance.OnLeft;
            @left.canceled += instance.OnLeft;
            @down.started += instance.OnDown;
            @down.performed += instance.OnDown;
            @down.canceled += instance.OnDown;
            @up.started += instance.OnUp;
            @up.performed += instance.OnUp;
            @up.canceled += instance.OnUp;
            @right.started += instance.OnRight;
            @right.performed += instance.OnRight;
            @right.canceled += instance.OnRight;
            @startandstopchart.started += instance.OnStartandstopchart;
            @startandstopchart.performed += instance.OnStartandstopchart;
            @startandstopchart.canceled += instance.OnStartandstopchart;
            @backchart.started += instance.OnBackchart;
            @backchart.performed += instance.OnBackchart;
            @backchart.canceled += instance.OnBackchart;
            @deletenote.started += instance.OnDeletenote;
            @deletenote.performed += instance.OnDeletenote;
            @deletenote.canceled += instance.OnDeletenote;
            @switch.started += instance.OnSwitch;
            @switch.performed += instance.OnSwitch;
            @switch.canceled += instance.OnSwitch;
            @Complete.started += instance.OnComplete;
            @Complete.performed += instance.OnComplete;
            @Complete.canceled += instance.OnComplete;
        }

        private void UnregisterCallbacks(IEditActions instance)
        {
            @left.started -= instance.OnLeft;
            @left.performed -= instance.OnLeft;
            @left.canceled -= instance.OnLeft;
            @down.started -= instance.OnDown;
            @down.performed -= instance.OnDown;
            @down.canceled -= instance.OnDown;
            @up.started -= instance.OnUp;
            @up.performed -= instance.OnUp;
            @up.canceled -= instance.OnUp;
            @right.started -= instance.OnRight;
            @right.performed -= instance.OnRight;
            @right.canceled -= instance.OnRight;
            @startandstopchart.started -= instance.OnStartandstopchart;
            @startandstopchart.performed -= instance.OnStartandstopchart;
            @startandstopchart.canceled -= instance.OnStartandstopchart;
            @backchart.started -= instance.OnBackchart;
            @backchart.performed -= instance.OnBackchart;
            @backchart.canceled -= instance.OnBackchart;
            @deletenote.started -= instance.OnDeletenote;
            @deletenote.performed -= instance.OnDeletenote;
            @deletenote.canceled -= instance.OnDeletenote;
            @switch.started -= instance.OnSwitch;
            @switch.performed -= instance.OnSwitch;
            @switch.canceled -= instance.OnSwitch;
            @Complete.started -= instance.OnComplete;
            @Complete.performed -= instance.OnComplete;
            @Complete.canceled -= instance.OnComplete;
        }

        public void RemoveCallbacks(IEditActions instance)
        {
            if (m_Wrapper.m_EditActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IEditActions instance)
        {
            foreach (var item in m_Wrapper.m_EditActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_EditActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public EditActions @edit => new EditActions(this);
    public interface IEditActions
    {
        void OnLeft(InputAction.CallbackContext context);
        void OnDown(InputAction.CallbackContext context);
        void OnUp(InputAction.CallbackContext context);
        void OnRight(InputAction.CallbackContext context);
        void OnStartandstopchart(InputAction.CallbackContext context);
        void OnBackchart(InputAction.CallbackContext context);
        void OnDeletenote(InputAction.CallbackContext context);
        void OnSwitch(InputAction.CallbackContext context);
        void OnComplete(InputAction.CallbackContext context);
    }
}
