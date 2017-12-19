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
    List<int> ListCurrentHealth = new List<int>();
    List<int> ListMaxHealth = new List<int>();
    [MenuItem("MyMenu2/My Window")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(MyWindow));
    }

    Vector2 scrollPosition = Vector2.zero;

    void OnGUI()
    {
        Debug.Log("iterationGUI");
        
        /*
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
        */
        //part3
        bool buttonFind = GUILayout.Button("Find and list all the living");
        if (buttonFind)
        {
            AllObjectsInTheScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene().GetRootGameObjects();
            MyListOfLivingIdiotsOnTheScene = new List<GameObject>();
            ListCurrentHealth = new List<int>();
            ListMaxHealth = new List<int>();
        }
        
        if(AllObjectsInTheScene!=null)
        {
            scrollPosition=GUILayout.BeginScrollView(scrollPosition);
            
            MyListOfLivingIdiotsOnTheScene = new List<GameObject>();
            ListCurrentHealth = new List<int>();
            ListMaxHealth = new List<int>();
            int i = 0;
            foreach (GameObject obj in AllObjectsInTheScene)
            {
                if (obj.GetComponent<Life>() == true)
                {
                    MyListOfLivingIdiotsOnTheScene.Add(obj);
                    GUILayout.Label("Name : " + obj.name, EditorStyles.whiteLargeLabel);
                    //show&&changeCurrentHealth
                    ListCurrentHealth.Add(obj.GetComponent<Life>().MyCurrentHealth);
                    ListCurrentHealth[i] = (int)EditorGUILayout.Slider("Current Health", obj.GetComponent<Life>().MyCurrentHealth, 0, obj.GetComponent<Life>().MymaxHealth);
                    MyListOfLivingIdiotsOnTheScene[i].GetComponent<Life>().MyCurrentHealth = ListCurrentHealth[i];
                    //show&&changeMaxHealth
                    ListMaxHealth.Add(obj.GetComponent<Life>().MymaxHealth);
                    ListMaxHealth[i] = EditorGUILayout.IntField("Maximum Health",obj.GetComponent<Life>().MymaxHealth);
                    MyListOfLivingIdiotsOnTheScene[i].GetComponent<Life>().MymaxHealth= ListMaxHealth[i];
                    //----
                    GUILayout.BeginHorizontal();
                    if (GUILayout.Button("KILL HIM !"))
                    {
                        obj.SetActive(false);
                        obj.GetComponent<Life>().MyCurrentHealth = 0;
                    }
                    if (GUILayout.Button("Raise the dead"))
                    {
                        if(obj.activeSelf==false)
                        {
                            obj.SetActive(true);
                            obj.GetComponent<Life>().MyCurrentHealth = obj.GetComponent<Life>().MymaxHealth;
                        }
                    }
                    GUILayout.EndHorizontal();
                    i++;
                }
            }
            GUILayout.EndScrollView();
            GUILayout.Label("nombre de vivants : " + MyListOfLivingIdiotsOnTheScene.Count, EditorStyles.whiteLargeLabel);
        }




        
    }
    
}
