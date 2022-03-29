using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Controler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
	[BoxGroup("Controler Panel")]
	[SerializeField] private GameObject _controlerFon;
	[BoxGroup("Controler Panel")]
	[SerializeField] private GameObject _controler;
	[BoxGroup("Controler Panel")]
	[SerializeField] private float _radius;
	[ReadOnly]
	[SerializeField] private Vector2 _controlerFonPosition;
	[ReadOnly]
	[SerializeField] private Vector2 _controlerPosition;

	private void Start()
    {
        _controlerFonPosition = _controlerFon.transform.localPosition;
		_controlerPosition = _controler.transform.localPosition;
    }

    public void OnPointerDown(PointerEventData eventData)
	{
		_controlerFon.transform.position = eventData.position;
	}

	public void OnDrag(PointerEventData eventData)
	{
		if(Mathf.Sqrt(Mathf.Pow(_controlerFon.transform.position.x - eventData.position.x, 2) + 
					  Mathf.Pow(_controlerFon.transform.position.y - eventData.position.y, 2)) <= _radius * (Screen.height / 1440f))
		{
			_controler.transform.position = eventData.position;
		}
        else
        {
			Math(eventData);
        }
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		_controlerFon.transform.localPosition = _controlerFonPosition;
		_controler.transform.localPosition = _controlerPosition;
	}

	private void Math(PointerEventData eventData)
    {
		float rad = Mathf.Sqrt(Mathf.Pow(_controlerFon.transform.position.x - eventData.position.x, 2) +
					  Mathf.Pow(_controlerFon.transform.position.y - eventData.position.y, 2));
		float corX_1 = _controlerFon.transform.position.x - eventData.position.x;
		float corY_1 = _controlerFon.transform.position.y - eventData.position.y;

		float corX_2 = corX_1 / rad * _radius * (Screen.height / 1440f);
		float corY_2 = corY_1 / rad * _radius * (Screen.height / 1440f);

		_controler.transform.position = new Vector2(-corX_2 + _controlerFon.transform.position.x, -corY_2 + _controlerFon.transform.position.y);
	}
}
