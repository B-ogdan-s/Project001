using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/Dealog/Variant Dealog")]
public class ScriptableObjectVariantDialog : AB_ScriptableObjectDialog
{
    public string[] _nameButton;
    public ScriptableObjectDialog[] _nextDealog;
}
