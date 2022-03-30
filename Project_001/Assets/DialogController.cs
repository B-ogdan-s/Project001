using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DialogController : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private String _textmassive;
    [SerializeField] private Text _text;

    public IEnumerator TextAnimation()
    {
        _text.text = "";
        for (int i = 0; i < _textmassive.Length; i++)
        {
            char c = _textmassive[i];
            _text.text += c;

            yield return new WaitForSeconds(0.05f);
        }

    }
    
    public void OnPointerDown(PointerEventData eventData)
    {
        StartCoroutine(TextAnimation());
    }
}
