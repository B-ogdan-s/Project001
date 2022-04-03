using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "ScriptableObject/Dealog/Variant")]
public class ScriptableObjectDialogAndVariant : AB_ScriptableObjectDialog
{
    public int _numNexDealog;
    public string[] _nameButton;
    public AB_ScriptableObjectDialog[] _nextDealog;
    public Transform _parentPanel;
    public GameObject _button;

    private DialogPanelAnimation _anim;

    public override AB_ScriptableObjectDialog NextDealog()
    {
        return null;
    }

    public void OpenPanel()
    {
        _anim = FindObjectOfType<DialogPanelAnimation>();
        _anim.Open();

        for(int i = _nextDealog.Length-1; i >= 0; i--)
        {
            var obj = Instantiate(_button);
            obj.transform.SetParent(_parentPanel);
            _button.GetComponent<DialogButton>()._NextDealog = _nextDealog[i];
            _button.GetComponentInChildren<Text>().GetComponent<Text>().text = _nameButton[i];
        }
    }
}
