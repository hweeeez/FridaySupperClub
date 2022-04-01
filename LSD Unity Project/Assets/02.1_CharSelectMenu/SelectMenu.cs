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
                    ""name"": ""Select"",
                    ""type"": ""Button"",
                    ""id"": ""adfd1ac1-9800-4bb7-a310-ee16bd91d5ed"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Left"",
                    ""type"": ""Button"",
                    ""id"": ""acc470d0-5340-4115-95d8-e76c66ce051f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Right"",
                    ""type"": ""Button"",
                    ""id"": ""7d71ec8b-3ccb-4198-96f7-e2f2741d7328"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""2e8dbb8d-2ec1-417f-a635-d148487e127e"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard2"",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0caa6077-6966-4f07-bbe2-497c97c228b5"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard1"",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""da855944-6b7b-487a-9d36-329a09222282"",
                    ""path"": ""<Keyboard>/i"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard3"",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""51b8dad2-9eb9-4471-b834-93bade6ffbb1"",
                    ""path"": ""<Keyboard>/8"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard4"",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7f09cd0a-0efb-440a-85b2-09406b7ba39d"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard2"",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""500e1a6c-6ad8-4c49-b88e-4ceee8a4b822"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard1"",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a676a92f-8caa-4ecc-8a19-ba2dfb2065b0"",
                    ""path"": ""<Keyboard>/j"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard3"",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c0f4e538-273e-43c3-b774-a1ae094ddd18"",
                    ""path"": ""<Keyboard>/numpad4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard4"",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f133392e-4a8a-4e4f-9488-5744060fc823"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard2"",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""259485c7-43bc-4981-b952-52124e16bad0"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard1"",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b52a8073-f1f7-40aa-888f-a73b5dd196b4"",
                    ""path"": ""<Keyboard>/l"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard3"",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""44d10c7e-073a-436c-a7df-67113732f1a9"",
                    ""path"": ""<Keyboard>/numpad6"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard4"",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard1"",
            ""bindingGroup"": ""Keyboard1"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Keyboard2"",
            ""bindingGroup"": ""Keyboard2"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Keyboard3"",
            ""bindingGroup"": ""Keyboard3"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Keyboard4"",
            ""bindingGroup"": ""Keyboard4"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // CharSelect
        m_CharSelect = asset.FindActionMap("CharSelect", throwIfNotFound: true);
        m_CharSelect_Select = m_CharSelect.FindAction("Select", throwIfNotFound: true);
        m_CharSelect_Left = m_CharSelect.FindAction("Left", throwIfNotFound: true);
        m_CharSelect_Right = m_CharSelect.FindAction("Right", throwIfNotFound: true);
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
    private readonly InputAction m_CharSelect_Select;
    private readonly InputAction m_CharSelect_Left;
    private readonly InputAction m_CharSelect_Right;
    public struct CharSelectActions
    {
        private @SelectMenu m_Wrapper;
        public CharSelectActions(@SelectMenu wrapper) { m_Wrapper = wrapper; }
        public InputAction @Select => m_Wrapper.m_CharSelect_Select;
        public InputAction @Left => m_Wrapper.m_CharSelect_Left;
        public InputAction @Right => m_Wrapper.m_CharSelect_Right;
        public InputActionMap Get() { return m_Wrapper.m_CharSelect; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CharSelectActions set) { return set.Get(); }
        public void SetCallbacks(ICharSelectActions instance)
        {
            if (m_Wrapper.m_CharSelectActionsCallbackInterface != null)
            {
                @Select.started -= m_Wrapper.m_CharSelectActionsCallbackInterface.OnSelect;
                @Select.performed -= m_Wrapper.m_CharSelectActionsCallbackInterface.OnSelect;
                @Select.canceled -= m_Wrapper.m_CharSelectActionsCallbackInterface.OnSelect;
                @Left.started -= m_Wrapper.m_CharSelectActionsCallbackInterface.OnLeft;
                @Left.performed -= m_Wrapper.m_CharSelectActionsCallbackInterface.OnLeft;
                @Left.canceled -= m_Wrapper.m_CharSelectActionsCallbackInterface.OnLeft;
                @Right.started -= m_Wrapper.m_CharSelectActionsCallbackInterface.OnRight;
                @Right.performed -= m_Wrapper.m_CharSelectActionsCallbackInterface.OnRight;
                @Right.canceled -= m_Wrapper.m_CharSelectActionsCallbackInterface.OnRight;
            }
            m_Wrapper.m_CharSelectActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Select.started += instance.OnSelect;
                @Select.performed += instance.OnSelect;
                @Select.canceled += instance.OnSelect;
                @Left.started += instance.OnLeft;
                @Left.performed += instance.OnLeft;
                @Left.canceled += instance.OnLeft;
                @Right.started += instance.OnRight;
                @Right.performed += instance.OnRight;
                @Right.canceled += instance.OnRight;
            }
        }
    }
    public CharSelectActions @CharSelect => new CharSelectActions(this);
    private int m_Keyboard1SchemeIndex = -1;
    public InputControlScheme Keyboard1Scheme
    {
        get
        {
            if (m_Keyboard1SchemeIndex == -1) m_Keyboard1SchemeIndex = asset.FindControlSchemeIndex("Keyboard1");
            return asset.controlSchemes[m_Keyboard1SchemeIndex];
        }
    }
    private int m_Keyboard2SchemeIndex = -1;
    public InputControlScheme Keyboard2Scheme
    {
        get
        {
            if (m_Keyboard2SchemeIndex == -1) m_Keyboard2SchemeIndex = asset.FindControlSchemeIndex("Keyboard2");
            return asset.controlSchemes[m_Keyboard2SchemeIndex];
        }
    }
    private int m_Keyboard3SchemeIndex = -1;
    public InputControlScheme Keyboard3Scheme
    {
        get
        {
            if (m_Keyboard3SchemeIndex == -1) m_Keyboard3SchemeIndex = asset.FindControlSchemeIndex("Keyboard3");
            return asset.controlSchemes[m_Keyboard3SchemeIndex];
        }
    }
    private int m_Keyboard4SchemeIndex = -1;
    public InputControlScheme Keyboard4Scheme
    {
        get
        {
            if (m_Keyboard4SchemeIndex == -1) m_Keyboard4SchemeIndex = asset.FindControlSchemeIndex("Keyboard4");
            return asset.controlSchemes[m_Keyboard4SchemeIndex];
        }
    }
    public interface ICharSelectActions
    {
        void OnSelect(InputAction.CallbackContext context);
        void OnLeft(InputAction.CallbackContext context);
        void OnRight(InputAction.CallbackContext context);
    }
}
