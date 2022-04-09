using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogButtonAnimation : MonoBehaviour
{
    [SerializeField] private float _indent;
    [SerializeField] private float _time;

    private float _startPositionY;
    private void Start()
    {
        _startPositionY = transform.position.y;
        transform.DOMoveY(_startPositionY - _indent, 0);
    }
    public void Open()
    {
        transform.DOMoveY(_startPositionY, _time);
    }

    public void Close()
    {
        transform.DOMoveY(_startPositionY - _indent, _time);
    }
}
