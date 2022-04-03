using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DialogController : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private Text _text;
    [SerializeField] private ScriptableObjectDialog _firstscriptableobject;
    [SerializeField] private float _time;
    [SerializeField] private VerticalPanelAnimationControler _animationController;

    private bool _dialogGoing = true;
    private bool _dialogeClick = true;

    public IEnumerator OnGoingText()
    {
        _dialogGoing = false;
        _text.text = "";

        for (int i = 0; i < _firstscriptableobject._dealog.Length; i++)
        {
            if (!_dialogeClick)
            {
                yield break;
            }

            char c = _firstscriptableobject._dealog[i];
            _text.text += c;
            yield return new WaitForSeconds(_time);
        }

        _dialogeClick = false;
    }

    private IEnumerator CR_StartDialoge()
    {
        yield return new WaitForSeconds(1.1f);
        StartCoroutine(OnGoingText());
    }
   
    public void StartDialoge()
    {
        StartCoroutine(CR_StartDialoge());
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log(_dialogeClick);
        Debug.Log(_dialogGoing);
         
        if (_dialogeClick == false && _dialogGoing == false)
        {
            Debug.Log("Seks");
            _dialogeClick = true;
            _dialogGoing = true;
            _firstscriptableobject = _firstscriptableobject._nextDealog;
            if (_firstscriptableobject == null)
            {
                _animationController.ClosePause();
                return;
            }
            StartCoroutine(OnGoingText());
        }
        
        else if (_dialogGoing == false)
        {
            _dialogeClick = false;
            _text.text = _firstscriptableobject._dealog;
        }
    }
}


