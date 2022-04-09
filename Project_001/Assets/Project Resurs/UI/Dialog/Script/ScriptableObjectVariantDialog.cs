using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "ScriptableObject/Dealog/Variant Dealog")]
public class ScriptableObjectVariantDialog : AB_ScriptableObjectDialog
{
    [SerializeField] private string[] _nameButton;
    [SerializeField] private ScriptableObjectDialog[] _nextDealog;

    [SerializeField] private Transform _parents;
    [SerializeField] private GameObject _button;

    public void OpenVariantDialogPanel()
    {
        for(int i = 0; i < _nextDealog.Length; i++)
        {
            var a = Instantiate(_button);
            a.transform.SetParent(_parents, false);
            a.GetComponentInChildren<Text>().text = _nameButton[i];
            a.GetComponent<ButtonVariant>().Dialog = _nextDealog[i];
        }
    }
}
