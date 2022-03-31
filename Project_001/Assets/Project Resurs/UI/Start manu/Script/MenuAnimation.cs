using Sirenix.OdinInspector;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAnimation : MonoBehaviour
{
    [BoxGroup("Game Object")]
    [SerializeField] private GameObject[] _buttonMas;
    [BoxGroup("Game Object")]
    [SerializeField] private GameObject _mainText;
    [BoxGroup("Time")]
    [SerializeField] private float _timeIndent;
    [BoxGroup("Time")]
    [SerializeField] private float _timePause;
    [BoxGroup("Indent")]
    [SerializeField] private float _buttonIndent;
    [BoxGroup("Indent")]
    [SerializeField] private float _textIndent;

    [ReadOnly]
    [SerializeField]private float _height;

    private void Start()
    {
        _height = Screen.height / 1440f;
        _mainText.transform.position = new Vector3(_mainText.transform.position.x, _mainText.transform.position.y + (_textIndent * _height));
        //_mainText.transform.DOMoveY(_mainText.transform.position.y + (_textIndent * _height), 0);
        for (int i = 0; i < _buttonMas.Length; i++)
        {
            _buttonMas[i].transform.DOMoveY(_buttonMas[i].transform.position.y - (_buttonIndent * _height),0);
        }

        Open();
    }

    [Button]
    public void Close()
    {
        StartCoroutine(CR_CloseMenu());
    }
    [Button]
    public void Open()
    {
        StartCoroutine(CR_OpenMenu());
    }

    private IEnumerator CR_CloseMenu()
    {
        _mainText.transform.DOMoveY(_mainText.transform.position.y + (_textIndent * _height), _timeIndent + (_timePause * (_buttonMas.Length - 1)));
        for(int i = 0; i< _buttonMas.Length; i++)
        {
            yield return new WaitForSeconds(_timePause);
            _buttonMas[i].transform.DOMoveY(_buttonMas[i].transform.position.y - (_buttonIndent * _height), _timeIndent);
        }
    }

    private IEnumerator CR_OpenMenu()
    {
        int a = _buttonMas.Length - 1;
        _mainText.transform.DOMoveY(_mainText.transform.position.y - (_textIndent * _height), _timeIndent + (_timePause * (_buttonMas.Length - 1)));
        for (int i = a; i >= 0; i--)
        {
            yield return new WaitForSeconds(_timePause);
            _buttonMas[i].transform.DOMoveY(_buttonMas[i].transform.position.y + (_buttonIndent * _height), _timeIndent);
        }
    }
}
