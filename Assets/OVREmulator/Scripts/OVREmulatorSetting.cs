using UnityEngine;

public class OVREmulatorSetting : MonoBehaviour
{
#if UNITY_EDITOR
    public OVRInput.Controller connectedController = OVRInput.Controller.RTrackedRemote;
    public static OVREmulatorSetting GetInstance() { return FindObjectOfType<OVREmulatorSetting>(); }
    public static OVRInput.Controller ConnectedController { get { return GetInstance().connectedController; } }
#endif
}