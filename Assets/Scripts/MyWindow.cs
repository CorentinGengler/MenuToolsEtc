using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

class MyWindow : EditorWindow
{
    [MenuItem("MyMenu/My Window")]

    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(MyWindow));
    }

    void OnGUI()
    {



        // The actual window code goes here
    }
}
