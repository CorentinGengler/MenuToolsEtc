using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

class MyWindow : EditorWindow
{
    string myString = "Hello World";
    bool groupEnabled;
    bool m_myBool = true;
    float m_myFloat = 1.23f;
    GameObject[] AllObjectsInTheScene;
    List<GameObject> MyListOfLivingIdiotsOnTheScene = new List<GameObject>();
    // Add menu item named "My Window" to the Window menu
    [MenuItem("MyMenu2/My Window")]
    public static void ShowWindow()
    {
        //Show existing window instance. If one doesn't exist, make one.
        EditorWindow.GetWindow(typeof(MyWindow));
    }

    void OnGUI()
    {
        Debug.Log("iterationGUI");
        //part1
        Color baseColor = GUI.backgroundColor;
        GUILayout.Label("Base Settings", EditorStyles.boldLabel);
        myString = EditorGUILayout.TextField("Text Field", myString);
        //part2
        groupEnabled = EditorGUILayout.BeginToggleGroup("Optional Settings", groupEnabled);
        GUI.backgroundColor = new Color(100, 200, 0);
        GUI.Box(new Rect(2, 60, 45, 37), "");
        GUI.backgroundColor = baseColor;
        m_myBool = EditorGUILayout.Toggle("Toggle", m_myBool);
        m_myFloat = EditorGUILayout.Slider("Slider", m_myFloat, -3, 3);
        GUILayout.BeginVertical("box");
        GUI.backgroundColor = new Color(100, 0, 0);
        bool button1 = GUILayout.Button("HO HO HO");
        bool button2 = GUILayout.Button("Merry Christmas");
        GUI.backgroundColor = baseColor;
        GUILayout.EndVertical();
        EditorGUILayout.EndToggleGroup();
        if (button1 == true)
        {
            myString = "ho ho ho";
        }
        if (button2 == true)
        {
            myString = "Merry Christmas";
        }

        //part3
        bool buttonFind = GUILayout.Button("Find and list all the living");
        if (buttonFind)
        {
            AllObjectsInTheScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene().GetRootGameObjects();
            MyListOfLivingIdiotsOnTheScene = new List<GameObject>();
        }
        
        if(AllObjectsInTheScene!=null)
        {
            MyListOfLivingIdiotsOnTheScene = new List<GameObject>();
            foreach (GameObject obj in AllObjectsInTheScene)
            {
                if (obj.GetComponent<Life>() == true)
                {
                    MyListOfLivingIdiotsOnTheScene.Add(obj);
                    GUILayout.Label("Name : " + obj.name, EditorStyles.whiteLargeLabel);
                    GUILayout.Label("Current Health : " + obj.GetComponent<Life>().MyCurrentHealth.ToString(), EditorStyles.boldLabel);
                    GUILayout.Label("Maximum Health : " + obj.GetComponent<Life>().MymaxHealth.ToString(), EditorStyles.boldLabel);
                    
                }
            }

            GUILayout.Label("nombre de vivants : " + MyListOfLivingIdiotsOnTheScene.Count, EditorStyles.whiteLargeLabel);
        }




        
    }
    
}
