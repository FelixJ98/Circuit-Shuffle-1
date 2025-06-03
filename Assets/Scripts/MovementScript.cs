using UnityEngine;
using UnityEngine.InputSystem;
using StarterAssets;

public class ControllerInputExample : MonoBehaviour
{

    public StarterAssetsInputs sai;
    void Update()
    {

        // Button press - Jump
        if (OVRInput.Get(OVRInput.Button.One, OVRInput.Controller.RTouch))
        {
            sai.OnJump(true);
            //Debug.Log("A button pressed");
        }
        else
        {
            sai.OnJump(false);
        }

        // Thumbstick - Move
        Vector2 thumbstick = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);
        if (thumbstick.magnitude > 0.5f)
        {
            //Debug.Log($"Thumbstick: {thumbstick}");
            sai.OnMove(thumbstick);
        }
        else
        {
            sai.OnMove(Vector2.zero);
        }

        // Trigger - Sprint
        float triggerValue = OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger);
        if (triggerValue > 0.1f)
        {
            //Debug.Log($"Trigger: {triggerValue}");
            sai.OnSprint(true);
        }
        else
        {
            sai.OnSprint(false);

        }

         //Controller position and rotation
        Vector3 position = OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTouch);
        //Debug.Log($"ControllerPosition: {position}");

        Quaternion rotation = OVRInput.GetLocalControllerRotation(OVRInput.Controller.RTouch);
        //Debug.Log($"ControllerRotation: {rotation}");
    }
}
