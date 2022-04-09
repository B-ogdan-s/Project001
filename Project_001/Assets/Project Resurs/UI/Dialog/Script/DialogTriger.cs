using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTriger : MonoBehaviour
{
    [SerializeField] private AB_ScriptableObjectDialog _dialog;

    private DialogButtonAnimation _buttonAnimation;
    private DialogController _dialogController;

    private void Start()
    {
        _buttonAnimation = FindObjectOfType<DialogButtonAnimation>();
        _dialogController = FindObjectOfType<DialogController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponentInParent<PlayerTransform>() != null)
        {
            _dialogController.Dialog = _dialog;
            _buttonAnimation.Open();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponentInParent<PlayerTransform>() != null)
        {
            _buttonAnimation.Close();
        }
    }
}
