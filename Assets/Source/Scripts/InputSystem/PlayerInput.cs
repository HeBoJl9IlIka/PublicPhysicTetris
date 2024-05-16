//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/Source/InputSystem/PlayerInput.inputactions
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

public partial class @PlayerInput : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInput"",
    ""maps"": [
        {
            ""name"": ""PlayerOne"",
            ""id"": ""3dd5e31d-1a74-413c-9ffe-b9ee42a4107b"",
            ""actions"": [
                {
                    ""name"": ""MoveHorizontal"",
                    ""type"": ""Value"",
                    ""id"": ""52a9ed5c-eddc-42c8-b310-6b771804d86b"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""BoostHorizontal"",
                    ""type"": ""Value"",
                    ""id"": ""93c378ef-4184-4a7f-8df7-0e1a35c854aa"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": ""MultiTap(tapDelay=0.1)"",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""BoostVertical"",
                    ""type"": ""Button"",
                    ""id"": ""9c1313e5-90eb-4601-bc79-d27eee8b5e62"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": ""Invert"",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""RotateFigure"",
                    ""type"": ""Button"",
                    ""id"": ""39f5e7cd-370c-4ecb-b0f1-196214a6ff7e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""71768860-84ae-48f0-8e58-3c0e49c07a33"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""BoostVertical"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""535336f4-7351-4dad-a966-d585418e5525"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""RotateFigure"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""09fe8e82-b328-4092-81ab-f908cb35ff9f"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveHorizontal"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""829b26aa-275a-4dff-81c4-0527dd3a44fd"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""MoveHorizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""b1d1d0c5-b468-4009-86ff-3d7f1bfdbd32"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""MoveHorizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""c70acac4-a4c4-40f4-9851-2ec512245c7b"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""BoostHorizontal"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""c172831a-05f0-418a-931e-a882fa991e87"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""BoostHorizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""927aa51e-8e14-4bfa-9145-e949c60eb676"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""BoostHorizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
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
        // PlayerOne
        m_PlayerOne = asset.FindActionMap("PlayerOne", throwIfNotFound: true);
        m_PlayerOne_MoveHorizontal = m_PlayerOne.FindAction("MoveHorizontal", throwIfNotFound: true);
        m_PlayerOne_BoostHorizontal = m_PlayerOne.FindAction("BoostHorizontal", throwIfNotFound: true);
        m_PlayerOne_BoostVertical = m_PlayerOne.FindAction("BoostVertical", throwIfNotFound: true);
        m_PlayerOne_RotateFigure = m_PlayerOne.FindAction("RotateFigure", throwIfNotFound: true);
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

    // PlayerOne
    private readonly InputActionMap m_PlayerOne;
    private IPlayerOneActions m_PlayerOneActionsCallbackInterface;
    private readonly InputAction m_PlayerOne_MoveHorizontal;
    private readonly InputAction m_PlayerOne_BoostHorizontal;
    private readonly InputAction m_PlayerOne_BoostVertical;
    private readonly InputAction m_PlayerOne_RotateFigure;
    public struct PlayerOneActions
    {
        private @PlayerInput m_Wrapper;
        public PlayerOneActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @MoveHorizontal => m_Wrapper.m_PlayerOne_MoveHorizontal;
        public InputAction @BoostHorizontal => m_Wrapper.m_PlayerOne_BoostHorizontal;
        public InputAction @BoostVertical => m_Wrapper.m_PlayerOne_BoostVertical;
        public InputAction @RotateFigure => m_Wrapper.m_PlayerOne_RotateFigure;
        public InputActionMap Get() { return m_Wrapper.m_PlayerOne; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerOneActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerOneActions instance)
        {
            if (m_Wrapper.m_PlayerOneActionsCallbackInterface != null)
            {
                @MoveHorizontal.started -= m_Wrapper.m_PlayerOneActionsCallbackInterface.OnMoveHorizontal;
                @MoveHorizontal.performed -= m_Wrapper.m_PlayerOneActionsCallbackInterface.OnMoveHorizontal;
                @MoveHorizontal.canceled -= m_Wrapper.m_PlayerOneActionsCallbackInterface.OnMoveHorizontal;
                @BoostHorizontal.started -= m_Wrapper.m_PlayerOneActionsCallbackInterface.OnBoostHorizontal;
                @BoostHorizontal.performed -= m_Wrapper.m_PlayerOneActionsCallbackInterface.OnBoostHorizontal;
                @BoostHorizontal.canceled -= m_Wrapper.m_PlayerOneActionsCallbackInterface.OnBoostHorizontal;
                @BoostVertical.started -= m_Wrapper.m_PlayerOneActionsCallbackInterface.OnBoostVertical;
                @BoostVertical.performed -= m_Wrapper.m_PlayerOneActionsCallbackInterface.OnBoostVertical;
                @BoostVertical.canceled -= m_Wrapper.m_PlayerOneActionsCallbackInterface.OnBoostVertical;
                @RotateFigure.started -= m_Wrapper.m_PlayerOneActionsCallbackInterface.OnRotateFigure;
                @RotateFigure.performed -= m_Wrapper.m_PlayerOneActionsCallbackInterface.OnRotateFigure;
                @RotateFigure.canceled -= m_Wrapper.m_PlayerOneActionsCallbackInterface.OnRotateFigure;
            }
            m_Wrapper.m_PlayerOneActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MoveHorizontal.started += instance.OnMoveHorizontal;
                @MoveHorizontal.performed += instance.OnMoveHorizontal;
                @MoveHorizontal.canceled += instance.OnMoveHorizontal;
                @BoostHorizontal.started += instance.OnBoostHorizontal;
                @BoostHorizontal.performed += instance.OnBoostHorizontal;
                @BoostHorizontal.canceled += instance.OnBoostHorizontal;
                @BoostVertical.started += instance.OnBoostVertical;
                @BoostVertical.performed += instance.OnBoostVertical;
                @BoostVertical.canceled += instance.OnBoostVertical;
                @RotateFigure.started += instance.OnRotateFigure;
                @RotateFigure.performed += instance.OnRotateFigure;
                @RotateFigure.canceled += instance.OnRotateFigure;
            }
        }
    }
    public PlayerOneActions @PlayerOne => new PlayerOneActions(this);
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
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
    public interface IPlayerOneActions
    {
        void OnMoveHorizontal(InputAction.CallbackContext context);
        void OnBoostHorizontal(InputAction.CallbackContext context);
        void OnBoostVertical(InputAction.CallbackContext context);
        void OnRotateFigure(InputAction.CallbackContext context);
    }
}
