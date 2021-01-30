using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CameraInterest))]
public class CameraInterestEditor : Editor
{
    private void OnSceneGUI()
    {
        CameraInterest interest = (CameraInterest)target;

        Handles.color = Color.cyan;
        Handles.DrawWireDisc(interest.transform.position, Vector3.forward, interest.stealFocusRadius);
        Handles.color = Color.blue;
        Handles.DrawWireDisc(interest.transform.position, Vector3.forward, interest.stealInterestRadius);


        interest.stealFocusRadius = Mathf.Clamp(interest.stealFocusRadius, 1f, interest.stealInterestRadius - 1);
        interest.stealInterestRadius = Mathf.Clamp(interest.stealInterestRadius, interest.stealFocusRadius + 1, Mathf.Infinity);
    }
}
