using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Item")]
public class ItemBase : ScriptableObject
{
    public string Name;
    public int ID;
}
