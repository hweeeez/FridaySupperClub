// GENERATED AUTOMATICALLY FROM 'Assets/02_Scripts/03_CursorController/Player1.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @AutoGen : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @AutoGen()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Player1"",
    ""maps"": [
        {
            ""name"": ""Player1"",
            ""id"": ""1146303f-91ad-4efc-a250-5ac347c897f2"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""0c06fc2e-c03d-4182-b45e-c3a7a2f3ef69"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": ""Press,MultiTap""
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""a2867a95-5af3-4462-8a36-ddc81a7ab9ea"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Select"",
                    ""type"": ""Button"",
                    ""id"": ""1daf9279-5b96-427a-800e-636da4e65806"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Slam"",
                    ""type"": ""Button"",
                    ""id"": ""6f974148-8a7b-4ca8-b5c7-643429069806"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Dash WASD"",
                    ""type"": ""PassThrough"",
                    ""id"": ""8fb2e689-e0ef-4258-aeec-4bedcfefb93f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Dash  Arrows"",
                    ""type"": ""PassThrough"",
                    ""id"": ""8211506b-88bd-4fa0-825e-5bd252ce81fb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Dash  5123"",
                    ""type"": ""PassThrough"",
                    ""id"": ""16705aac-8f06-43dc-8a7e-87253f2f8a85"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Dash  IJKL"",
                    ""type"": ""PassThrough"",
                    ""id"": ""de23f853-6d68-4325-a564-62b75ea33be3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MouseClick"",
                    ""type"": ""Button"",
                    ""id"": ""404c1e98-15d8-4f99-804d-fdfcb7a09077"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)""
                },
                {
                    ""name"": ""MousePosition"",
                    ""type"": ""PassThrough"",
                    ""id"": ""2f5b79bb-e1de-47ec-b7c9-3d3f599653bf"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)""
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""29bcfc81-f714-4710-a748-5645c3bc5308"",
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
                    ""id"": ""5dcaeac5-42b8-418a-8b17-031460e0d84a"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""711ca3cb-5602-4669-b2f9-e2c87adbb99f"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard1"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""5d1a56e5-b804-4b4f-85e4-d580f16ec214"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard1"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""c7d6bf21-4c91-4f03-a68b-69b800b22785"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard1"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Arrow"",
                    ""id"": ""3e13e8f5-bc5a-4d57-89c5-d352686f22ea"",
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
                    ""id"": ""5980b25c-feb0-494b-beba-061dbb859fa8"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard2"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""99f20de2-6254-48fd-9340-67176e6f67fb"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard2"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""ad9c62ca-1592-447f-9784-039b5aad253b"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard2"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""e8843e66-8d31-4f11-b9e7-bb692adb2568"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard2"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""5123"",
                    ""id"": ""82c36372-1da5-40fd-a132-84dcd0b8d95d"",
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
                    ""id"": ""8ad2ade2-a6c1-4ff8-a277-01080202bd48"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""73a8bbe3-1ef7-471a-a845-8c9f4eb1b4ed"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""4a7fc0c4-5690-44a2-b765-6cdcd4002974"",
                    ""path"": ""<Keyboard>/numpad1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard3"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""52605e2a-716c-422c-b11f-6c65f540246c"",
                    ""path"": ""<Keyboard>/numpad3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard3"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""IJKL"",
                    ""id"": ""93351ffe-e266-4265-83ae-e8202dddce4d"",
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
                    ""id"": ""4058ab79-7245-4f0b-90b9-fb2b2e644019"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard4"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""87ddc5b3-e5a8-4d8b-81ee-6eb7c75ffed2"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard4"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""640a0ca4-b2dc-4d4a-91d9-8e8c01ede894"",
                    ""path"": ""<Keyboard>/j"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard4"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""cf37d46e-947d-4814-aacc-a7bbb1ecac71"",
                    ""path"": ""<Keyboard>/l"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard4"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""0c580f56-1c31-4853-9e04-ffd255b9f206"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard1"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7b4caffc-fe07-46a3-8140-e2406532749d"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard2"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""06f61648-cf27-4fd0-af99-8ab82b7797b6"",
                    ""path"": ""<Keyboard>/numpad5"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard3"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2d4250fc-8f37-430a-9793-3355d87041c7"",
                    ""path"": ""<Keyboard>/i"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard4"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0c791220-4282-43f4-b061-133b094f326f"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""55acbf41-9f96-475c-9557-307ea61d59af"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard1"",
                    ""action"": ""Slam"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a8317d1a-c3b5-4757-b1f7-6688e237dffb"",
                    ""path"": ""<Keyboard>/k"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard4"",
                    ""action"": ""Slam"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""be2ecec3-48b7-475b-97d8-8a956eca6142"",
                    ""path"": ""<Keyboard>/numpad2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard2;Keyboard3"",
                    ""action"": ""Slam"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5bec7fbe-de2f-41a6-bcb4-1407b554b6ca"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard2"",
                    ""action"": ""Slam"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD 1D Axis"",
                    ""id"": ""7d04780d-ae36-404a-a9b2-613d88186b13"",
                    ""path"": ""1DAxis"",
                    ""interactions"": ""MultiTap(tapCount=1)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash WASD"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""7eea532f-bad8-4475-8a76-3ee50b367438"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard1"",
                    ""action"": ""Dash WASD"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""ff3cdecf-936b-476c-b21c-b4a9198578a5"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard1"",
                    ""action"": ""Dash WASD"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Arrows 1D Axis"",
                    ""id"": ""13c4d73e-17e5-466c-b586-247dce1b721c"",
                    ""path"": ""1DAxis"",
                    ""interactions"": ""MultiTap(tapCount=1)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash  Arrows"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""94d697b3-3491-4178-bc85-a921d40b2a60"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard2"",
                    ""action"": ""Dash  Arrows"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""345d6819-0c88-4efa-a0e1-094cf2757264"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard2"",
                    ""action"": ""Dash  Arrows"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""5123 1D Axis"",
                    ""id"": ""c3c7b42e-8732-4fc6-bf25-bdc624da42a8"",
                    ""path"": ""1DAxis"",
                    ""interactions"": ""MultiTap(tapCount=1)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash  5123"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""9a8e15e1-9b50-4637-9aca-49e32af800ec"",
                    ""path"": ""<Keyboard>/numpad1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard3"",
                    ""action"": ""Dash  5123"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""88da2fb3-660d-439a-a620-f5aadabfd5ce"",
                    ""path"": ""<Keyboard>/numpad3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard3"",
                    ""action"": ""Dash  5123"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""IJKL 1D Axis"",
                    ""id"": ""c8f8605f-95fe-46f7-931e-97fbdfee26ad"",
                    ""path"": ""1DAxis"",
                    ""interactions"": ""MultiTap(tapCount=1)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash  IJKL"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""9063975b-1214-453f-b33e-cce7433dbe0c"",
                    ""path"": ""<Keyboard>/j"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard4"",
                    ""action"": ""Dash  IJKL"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""bf690181-e2c7-49f1-bcc9-ac2b14efa950"",
                    ""path"": ""<Keyboard>/l"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard4"",
                    ""action"": ""Dash  IJKL"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""1d0cedc4-e8bf-47f6-b6b1-dfe217f8c2ed"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""257e0faa-8f3d-4617-8d60-55b5b96e9588"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MousePosition"",
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
        // Player1
        m_Player1 = asset.FindActionMap("Player1", throwIfNotFound: true);
        m_Player1_Movement = m_Player1.FindAction("Movement", throwIfNotFound: true);
        m_Player1_Jump = m_Player1.FindAction("Jump", throwIfNotFound: true);
        m_Player1_Select = m_Player1.FindAction("Select", throwIfNotFound: true);
        m_Player1_Slam = m_Player1.FindAction("Slam", throwIfNotFound: true);
        m_Player1_DashWASD = m_Player1.FindAction("Dash WASD", throwIfNotFound: true);
        m_Player1_DashArrows = m_Player1.FindAction("Dash  Arrows", throwIfNotFound: true);
        m_Player1_Dash5123 = m_Player1.FindAction("Dash  5123", throwIfNotFound: true);
        m_Player1_DashIJKL = m_Player1.FindAction("Dash  IJKL", throwIfNotFound: true);
        m_Player1_MouseClick = m_Player1.FindAction("MouseClick", throwIfNotFound: true);
        m_Player1_MousePosition = m_Player1.FindAction("MousePosition", throwIfNotFound: true);
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

    // Player1
    private readonly InputActionMap m_Player1;
    private IPlayer1Actions m_Player1ActionsCallbackInterface;
    private readonly InputAction m_Player1_Movement;
    private readonly InputAction m_Player1_Jump;
    private readonly InputAction m_Player1_Select;
    private readonly InputAction m_Player1_Slam;
    private readonly InputAction m_Player1_DashWASD;
    private readonly InputAction m_Player1_DashArrows;
    private readonly InputAction m_Player1_Dash5123;
    private readonly InputAction m_Player1_DashIJKL;
    private readonly InputAction m_Player1_MouseClick;
    private readonly InputAction m_Player1_MousePosition;
    public struct Player1Actions
    {
        private @AutoGen m_Wrapper;
        public Player1Actions(@AutoGen wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Player1_Movement;
        public InputAction @Jump => m_Wrapper.m_Player1_Jump;
        public InputAction @Select => m_Wrapper.m_Player1_Select;
        public InputAction @Slam => m_Wrapper.m_Player1_Slam;
        public InputAction @DashWASD => m_Wrapper.m_Player1_DashWASD;
        public InputAction @DashArrows => m_Wrapper.m_Player1_DashArrows;
        public InputAction @Dash5123 => m_Wrapper.m_Player1_Dash5123;
        public InputAction @DashIJKL => m_Wrapper.m_Player1_DashIJKL;
        public InputAction @MouseClick => m_Wrapper.m_Player1_MouseClick;
        public InputAction @MousePosition => m_Wrapper.m_Player1_MousePosition;
        public InputActionMap Get() { return m_Wrapper.m_Player1; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(Player1Actions set) { return set.Get(); }
        public void SetCallbacks(IPlayer1Actions instance)
        {
            if (m_Wrapper.m_Player1ActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_Player1ActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_Player1ActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_Player1ActionsCallbackInterface.OnMovement;
                @Jump.started -= m_Wrapper.m_Player1ActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_Player1ActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_Player1ActionsCallbackInterface.OnJump;
                @Select.started -= m_Wrapper.m_Player1ActionsCallbackInterface.OnSelect;
                @Select.performed -= m_Wrapper.m_Player1ActionsCallbackInterface.OnSelect;
                @Select.canceled -= m_Wrapper.m_Player1ActionsCallbackInterface.OnSelect;
                @Slam.started -= m_Wrapper.m_Player1ActionsCallbackInterface.OnSlam;
                @Slam.performed -= m_Wrapper.m_Player1ActionsCallbackInterface.OnSlam;
                @Slam.canceled -= m_Wrapper.m_Player1ActionsCallbackInterface.OnSlam;
                @DashWASD.started -= m_Wrapper.m_Player1ActionsCallbackInterface.OnDashWASD;
                @DashWASD.performed -= m_Wrapper.m_Player1ActionsCallbackInterface.OnDashWASD;
                @DashWASD.canceled -= m_Wrapper.m_Player1ActionsCallbackInterface.OnDashWASD;
                @DashArrows.started -= m_Wrapper.m_Player1ActionsCallbackInterface.OnDashArrows;
                @DashArrows.performed -= m_Wrapper.m_Player1ActionsCallbackInterface.OnDashArrows;
                @DashArrows.canceled -= m_Wrapper.m_Player1ActionsCallbackInterface.OnDashArrows;
                @Dash5123.started -= m_Wrapper.m_Player1ActionsCallbackInterface.OnDash5123;
                @Dash5123.performed -= m_Wrapper.m_Player1ActionsCallbackInterface.OnDash5123;
                @Dash5123.canceled -= m_Wrapper.m_Player1ActionsCallbackInterface.OnDash5123;
                @DashIJKL.started -= m_Wrapper.m_Player1ActionsCallbackInterface.OnDashIJKL;
                @DashIJKL.performed -= m_Wrapper.m_Player1ActionsCallbackInterface.OnDashIJKL;
                @DashIJKL.canceled -= m_Wrapper.m_Player1ActionsCallbackInterface.OnDashIJKL;
                @MouseClick.started -= m_Wrapper.m_Player1ActionsCallbackInterface.OnMouseClick;
                @MouseClick.performed -= m_Wrapper.m_Player1ActionsCallbackInterface.OnMouseClick;
                @MouseClick.canceled -= m_Wrapper.m_Player1ActionsCallbackInterface.OnMouseClick;
                @MousePosition.started -= m_Wrapper.m_Player1ActionsCallbackInterface.OnMousePosition;
                @MousePosition.performed -= m_Wrapper.m_Player1ActionsCallbackInterface.OnMousePosition;
                @MousePosition.canceled -= m_Wrapper.m_Player1ActionsCallbackInterface.OnMousePosition;
            }
            m_Wrapper.m_Player1ActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Select.started += instance.OnSelect;
                @Select.performed += instance.OnSelect;
                @Select.canceled += instance.OnSelect;
                @Slam.started += instance.OnSlam;
                @Slam.performed += instance.OnSlam;
                @Slam.canceled += instance.OnSlam;
                @DashWASD.started += instance.OnDashWASD;
                @DashWASD.performed += instance.OnDashWASD;
                @DashWASD.canceled += instance.OnDashWASD;
                @DashArrows.started += instance.OnDashArrows;
                @DashArrows.performed += instance.OnDashArrows;
                @DashArrows.canceled += instance.OnDashArrows;
                @Dash5123.started += instance.OnDash5123;
                @Dash5123.performed += instance.OnDash5123;
                @Dash5123.canceled += instance.OnDash5123;
                @DashIJKL.started += instance.OnDashIJKL;
                @DashIJKL.performed += instance.OnDashIJKL;
                @DashIJKL.canceled += instance.OnDashIJKL;
                @MouseClick.started += instance.OnMouseClick;
                @MouseClick.performed += instance.OnMouseClick;
                @MouseClick.canceled += instance.OnMouseClick;
                @MousePosition.started += instance.OnMousePosition;
                @MousePosition.performed += instance.OnMousePosition;
                @MousePosition.canceled += instance.OnMousePosition;
            }
        }
    }
    public Player1Actions @Player1 => new Player1Actions(this);
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
    public interface IPlayer1Actions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnSelect(InputAction.CallbackContext context);
        void OnSlam(InputAction.CallbackContext context);
        void OnDashWASD(InputAction.CallbackContext context);
        void OnDashArrows(InputAction.CallbackContext context);
        void OnDash5123(InputAction.CallbackContext context);
        void OnDashIJKL(InputAction.CallbackContext context);
        void OnMouseClick(InputAction.CallbackContext context);
        void OnMousePosition(InputAction.CallbackContext context);
    }
}
