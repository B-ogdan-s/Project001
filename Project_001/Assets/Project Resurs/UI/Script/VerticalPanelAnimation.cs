using Sirenix.OdinInspector;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VerticalPanelAnimation : MonoBehaviour
{
    [BoxGroup("Panels")]
    [SerializeField] private Canvas[] _canvasUI;
    [BoxGroup("Panels")]
    [SerializeField] private GameObject[] _leftPanel;
    [BoxGroup("Panels")]
    [SerializeField] private GameObject[] _rightPanel;
    [BoxGroup("Panels")]
    [SerializeField] private GameObject[] _downPanel;

    [BoxGroup("Indent")]
    [SerializeField] private float _indentLeftPanel;
    [BoxGroup("Indent")]
    [SerializeField] private float _indentRightPanel;
    [BoxGroup("Indent")]
    [SerializeField] private float _indentDownPanel;
    [BoxGroup("Indent")]
    [SerializeField] private float _time;

    public IEnumerator CR_Open(Canvas _panelCanvas, Image _blackFon, float _valueFon, Transform _panel, float _indentPanel)
    {
        var Seq = DOTween.Sequence();
        _panelCanvas.enabled = true;
        _blackFon.DOFade(_valueFon, _time);
        Seq.Append(_panel.DOMoveY(_panel.position.y - (_indentPanel * Screen.height / 1440f), _time));
        foreach (var obj in _leftPanel)
        {
            Seq.Join(obj.transform.DOMoveX(obj.transform.position.x - (_indentLeftPanel * Screen.width / 2960), _time));
        }
        foreach (var obj in _rightPanel)
        {
            Seq.Join(obj.transform.DOMoveX(obj.transform.position.x + (_indentRightPanel * Screen.width / 2960), _time));
        }
        foreach (var obj in _downPanel)
        {
            Seq.Join(obj.transform.DOMoveY(obj.transform.position.y - (_indentDownPanel * Screen.height / 1440), _time));
        }
        yield return new WaitForSeconds(_time);

        foreach (var canvas in _canvasUI)
        {
            canvas.enabled = false;
        }
    }

    public IEnumerator CR_Close(Canvas _panelCanvas, Image _blackFon, float _valueFon, Transform _panel, float _indentPanel)
    {
        foreach (var canvas in _canvasUI)
        {
            canvas.enabled = true;
        }

        _blackFon.DOFade(0, _time);

        var Seq = DOTween.Sequence();
        Seq.Append(_panel.DOMoveY(_panel.position.y + (_indentPanel * Screen.height / 1440f), _time));
        foreach (var obj in _leftPanel)
        {
            Seq.Join(obj.transform.DOMoveX(obj.transform.position.x + (_indentLeftPanel * Screen.width / 2960), _time));
        }
        foreach (var obj in _rightPanel)
        {
            Seq.Join(obj.transform.DOMoveX(obj.transform.position.x - (_indentRightPanel * Screen.width / 2960), _time));
        }
        foreach (var obj in _downPanel)
        {
            Seq.Join(obj.transform.DOMoveY(obj.transform.position.y + (_indentDownPanel * Screen.height / 1440), _time));
        }
        yield return new WaitForSeconds(_time);

        _panelCanvas.enabled = false;
    }
}
