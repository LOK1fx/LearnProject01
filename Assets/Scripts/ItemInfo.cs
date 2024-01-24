using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInfo : MonoBehaviour
{
    [TextArea]
    public string Name;
    [TextArea]
    public string Description;

    public void PrintToConsole()
    {
        Debug.Log($"��� �������: {Name} \n��������: {Description}");
    }
}