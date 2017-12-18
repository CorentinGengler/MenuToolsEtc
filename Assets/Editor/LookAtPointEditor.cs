using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(LookAtPoint))]
[CanEditMultipleObjects]
public class LookAtPointEditor : Editor
{
    SerializedProperty lookAtPoint;

    void OnEnable()
    {
        lookAtPoint = serializedObject.FindProperty("lookAtPoint");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        EditorGUILayout.PropertyField(lookAtPoint);
        serializedObject.ApplyModifiedProperties();

        if (lookAtPoint.vector3Value.y > (target as LookAtPoint).transform.position.y)
        {
            EditorGUILayout.LabelField("(Above this object)");
        }
        if (lookAtPoint.vector3Value.y < (target as LookAtPoint).transform.position.y)
        {
            EditorGUILayout.LabelField("(Below this object)");
        }
        
        LookAtPoint myTarget = (LookAtPoint)target;

        if (GUILayout.Button("Drawer"))
        {
            myTarget.DropDownButton = !myTarget.DropDownButton;
        }
        if (myTarget.DropDownButton == true)
        {
            myTarget.experience = EditorGUILayout.IntField("Experience", myTarget.experience);
            EditorGUILayout.LabelField("Level", myTarget.Level.ToString());
        }
        
    }
}