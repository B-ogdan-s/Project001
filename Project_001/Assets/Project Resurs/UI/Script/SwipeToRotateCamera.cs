using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SwipeToRotateCamera : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
	[SerializeField] private RotetCam _rotetCam;

	[SerializeField] private float _admissibleRadius;

	[BoxGroup("Clic Coordenat")]
	[ReadOnly]
	[SerializeField] private Vector2 _startTouch;
	[BoxGroup("Clic Coordenat")]
	[ReadOnly]
	[SerializeField] private Vector2 _finishTouch;
	[BoxGroup("Clic Coordenat")]
	[ReadOnly]
	[SerializeField] private float _radius;
	public void OnPointerDown(PointerEventData eventData)
    {
		_startTouch = eventData.position;
    }

	public void OnPointerUp(PointerEventData eventData)
    {
		_finishTouch = eventData.position;
		RotControler();
	}

	private void RotControler()
    {
		_radius = Mathf.Abs(_startTouch.x - _finishTouch.x);
		if (_radius > _admissibleRadius && _radius > Mathf.Abs(_startTouch.y - _finishTouch.y))
        {
			if( _startTouch.x > _finishTouch.x)
            {
				_rotetCam.NextPos();
            }
			else
			{
				_rotetCam.PeviousPos();
			}
        }
    }
}
