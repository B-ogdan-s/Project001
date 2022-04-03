using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class AB_ScriptableObjectDialog : ScriptableObject
{
    public string _name;
    [TextArea(5, 7)]
    public string _dealog;
    public Color _colorName;
    public Transform _position;
    public GameObject _speaker;

    public virtual AB_ScriptableObjectDialog NextDealog()
    {
        return null;
    }
}
