#if UNITY_EDITOR
using System;
using System.Reflection;
using UnityEditor;

[InitializeOnLoad]
public class OVRInputReplacer
{
    static OVRInputReplacer()
    {
        // コントローラーの種別
        ReplaceProperty(typeof(OVRPlugin), typeof(OVRPluginEmulator), "productName", new System.Type[] { });

        // コントローラーの接続判定
        ReplaceMethod(typeof(OVRInput), typeof(OVRInputEmulator), "IsControllerConnected", new System.Type[] { typeof(OVRInput.Controller) });
        // コントローラーのTransform
        ReplaceMethod(typeof(OVRInput), typeof(OVRInputEmulator), "GetLocalControllerRotation", new System.Type[] { typeof(OVRInput.Controller) });
        ReplaceMethod(typeof(OVRInput), typeof(OVRInputEmulator), "GetLocalControllerPosition", new System.Type[] { typeof(OVRInput.Controller) });
        // タッチパッド上の座標
        ReplaceMethod(typeof(OVRInput), typeof(OVRInputEmulator), "Get", new System.Type[] { typeof(OVRInput.Axis2D), typeof(OVRInput.Controller) });
        // リセンター判定
        ReplaceMethod(typeof(OVRInput), typeof(OVRInputEmulator), "GetControllerWasRecentered", new System.Type[] { typeof(OVRInput.Controller) });
        // タッチパッドのタッチ判定
        ReplaceMethod(typeof(OVRInput), typeof(OVRInputEmulator), "Get", new System.Type[] { typeof(OVRInput.Touch), typeof(OVRInput.Controller) });
        ReplaceMethod(typeof(OVRInput), typeof(OVRInputEmulator), "GetDown", new System.Type[] { typeof(OVRInput.Touch), typeof(OVRInput.Controller) });
        ReplaceMethod(typeof(OVRInput), typeof(OVRInputEmulator), "GetUp", new System.Type[] { typeof(OVRInput.Touch), typeof(OVRInput.Controller) });
        // タッチパッドのクリック判定
        ReplaceMethod(typeof(OVRInput), typeof(OVRInputEmulator), "Get", new System.Type[] { typeof(OVRInput.Button), typeof(OVRInput.Controller) });
        ReplaceMethod(typeof(OVRInput), typeof(OVRInputEmulator), "GetDown", new System.Type[] { typeof(OVRInput.Button), typeof(OVRInput.Controller) });
        ReplaceMethod(typeof(OVRInput), typeof(OVRInputEmulator), "GetUp", new System.Type[] { typeof(OVRInput.Button), typeof(OVRInput.Controller) });
        // バックボタンのクリック判定
        ReplaceMethod(typeof(OVRInput), typeof(OVRInputEmulator), "Get", new System.Type[] { typeof(OVRInput.RawButton), typeof(OVRInput.Controller) });
        ReplaceMethod(typeof(OVRInput), typeof(OVRInputEmulator), "GetDown", new System.Type[] { typeof(OVRInput.RawButton), typeof(OVRInput.Controller) });
        ReplaceMethod(typeof(OVRInput), typeof(OVRInputEmulator), "GetUp", new System.Type[] { typeof(OVRInput.RawButton), typeof(OVRInput.Controller) });
    }

    static void ReplaceMethod(System.Type originType, System.Type replaceType, string methodName, System.Type[] types)
    {
        var origin = originType.GetMethod(methodName, types);
        var replace = replaceType.GetMethod(methodName, types);
        ReplaceFunctionPointer(origin, replace);
    }
    static void ReplaceProperty(System.Type originType, System.Type replaceType, string propertyName, System.Type[] types)
    {
        var origin = originType.GetProperty(propertyName, types);
        var replace = replaceType.GetProperty(propertyName, types);
        ReplaceFunctionPointer(origin.GetGetMethod(), replace.GetGetMethod());
    }
    static void ReplaceFunctionPointer(MethodInfo originalMethod, MethodInfo replaceMethod)
    {
        unsafe
        {
            var originalPointer = originalMethod.MethodHandle.Value.ToPointer();
            var replacePointer = replaceMethod.MethodHandle.Value.ToPointer();
            *((int*)new IntPtr(((int*)originalPointer + 1)).ToPointer()) = *((int*)new IntPtr(((int*)replacePointer + 1)).ToPointer());
        }
    }
}
#endif