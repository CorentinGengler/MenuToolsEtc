using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

class MyWindow : EditorWindow
{
    string myString = "Hello World";
    bool groupEnabled;
    bool myBool = true;
    float myFloat = 1.23f;
    

    // Add menu item named "My Window" to the Window menu
    [MenuItem("MyMenu2/My Window")]
    public static void ShowWindow()
    {
        //Show existing window instance. If one doesn't exist, make one.
        EditorWindow.GetWindow(typeof(MyWindow));
    }

    void OnGUI()
    {
        Color baseColor = GUI.backgroundColor;
        GUILayout.Label("Base Settings", EditorStyles.boldLabel);
        myString = EditorGUILayout.TextField("Text Field", myString);
        groupEnabled = EditorGUILayout.BeginToggleGroup("Optional Settings", groupEnabled);
        GUI.backgroundColor = new Color(100, 200, 0);
        GUI.Box(new Rect(2, 60, 45, 37), "");
        GUI.backgroundColor= baseColor;
        myBool = EditorGUILayout.Toggle("Toggle", myBool);
        myFloat = EditorGUILayout.Slider("Slider", myFloat, -3, 3);
        GUILayout.BeginVertical("box");
        GUI.backgroundColor = new Color(100, 0, 0);
        bool button1 = GUILayout.Button("HO HO HO");
        bool button2 = GUILayout.Button("Merry Christmas");
        GUI.backgroundColor = baseColor;
        GUILayout.EndVertical();
        EditorGUILayout.EndToggleGroup();

        if(button1==true)
        {
            myString = "ho ho ho";
        }
        if (button2 == true)
        {
            myString = "Merry Christmas";
        }
    }
}
