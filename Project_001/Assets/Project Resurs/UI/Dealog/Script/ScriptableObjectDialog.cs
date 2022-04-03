using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;

[CreateAssetMenu(menuName = "ScriptableObject/Dealog/Dealog")]
public class ScriptableObjectDialog : ScriptableObject
{
    public string _name;
    [TextArea(5, 7)]
    public string _dealog;
    public Color _colorName;
    public Transform _position;
    public GameObject _speaker;
    public ScriptableObjectDialog _nextDealog;
}
