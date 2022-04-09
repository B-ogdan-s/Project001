using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public  class DialogController : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private Text _text;
    [SerializeField] private AB_ScriptableObjectDialog _dialog;
    [SerializeField] private AB_ScriptableObjectDialog _startDialog;
    [SerializeField] private float _time;
    [SerializeField] private VerticalPanelAnimationControler _animationController;

    private DialogPanelAnimation _panelAnimation;

    private bool _dialogGoing = true;
    private bool _dialogeClick = true;

    private void Start()
    {
        _panelAnimation = FindObjectOfType<DialogPanelAnimation>();
    }

    public IEnumerator OnGoingText()
    {

        _dialogGoing = false;
        _text.text = "";

        for (int i = 0; i < _dialog._dealog.Length; i++)
        {
            if (!_dialogeClick)
            {
                yield break;
            }

            char c = _dialog._dealog[i];
            _text.text += c;
            yield return new WaitForSeconds(_time);
        }

        _dialogeClick = false;
    }

    private IEnumerator CR_StartDialoge()
    {
        yield return new WaitForSeconds(0.8f);
        StartCoroutine(OnGoingText());
    }

    public void StartVariantDialog()
    {
        if (_dialog == null)
        {
            _animationController.ClosePause();
            _text.text = "";
            return;
        }
        StartCoroutine(CR_StartDialoge());
    }
   
    public void StartDialoge()
    {
        _dialog = _startDialog;
        if (_dialog == null)
        {
            return;
        }
        _animationController.OpenPause();
        StartCoroutine(CR_StartDialoge());
    }

    public void OnPointerDown(PointerEventData eventData)
    {         
        if (_dialogeClick == false && _dialogGoing == false)
        {
            _dialogeClick = true;
            _dialogGoing = true;
            if (_dialog is ScriptableObjectDialog)
            {
                var a = (ScriptableObjectDialog)_dialog;
                _dialog = a._nextDealog;
                if (_dialog == null)
                {
                    _animationController.ClosePause();
                    _text.text = "";
                    return;
                }
                StartCoroutine(OnGoingText());
            }
            else if(_dialog is ScriptableObjectVariantDialog)
            {
                var a = (ScriptableObjectVariantDialog)_dialog;
                a.OpenVariantDialogPanel();
                _panelAnimation.Open();
                enabled = false;
            }
        }
        
        else if (_dialogGoing == false)
        {
            _dialogeClick = false;
            _text.text = _dialog._dealog;
        }
    }

    public AB_ScriptableObjectDialog Dialog
    {
        get { return _dialog; }
        set { _dialog = value; }
    }
}


