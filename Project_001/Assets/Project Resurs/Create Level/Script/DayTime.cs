using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class DayTime : MonoBehaviour
{
    [SerializeField] private Gradient _directionalLight;
    [SerializeField] private Gradient _ambientlLight;

    [SerializeField, Range(1, 3600)] private float _timeDay = 300;
    [SerializeField, Range(0f, 1f)] private float _timeProgress;

    [SerializeField] private Light _light;

    private Vector3 _defaultAngles;

    private void Start() => _defaultAngles = _light.transform.localEulerAngles;

    private void Update()
    {
        if(Application.isPlaying)
            _timeProgress += Time.deltaTime / _timeDay;
        if( _timeProgress > 1)
        {
            _timeProgress = 0;
        }
        _light.color = _directionalLight.Evaluate(_timeProgress);
        RenderSettings.ambientLight = _ambientlLight.Evaluate(_timeProgress);

        _light.transform.localEulerAngles = new Vector3(360f * _timeProgress - 90, _defaultAngles.y, _defaultAngles.z); 
    }
}
