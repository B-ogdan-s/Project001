using Sirenix.OdinInspector;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VerticalPanelAnimationControler : MonoBehaviour
{
    [SerializeField] private VerticalPanelAnimation _UIAnimation;

    [BoxGroup("Panels")]
    [SerializeField] private Canvas _Canvas;
    [BoxGroup("Panels")]
    [SerializeField] private Image _blackFon;
    [BoxGroup("Panels")]
    [SerializeField] private float _valueFon;

    [BoxGroup("Indent")]
    [SerializeField] private float _indent;

    private void Start()
    {
        transform.DOMoveY(transform.position.y + (_indent * Screen.height / 1440f), 0);
        _blackFon.DOFade(0, 0);
        _Canvas.enabled = false;
    }
    [HorizontalGroup("Pause")]
    [VerticalGroup("Pause/Right")]
    [Button(ButtonSizes.Medium)]
    public void OpenPause()
    {
        StartCoroutine(_UIAnimation.CR_Open(_Canvas, _blackFon, _valueFon, transform, _indent));
    }
    [VerticalGroup("Pause/Left")]
    [Button(ButtonSizes.Medium)]
    public void ClosePause()
    {
        StartCoroutine(_UIAnimation.CR_Close(_Canvas, _blackFon, _valueFon, transform, _indent));
    }
}
