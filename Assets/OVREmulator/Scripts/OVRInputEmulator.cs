#if UNITY_EDITOR
using UnityEngine;

public class OVRInputEmulator
{
    public static GvrControllerInputDevice InputDevice { get { return GvrControllerInput.GetDevice(GvrControllerHand.Dominant); } }
    public static bool IsControllerConnected(OVRInput.Controller controllerMask)
    { return controllerMask == OVREmulatorSetting.ConnectedController; }
    public static Quaternion GetLocalControllerRotation(OVRInput.Controller controllerMask) { return InputDevice.Orientation; }
    public static Vector3 GetLocalControllerPosition(OVRInput.Controller controllerMask) { return InputDevice.Position; }
    public static Vector2 Get(OVRInput.Axis2D virtualMask, OVRInput.Controller controllerMask = OVRInput.Controller.Active) { return InputDevice.TouchPos; }
    public static bool GetControllerWasRecentered(OVRInput.Controller controllerMask = OVRInput.Controller.Active) { return InputDevice.Recentered; }
    public static bool Get(OVRInput.Touch virtualMask, OVRInput.Controller controllerMask = OVRInput.Controller.Active) { return InputDevice.GetButton(GvrControllerButton.TouchPadTouch); }
    public static bool GetDown(OVRInput.Touch virtualMask, OVRInput.Controller controllerMask = OVRInput.Controller.Active) { return InputDevice.GetButtonDown(GvrControllerButton.TouchPadTouch); }
    public static bool GetUp(OVRInput.Touch virtualMask, OVRInput.Controller controllerMask = OVRInput.Controller.Active) { return InputDevice.GetButtonUp(GvrControllerButton.TouchPadTouch); }
    public static bool Get(OVRInput.Button virtualMask, OVRInput.Controller controllerMask = OVRInput.Controller.Active) { return InputDevice.GetButton(GvrControllerButton.TouchPadButton); }
    public static bool GetDown(OVRInput.Button virtualMask, OVRInput.Controller controllerMask = OVRInput.Controller.Active) { return InputDevice.GetButtonDown(GvrControllerButton.TouchPadButton); }
    public static bool GetUp(OVRInput.Button virtualMask, OVRInput.Controller controllerMask = OVRInput.Controller.Active) { return InputDevice.GetButtonUp(GvrControllerButton.TouchPadButton); }
    public static bool Get(OVRInput.RawButton virtualMask, OVRInput.Controller controllerMask = OVRInput.Controller.Active) { return virtualMask == OVRInput.RawButton.Back ? InputDevice.GetButton(GvrControllerButton.App) : false; }
    public static bool GetDown(OVRInput.RawButton virtualMask, OVRInput.Controller controllerMask = OVRInput.Controller.Active) { return virtualMask == OVRInput.RawButton.Back ? InputDevice.GetButtonDown(GvrControllerButton.App) : false; }
    public static bool GetUp(OVRInput.RawButton virtualMask, OVRInput.Controller controllerMask = OVRInput.Controller.Active) { return virtualMask == OVRInput.RawButton.Back ? InputDevice.GetButtonUp(GvrControllerButton.App) : false; }
}
#endif