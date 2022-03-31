using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PresentationModele : MonoBehaviour, IPointerDownHandler, IDragHandler
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _model;
    [ReadOnly]
    [SerializeField] private float _startTouch;
    [ReadOnly]
    public void OnDrag(PointerEventData eventData)
    {
        _model.eulerAngles += new Vector3(0, (_startTouch - eventData.position.x) * _speed * Time.deltaTime, 0);
        _startTouch = eventData.position.x;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _startTouch = eventData.position.x;
    }
}
