using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateLavelEarth : MonoBehaviour
{
    [HorizontalGroup("Num")]
    [VerticalGroup("Num/X")]
    [ReadOnly]
    [SerializeField] private int _numX;
    [VerticalGroup("Num/Y")]
    [ReadOnly]
    [SerializeField] private int _numZ;

    [HorizontalGroup("Start Pos")]
    [VerticalGroup("Start Pos/X")]
    [ReadOnly]
    [SerializeField] private float _startPosX;
    [VerticalGroup("Start Pos/Y")]
    [ReadOnly]
    [SerializeField] private float _startPosZ;

    [SerializeField] private GameObject _earth;
    [SerializeField] private Transform _parents;

    [SerializeField] private float _panelScale;
    [SerializeField] private float _panelIndentXZ;

    [Button]
    public void CreateEarth()
    {
        _startPosX = (int)(GetComponent<Collider>().bounds.min.x / _panelScale) * _panelScale;
        _startPosZ = (int)(GetComponent<Collider>().bounds.min.z / _panelScale) * _panelScale;

        if(_startPosX - (_panelScale / 2f) <= GetComponent<Collider>().bounds.min.x - (_panelScale / 100 * _panelIndentXZ))
        {
            _startPosX += _panelScale;
        }
        if (_startPosZ - (_panelScale / 2f) <= GetComponent<Collider>().bounds.min.z - (_panelScale / 100 * _panelIndentXZ))
        {
            _startPosZ += _panelScale;
        }

        _numX = 1;
        _numZ = 1;

        while(_startPosX + (_numX * _panelScale) + (_panelScale / 2) <= GetComponent<Collider>().bounds.max.x + (_panelScale / 100 * _panelIndentXZ))
        {
            _numX++;
        }
        while (_startPosZ + (_numZ * _panelScale) + (_panelScale / 2) <= GetComponent<Collider>().bounds.max.z + (_panelScale / 100 * _panelIndentXZ))
        {
            _numZ++;
        }

        for (int x = 0; x < _numX; x++)
        {
            for (int z = 0; z < _numZ; z++)
            {
                GameObject obj = Instantiate(_earth, _parents);
                obj.transform.position = new Vector3(_startPosX + (x * _panelScale), obj.transform.position.y, _startPosZ + (z * _panelScale));
                //Destroy(gameObject);
                //DestroyImmediate(gameObject);
            }
        }
    }
}
