using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonVariant : MonoBehaviour
{
    private AB_ScriptableObjectDialog _nextDialog;
    private DialogController _dialogController;
    private DialogPanelAnimation _panelAnimation;

    private void Start()
    {
        _panelAnimation = FindObjectOfType<DialogPanelAnimation>();
        _dialogController = FindObjectOfType<DialogController>();
    }

    public void OnClick()
    {
        ButtonVariant[] buttonMas = FindObjectsOfType<ButtonVariant>();
        _dialogController.enabled = true;
        _dialogController.Dialog = _nextDialog;
        _dialogController.StartVariantDialog();
        _panelAnimation.Close();

        foreach (ButtonVariant a in buttonMas)
        {
            Destroy(a.gameObject);
        }
    }

    public AB_ScriptableObjectDialog Dialog
    {
        get { return _nextDialog; }
        set { _nextDialog = value; }
    }
}
