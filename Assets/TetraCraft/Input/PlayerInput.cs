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
                },
                {
                    ""name"": ""Boost"",
                    ""type"": ""Button"",
                    ""id"": ""9ce7ad44-6ece-4c28-a6cb-a2ff82a59bea"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Rotate"",
                    ""type"": ""Button"",
                    ""id"": ""7b9ecc38-e674-410e-bc62-14b6e4624773"",
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
                    ""groups"": ""Keyboard"",
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
                    ""groups"": ""Keyboard"",
                    ""action"": ""MoveLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c240fd6d-4462-4b1a-bc50-ad981eb16878"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Boost"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d7704821-ec99-4428-99df-0ad99972363d"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""410abaa5-68a5-4340-b3b5-bdc6e4354c02"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Rotate"",
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
        m_Tetramino_Boost = m_Tetramino.FindAction("Boost", throwIfNotFound: true);
        m_Tetramino_Rotate = m_Tetramino.FindAction("Rotate", throwIfNotFound: true);
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
    private readonly InputAction m_Tetramino_Boost;
    private readonly InputAction m_Tetramino_Rotate;
    public struct TetraminoActions
    {
        private @PlayerInput m_Wrapper;
        public TetraminoActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @MoveRight => m_Wrapper.m_Tetramino_MoveRight;
        public InputAction @MoveLeft => m_Wrapper.m_Tetramino_MoveLeft;
        public InputAction @Boost => m_Wrapper.m_Tetramino_Boost;
        public InputAction @Rotate => m_Wrapper.m_Tetramino_Rotate;
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
                @Boost.started -= m_Wrapper.m_TetraminoActionsCallbackInterface.OnBoost;
                @Boost.performed -= m_Wrapper.m_TetraminoActionsCallbackInterface.OnBoost;
                @Boost.canceled -= m_Wrapper.m_TetraminoActionsCallbackInterface.OnBoost;
                @Rotate.started -= m_Wrapper.m_TetraminoActionsCallbackInterface.OnRotate;
                @Rotate.performed -= m_Wrapper.m_TetraminoActionsCallbackInterface.OnRotate;
                @Rotate.canceled -= m_Wrapper.m_TetraminoActionsCallbackInterface.OnRotate;
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
                @Boost.started += instance.OnBoost;
                @Boost.performed += instance.OnBoost;
                @Boost.canceled += instance.OnBoost;
                @Rotate.started += instance.OnRotate;
                @Rotate.performed += instance.OnRotate;
                @Rotate.canceled += instance.OnRotate;
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
        void OnBoost(InputAction.CallbackContext context);
        void OnRotate(InputAction.CallbackContext context);
    }
}
