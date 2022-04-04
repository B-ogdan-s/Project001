using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DialogController : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private Text _text;
    [SerializeField] private AB_ScriptableObjectDialog _dealog;
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

        for (int i = 0; i < _dealog._dealog.Length; i++)
        {
            if (!_dialogeClick)
            {
                yield break;
            }

            char c = _dealog._dealog[i];
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
        if (_dealog == null)
        {
            _animationController.ClosePause();
            _text.text = "";
            return;
        }
        StartCoroutine(CR_StartDialoge());
    }
   
    public void StartDialoge()
    {
        if (_dealog == null)
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
            if (_dealog is ScriptableObjectDialog)
            {
                var a = (ScriptableObjectDialog)_dealog;
                _dealog = a._nextDealog;
                if (_dealog == null)
                {
                    _animationController.ClosePause();
                    _text.text = "";
                    return;
                }
                StartCoroutine(OnGoingText());
            }
            else if(_dealog is ScriptableObjectVariantDialog)
            {
                var a = (ScriptableObjectVariantDialog)_dealog;
                a.OpenVariantDialogPanel();
                _panelAnimation.Open();
                enabled = false;
            }
        }
        
        else if (_dialogGoing == false)
        {
            _dialogeClick = false;
            _text.text = _dealog._dealog;
        }
    }

    public AB_ScriptableObjectDialog Dialog
    {
        get { return _dealog; }
        set { _dealog = value; }
    }
}


