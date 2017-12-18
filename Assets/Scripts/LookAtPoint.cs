using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class LookAtPoint : MonoBehaviour
{
    public bool DropDownButton;
    public Vector3 lookAtPoint = Vector3.zero;
    public int experience;
    
    public int Level
    {
        get { return experience / 750; }
    }

    void Update()
    {
        transform.LookAt(lookAtPoint);
    }
}
