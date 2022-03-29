using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTransform : MonoBehaviour
{
    [BoxGroup("Controler")]
    [SerializeField] private GameObject _connrolerFon;
    [BoxGroup("Controler")]
    [SerializeField] private GameObject _connroler;
    [BoxGroup("Controler")]
    [SerializeField] private float _radiusStartTransform;
    [BoxGroup("Controler")]
    [SerializeField] private ScriptableObjectPlayerInfo _playerInfo;


    [SerializeField] private RotetCam _rotetCam;

    private void Update()
    {
        float radius = Mathf.Sqrt(Mathf.Pow(_connroler.transform.localPosition.x,2) + Mathf.Pow(_connroler.transform.localPosition.y, 2));
        if (radius > _radiusStartTransform)
        {
            float _sin = Mathf.Asin(_connroler.transform.localPosition.y / radius ) / Mathf.PI * 180f;
            float _cos = Mathf.Acos(_connroler.transform.localPosition.x / radius ) / Mathf.PI * 180f;
            if(_sin > 0)
            {
                _cos *= -1;
            }
            transform.eulerAngles = new Vector3(0f,_cos + 45f + _rotetCam.GetRotCam(),0f);
            transform.Translate(Vector3.right * _playerInfo._speed * (radius / 250f) * Time.deltaTime);
        }
    }
}
