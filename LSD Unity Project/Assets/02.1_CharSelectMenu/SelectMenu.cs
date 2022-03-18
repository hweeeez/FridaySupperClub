// GENERATED AUTOMATICALLY FROM 'Assets/02.1_CharSelectMenu/SelectMenu.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @SelectMenu : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @SelectMenu()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""SelectMenu"",
    ""maps"": [
        {
            ""name"": ""CharSelect"",
            ""id"": ""3a50fd1b-d13a-48f6-bd98-c4f840fa92b7"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Button"",
                    ""id"": ""6b03a214-4890-4965-911e-fa4f09fe4383"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Select"",
                    ""type"": ""Button"",
                    ""id"": ""adfd1ac1-9800-4bb7-a310-ee16bd91d5ed"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""16e0ef5b-fb6d-49fd-9811-d030e34e9d13"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""c5c74f71-e424-4b29-a7e6-301fdb88c051"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""41ae56bf-85fb-481b-a800-5a6b025b5a47"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""ddce3ae4-7ac5-4d49-8589-6e079582ac9d"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""50d4099d-5454-48f2-bdcf-027e73fe83f4"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""2e8dbb8d-2ec1-417f-a635-d148487e127e"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": ""Press(behavior=2)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // CharSelect
        m_CharSelect = asset.FindActionMap("CharSelect", throwIfNotFound: true);
        m_CharSelect_Movement = m_CharSelect.FindAction("Movement", throwIfNotFound: true);
        m_CharSelect_Select = m_CharSelect.FindAction("Select", throwIfNotFound: true);
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

    // CharSelect
    private readonly InputActionMap m_CharSelect;
    private ICharSelectActions m_CharSelectActionsCallbackInterface;
    private readonly InputAction m_CharSelect_Movement;
    private readonly InputAction m_CharSelect_Select;
    public struct CharSelectActions
    {
        private @SelectMenu m_Wrapper;
        public CharSelectActions(@SelectMenu wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_CharSelect_Movement;
        public InputAction @Select => m_Wrapper.m_CharSelect_Select;
        public InputActionMap Get() { return m_Wrapper.m_CharSelect; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CharSelectActions set) { return set.Get(); }
        public void SetCallbacks(ICharSelectActions instance)
        {
            if (m_Wrapper.m_CharSelectActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_CharSelectActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_CharSelectActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_CharSelectActionsCallbackInterface.OnMovement;
                @Select.started -= m_Wrapper.m_CharSelectActionsCallbackInterface.OnSelect;
                @Select.performed -= m_Wrapper.m_CharSelectActionsCallbackInterface.OnSelect;
                @Select.canceled -= m_Wrapper.m_CharSelectActionsCallbackInterface.OnSelect;
            }
            m_Wrapper.m_CharSelectActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Select.started += instance.OnSelect;
                @Select.performed += instance.OnSelect;
                @Select.canceled += instance.OnSelect;
            }
        }
    }
    public CharSelectActions @CharSelect => new CharSelectActions(this);
    public interface ICharSelectActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnSelect(InputAction.CallbackContext context);
    }
}
