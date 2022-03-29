using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/SaveInventory")]
public class ScriptableObjectSaveInventory : ScriptableObject
{
    public GameObject _panel;
    public float _num;
    [ReadOnly]
    public float _startNum = 8;
}
