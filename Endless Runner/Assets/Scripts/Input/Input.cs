// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Input/Input.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Input : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Input()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Input"",
    ""maps"": [
        {
            ""name"": ""UI"",
            ""id"": ""2a530b88-9db3-4c14-8465-aa366b2df95e"",
            ""actions"": [
                {
                    ""name"": ""New action"",
                    ""type"": ""Button"",
                    ""id"": ""e7c6f4bb-ad40-41e9-86c0-5e315327df47"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""ad8ecce6-fe3d-4550-ad28-64d76aadb9b5"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""New action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Player"",
            ""id"": ""3ad5fe11-4c41-4e73-a3a4-f8808a11fce3"",
            ""actions"": [
                {
                    ""name"": ""ClickDown"",
                    ""type"": ""PassThrough"",
                    ""id"": ""8d1c9427-6998-4df9-bb1c-4e6d3170bf82"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ClickUp"",
                    ""type"": ""PassThrough"",
                    ""id"": ""10d2b895-27e7-40bc-b862-fd2dbf2b91ba"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ClickPostion"",
                    ""type"": ""Value"",
                    ""id"": ""f267d3de-b5a6-4175-bbcd-078160e4fc0f"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""e947148e-9f41-436e-a2c3-e496f9027138"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""ClickDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e674fdb2-afe3-43ec-acb7-d379a3e7e775"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""ClickUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6c9922a4-3098-4288-a0ea-82c53316a4c6"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""ClickPostion"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Mobile"",
            ""bindingGroup"": ""Mobile"",
            ""devices"": [
                {
                    ""devicePath"": ""<Touchscreen>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""PC"",
            ""bindingGroup"": ""PC"",
            ""devices"": [
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // UI
        m_UI = asset.FindActionMap("UI", throwIfNotFound: true);
        m_UI_Newaction = m_UI.FindAction("New action", throwIfNotFound: true);
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_ClickDown = m_Player.FindAction("ClickDown", throwIfNotFound: true);
        m_Player_ClickUp = m_Player.FindAction("ClickUp", throwIfNotFound: true);
        m_Player_ClickPostion = m_Player.FindAction("ClickPostion", throwIfNotFound: true);
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

    // UI
    private readonly InputActionMap m_UI;
    private IUIActions m_UIActionsCallbackInterface;
    private readonly InputAction m_UI_Newaction;
    public struct UIActions
    {
        private @Input m_Wrapper;
        public UIActions(@Input wrapper) { m_Wrapper = wrapper; }
        public InputAction @Newaction => m_Wrapper.m_UI_Newaction;
        public InputActionMap Get() { return m_Wrapper.m_UI; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIActions set) { return set.Get(); }
        public void SetCallbacks(IUIActions instance)
        {
            if (m_Wrapper.m_UIActionsCallbackInterface != null)
            {
                @Newaction.started -= m_Wrapper.m_UIActionsCallbackInterface.OnNewaction;
                @Newaction.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnNewaction;
                @Newaction.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnNewaction;
            }
            m_Wrapper.m_UIActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Newaction.started += instance.OnNewaction;
                @Newaction.performed += instance.OnNewaction;
                @Newaction.canceled += instance.OnNewaction;
            }
        }
    }
    public UIActions @UI => new UIActions(this);

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_ClickDown;
    private readonly InputAction m_Player_ClickUp;
    private readonly InputAction m_Player_ClickPostion;
    public struct PlayerActions
    {
        private @Input m_Wrapper;
        public PlayerActions(@Input wrapper) { m_Wrapper = wrapper; }
        public InputAction @ClickDown => m_Wrapper.m_Player_ClickDown;
        public InputAction @ClickUp => m_Wrapper.m_Player_ClickUp;
        public InputAction @ClickPostion => m_Wrapper.m_Player_ClickPostion;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @ClickDown.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnClickDown;
                @ClickDown.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnClickDown;
                @ClickDown.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnClickDown;
                @ClickUp.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnClickUp;
                @ClickUp.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnClickUp;
                @ClickUp.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnClickUp;
                @ClickPostion.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnClickPostion;
                @ClickPostion.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnClickPostion;
                @ClickPostion.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnClickPostion;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @ClickDown.started += instance.OnClickDown;
                @ClickDown.performed += instance.OnClickDown;
                @ClickDown.canceled += instance.OnClickDown;
                @ClickUp.started += instance.OnClickUp;
                @ClickUp.performed += instance.OnClickUp;
                @ClickUp.canceled += instance.OnClickUp;
                @ClickPostion.started += instance.OnClickPostion;
                @ClickPostion.performed += instance.OnClickPostion;
                @ClickPostion.canceled += instance.OnClickPostion;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    private int m_MobileSchemeIndex = -1;
    public InputControlScheme MobileScheme
    {
        get
        {
            if (m_MobileSchemeIndex == -1) m_MobileSchemeIndex = asset.FindControlSchemeIndex("Mobile");
            return asset.controlSchemes[m_MobileSchemeIndex];
        }
    }
    private int m_PCSchemeIndex = -1;
    public InputControlScheme PCScheme
    {
        get
        {
            if (m_PCSchemeIndex == -1) m_PCSchemeIndex = asset.FindControlSchemeIndex("PC");
            return asset.controlSchemes[m_PCSchemeIndex];
        }
    }
    public interface IUIActions
    {
        void OnNewaction(InputAction.CallbackContext context);
    }
    public interface IPlayerActions
    {
        void OnClickDown(InputAction.CallbackContext context);
        void OnClickUp(InputAction.CallbackContext context);
        void OnClickPostion(InputAction.CallbackContext context);
    }
}
