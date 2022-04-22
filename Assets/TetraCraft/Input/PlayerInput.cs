// GENERATED AUTOMATICALLY FROM 'Assets/TetraCraft/Input/PlayerInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerInput : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInput"",
    ""maps"": [
        {
            ""name"": ""Tetramino"",
            ""id"": ""2a711d0c-b31c-4b35-8655-8b6e5acd136f"",
            ""actions"": [
                {
                    ""name"": ""Move Right"",
                    ""type"": ""Button"",
                    ""id"": ""2e788c82-80eb-45ad-89fe-6d23798a4327"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MoveLeft"",
                    ""type"": ""Button"",
                    ""id"": ""2f5f4caf-3928-48c9-836c-d4f1d94fafea"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""69f710a9-574d-48d7-b705-4b7dd5a77a64"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ddc43e3b-0ed7-4751-9f78-390ae2f1870c"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
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
                    ""isOptional"": true,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": true,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Tetramino
        m_Tetramino = asset.FindActionMap("Tetramino", throwIfNotFound: true);
        m_Tetramino_MoveRight = m_Tetramino.FindAction("Move Right", throwIfNotFound: true);
        m_Tetramino_MoveLeft = m_Tetramino.FindAction("MoveLeft", throwIfNotFound: true);
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

    // Tetramino
    private readonly InputActionMap m_Tetramino;
    private ITetraminoActions m_TetraminoActionsCallbackInterface;
    private readonly InputAction m_Tetramino_MoveRight;
    private readonly InputAction m_Tetramino_MoveLeft;
    public struct TetraminoActions
    {
        private @PlayerInput m_Wrapper;
        public TetraminoActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @MoveRight => m_Wrapper.m_Tetramino_MoveRight;
        public InputAction @MoveLeft => m_Wrapper.m_Tetramino_MoveLeft;
        public InputActionMap Get() { return m_Wrapper.m_Tetramino; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(TetraminoActions set) { return set.Get(); }
        public void SetCallbacks(ITetraminoActions instance)
        {
            if (m_Wrapper.m_TetraminoActionsCallbackInterface != null)
            {
                @MoveRight.started -= m_Wrapper.m_TetraminoActionsCallbackInterface.OnMoveRight;
                @MoveRight.performed -= m_Wrapper.m_TetraminoActionsCallbackInterface.OnMoveRight;
                @MoveRight.canceled -= m_Wrapper.m_TetraminoActionsCallbackInterface.OnMoveRight;
                @MoveLeft.started -= m_Wrapper.m_TetraminoActionsCallbackInterface.OnMoveLeft;
                @MoveLeft.performed -= m_Wrapper.m_TetraminoActionsCallbackInterface.OnMoveLeft;
                @MoveLeft.canceled -= m_Wrapper.m_TetraminoActionsCallbackInterface.OnMoveLeft;
            }
            m_Wrapper.m_TetraminoActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MoveRight.started += instance.OnMoveRight;
                @MoveRight.performed += instance.OnMoveRight;
                @MoveRight.canceled += instance.OnMoveRight;
                @MoveLeft.started += instance.OnMoveLeft;
                @MoveLeft.performed += instance.OnMoveLeft;
                @MoveLeft.canceled += instance.OnMoveLeft;
            }
        }
    }
    public TetraminoActions @Tetramino => new TetraminoActions(this);
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    public interface ITetraminoActions
    {
        void OnMoveRight(InputAction.CallbackContext context);
        void OnMoveLeft(InputAction.CallbackContext context);
    }
}
