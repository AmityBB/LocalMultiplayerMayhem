using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;

public class VirtualCursorUI : MonoBehaviour
{
    

    public static VirtualCursorUI instance {  get; private set; }

    [SerializeField] private RectTransform virtualMouse;
    [SerializeField] private RectTransform canvasRectTransform;

    private VirtualMouseInput virtualMouseInput;


    private bool MouseMove;
    private Vector2 CurrentMouse;



    private void Awake()
    {
        instance = this;

        virtualMouseInput = GetComponent<VirtualMouseInput>();

        
    }


    private void Start()
    {
        Test.Instance.OnGameDeviceChanged += Test_OnGameDeviceChanged;
        UpdateVisibility();
    }

    private void Test_OnGameDeviceChanged(object sender, System.EventArgs e)
    {
        UpdateVisibility();
    }

    private void UpdateVisibility()
    {
        if (Test.Instance.GetActiveGameDevice() == Test.GameDevice.Gamepad)
        {
            Debug.Log("Controller");
        }
        else { Debug.Log("Keyboard"); }
    }

    private void Update()
    {
        transform.localScale = Vector3.one * (1f / canvasRectTransform.localScale.x);
        transform.SetAsLastSibling();
        CurrentMouse = Mouse.current.position.ReadValue();
        /*if (!MouseMove)
        { 
            Mouse.current.WarpCursorPosition(this.transform.position);
        }
        else
        {
            this.transform.position = CurrentMouse;
        }*/
    }
}
