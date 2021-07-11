// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/InputSystem/InputSystem.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputSystem : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputSystem()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputSystem"",
    ""maps"": [
        {
            ""name"": ""UI"",
            ""id"": ""5950aad2-8e5b-40c8-ae25-3031a3cf1dab"",
            ""actions"": [
                {
                    ""name"": ""Point"",
                    ""type"": ""PassThrough"",
                    ""id"": ""d313ad2b-1b4e-430c-bab5-01a64626d32b"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LeftClick"",
                    ""type"": ""PassThrough"",
                    ""id"": ""e79956ea-6c7b-4157-9f92-6cfacf4138d9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Scroll"",
                    ""type"": ""Value"",
                    ""id"": ""6efca2ac-af37-43f6-b51e-82d4654b2978"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""b56ab2ca-e896-453f-bb10-077d2304d3dc"",
                    ""path"": ""<Touchscreen>/touch*/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""TouchScreen"",
                    ""action"": ""Point"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e4f16616-d4a1-45d4-9f67-e41381c5c8d0"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MouseAndKeyBoard"",
                    ""action"": ""Point"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7556cfa0-e96a-42bd-bcec-8e315a1e917a"",
                    ""path"": ""<Touchscreen>/touch*/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""TouchScreen"",
                    ""action"": ""LeftClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a75386fa-cd2f-49ea-8991-91aabfc25301"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MouseAndKeyBoard"",
                    ""action"": ""LeftClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e9f19c79-b48a-4a45-a295-93aa87cc6c93"",
                    ""path"": ""<Mouse>/scroll"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MouseAndKeyBoard"",
                    ""action"": ""Scroll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b4f638d3-b17c-4372-acf2-604df12bfc5c"",
                    ""path"": ""<Touchscreen>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""TouchScreen"",
                    ""action"": ""Scroll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""InputPlayer"",
            ""id"": ""638444b2-dbb4-4686-97f7-13b16e0cbd9d"",
            ""actions"": [
                {
                    ""name"": ""Click"",
                    ""type"": ""Value"",
                    ""id"": ""a6a0dc80-e7b9-4388-8fd3-1f19832ddfc5"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ClickDown"",
                    ""type"": ""PassThrough"",
                    ""id"": ""a266f93b-5df9-43e3-bd73-253a0cf9d52a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ClickRelease"",
                    ""type"": ""PassThrough"",
                    ""id"": ""b623b8d7-7181-4367-9282-fdba455ea8e7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""212769cc-40cb-41e0-a519-00784ea359b4"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MouseAndKeyBoard"",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e61b4177-3b1e-4a2c-a2a0-801439f23c32"",
                    ""path"": ""<Touchscreen>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""TouchScreen"",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7c2a947e-56d4-4139-9827-6bfffafcf45b"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": ""MouseAndKeyBoard"",
                    ""action"": ""ClickDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8ea63840-e785-4972-aaaa-66a0b04747ca"",
                    ""path"": ""<Touchscreen>/press"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": ""TouchScreen"",
                    ""action"": ""ClickDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cc06c537-c5e3-49ab-8d2e-b2dac3cb9927"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Press(behavior=2)"",
                    ""processors"": """",
                    ""groups"": ""MouseAndKeyBoard"",
                    ""action"": ""ClickRelease"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""TouchScreen"",
            ""bindingGroup"": ""TouchScreen"",
            ""devices"": [
                {
                    ""devicePath"": ""<Touchscreen>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""MouseAndKeyBoard"",
            ""bindingGroup"": ""MouseAndKeyBoard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // UI
        m_UI = asset.FindActionMap("UI", throwIfNotFound: true);
        m_UI_Point = m_UI.FindAction("Point", throwIfNotFound: true);
        m_UI_LeftClick = m_UI.FindAction("LeftClick", throwIfNotFound: true);
        m_UI_Scroll = m_UI.FindAction("Scroll", throwIfNotFound: true);
        // InputPlayer
        m_InputPlayer = asset.FindActionMap("InputPlayer", throwIfNotFound: true);
        m_InputPlayer_Click = m_InputPlayer.FindAction("Click", throwIfNotFound: true);
        m_InputPlayer_ClickDown = m_InputPlayer.FindAction("ClickDown", throwIfNotFound: true);
        m_InputPlayer_ClickRelease = m_InputPlayer.FindAction("ClickRelease", throwIfNotFound: true);
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
    private readonly InputAction m_UI_Point;
    private readonly InputAction m_UI_LeftClick;
    private readonly InputAction m_UI_Scroll;
    public struct UIActions
    {
        private @InputSystem m_Wrapper;
        public UIActions(@InputSystem wrapper) { m_Wrapper = wrapper; }
        public InputAction @Point => m_Wrapper.m_UI_Point;
        public InputAction @LeftClick => m_Wrapper.m_UI_LeftClick;
        public InputAction @Scroll => m_Wrapper.m_UI_Scroll;
        public InputActionMap Get() { return m_Wrapper.m_UI; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIActions set) { return set.Get(); }
        public void SetCallbacks(IUIActions instance)
        {
            if (m_Wrapper.m_UIActionsCallbackInterface != null)
            {
                @Point.started -= m_Wrapper.m_UIActionsCallbackInterface.OnPoint;
                @Point.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnPoint;
                @Point.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnPoint;
                @LeftClick.started -= m_Wrapper.m_UIActionsCallbackInterface.OnLeftClick;
                @LeftClick.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnLeftClick;
                @LeftClick.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnLeftClick;
                @Scroll.started -= m_Wrapper.m_UIActionsCallbackInterface.OnScroll;
                @Scroll.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnScroll;
                @Scroll.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnScroll;
            }
            m_Wrapper.m_UIActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Point.started += instance.OnPoint;
                @Point.performed += instance.OnPoint;
                @Point.canceled += instance.OnPoint;
                @LeftClick.started += instance.OnLeftClick;
                @LeftClick.performed += instance.OnLeftClick;
                @LeftClick.canceled += instance.OnLeftClick;
                @Scroll.started += instance.OnScroll;
                @Scroll.performed += instance.OnScroll;
                @Scroll.canceled += instance.OnScroll;
            }
        }
    }
    public UIActions @UI => new UIActions(this);

    // InputPlayer
    private readonly InputActionMap m_InputPlayer;
    private IInputPlayerActions m_InputPlayerActionsCallbackInterface;
    private readonly InputAction m_InputPlayer_Click;
    private readonly InputAction m_InputPlayer_ClickDown;
    private readonly InputAction m_InputPlayer_ClickRelease;
    public struct InputPlayerActions
    {
        private @InputSystem m_Wrapper;
        public InputPlayerActions(@InputSystem wrapper) { m_Wrapper = wrapper; }
        public InputAction @Click => m_Wrapper.m_InputPlayer_Click;
        public InputAction @ClickDown
        {
            get => m_Wrapper.m_InputPlayer_ClickDown;
            set => throw new NotImplementedException();
        }

        public InputAction @ClickRelease => m_Wrapper.m_InputPlayer_ClickRelease;
        public InputActionMap Get() { return m_Wrapper.m_InputPlayer; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(InputPlayerActions set) { return set.Get(); }
        public void SetCallbacks(IInputPlayerActions instance)
        {
            if (m_Wrapper.m_InputPlayerActionsCallbackInterface != null)
            {
                @Click.started -= m_Wrapper.m_InputPlayerActionsCallbackInterface.OnClick;
                @Click.performed -= m_Wrapper.m_InputPlayerActionsCallbackInterface.OnClick;
                @Click.canceled -= m_Wrapper.m_InputPlayerActionsCallbackInterface.OnClick;
                @ClickDown.started -= m_Wrapper.m_InputPlayerActionsCallbackInterface.OnClickDown;
                @ClickDown.performed -= m_Wrapper.m_InputPlayerActionsCallbackInterface.OnClickDown;
                @ClickDown.canceled -= m_Wrapper.m_InputPlayerActionsCallbackInterface.OnClickDown;
                @ClickRelease.started -= m_Wrapper.m_InputPlayerActionsCallbackInterface.OnClickRelease;
                @ClickRelease.performed -= m_Wrapper.m_InputPlayerActionsCallbackInterface.OnClickRelease;
                @ClickRelease.canceled -= m_Wrapper.m_InputPlayerActionsCallbackInterface.OnClickRelease;
            }
            m_Wrapper.m_InputPlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Click.started += instance.OnClick;
                @Click.performed += instance.OnClick;
                @Click.canceled += instance.OnClick;
                @ClickDown.started += instance.OnClickDown;
                @ClickDown.performed += instance.OnClickDown;
                @ClickDown.canceled += instance.OnClickDown;
                @ClickRelease.started += instance.OnClickRelease;
                @ClickRelease.performed += instance.OnClickRelease;
                @ClickRelease.canceled += instance.OnClickRelease;
            }
        }
    }
    public InputPlayerActions @InputPlayer => new InputPlayerActions(this);
    private int m_TouchScreenSchemeIndex = -1;
    public InputControlScheme TouchScreenScheme
    {
        get
        {
            if (m_TouchScreenSchemeIndex == -1) m_TouchScreenSchemeIndex = asset.FindControlSchemeIndex("TouchScreen");
            return asset.controlSchemes[m_TouchScreenSchemeIndex];
        }
    }
    private int m_MouseAndKeyBoardSchemeIndex = -1;
    public InputControlScheme MouseAndKeyBoardScheme
    {
        get
        {
            if (m_MouseAndKeyBoardSchemeIndex == -1) m_MouseAndKeyBoardSchemeIndex = asset.FindControlSchemeIndex("MouseAndKeyBoard");
            return asset.controlSchemes[m_MouseAndKeyBoardSchemeIndex];
        }
    }
    public interface IUIActions
    {
        void OnPoint(InputAction.CallbackContext context);
        void OnLeftClick(InputAction.CallbackContext context);
        void OnScroll(InputAction.CallbackContext context);
    }
    public interface IInputPlayerActions
    {
        void OnClick(InputAction.CallbackContext context);
        void OnClickDown(InputAction.CallbackContext context);
        void OnClickRelease(InputAction.CallbackContext context);
    }
}
