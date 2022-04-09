using Sirenix.OdinInspector;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogPanelAnimation : MonoBehaviour
{
    [SerializeField] private float _indent;
    [SerializeField] private float _time;
    private void Start()
    {
        transform.DOMoveY(transform.position.y + _indent * (Screen.height / 1440f), 0);
    }
    [Button]
    public void Open()
    {
        transform.DOMoveY(transform.position.y - _indent * (Screen.height / 1440f), _time);
    }
    [Button]
    public void Close()
    {
        transform.DOMoveY(transform.position.y + _indent * (Screen.height / 1440f), _time);
    }
}
