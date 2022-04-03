using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;

[CreateAssetMenu(menuName = "ScriptableObject/Dealog/Dealog")]
public class ScriptableObjectDialog : AB_ScriptableObjectDialog
{
    public AB_ScriptableObjectDialog _nextDealog;
    public override AB_ScriptableObjectDialog NextDealog()
    {
        return _nextDealog;
    }
}
