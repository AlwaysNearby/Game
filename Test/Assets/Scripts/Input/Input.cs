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
            ""name"": ""Player"",
            ""id"": ""70e9f226-ff3d-4b79-8382-719a18090e2d"",
            ""actions"": [
                {
                    ""name"": ""ClickDown"",
                    ""type"": ""PassThrough"",
                    ""id"": ""2cbe7714-624f-403c-84f2-fc9ec6608dc3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ClickPosition"",
                    ""type"": ""Value"",
                    ""id"": ""02af0972-0f0c-4f91-b10b-c88af2451caf"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""74a5d35b-a69c-46eb-a2e1-f4acc0b561b8"",
                    ""path"": ""<Pointer>/press"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Mobile"",
                    ""action"": ""ClickDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""85427a0e-f75a-40d9-b2d3-d5d02b549b2e"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""ClickPosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
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
        },
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
        }
    ]
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_ClickDown = m_Player.FindAction("ClickDown", throwIfNotFound: true);
        m_Player_ClickPosition = m_Player.FindAction("ClickPosition", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_ClickDown;
    private readonly InputAction m_Player_ClickPosition;
    public struct PlayerActions
    {
        private @Input m_Wrapper;
        public PlayerActions(@Input wrapper) { m_Wrapper = wrapper; }
        public InputAction @ClickDown => m_Wrapper.m_Player_ClickDown;
        public InputAction @ClickPosition => m_Wrapper.m_Player_ClickPosition;
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
                @ClickPosition.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnClickPosition;
                @ClickPosition.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnClickPosition;
                @ClickPosition.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnClickPosition;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @ClickDown.started += instance.OnClickDown;
                @ClickDown.performed += instance.OnClickDown;
                @ClickDown.canceled += instance.OnClickDown;
                @ClickPosition.started += instance.OnClickPosition;
                @ClickPosition.performed += instance.OnClickPosition;
                @ClickPosition.canceled += instance.OnClickPosition;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    private int m_PCSchemeIndex = -1;
    public InputControlScheme PCScheme
    {
        get
        {
            if (m_PCSchemeIndex == -1) m_PCSchemeIndex = asset.FindControlSchemeIndex("PC");
            return asset.controlSchemes[m_PCSchemeIndex];
        }
    }
    private int m_MobileSchemeIndex = -1;
    public InputControlScheme MobileScheme
    {
        get
        {
            if (m_MobileSchemeIndex == -1) m_MobileSchemeIndex = asset.FindControlSchemeIndex("Mobile");
            return asset.controlSchemes[m_MobileSchemeIndex];
        }
    }
    public interface IPlayerActions
    {
        void OnClickDown(InputAction.CallbackContext context);
        void OnClickPosition(InputAction.CallbackContext context);
    }
}
