using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RotetCam : MonoBehaviour
{
    private bool _test = true;
    [BoxGroup("Time")]
    [SerializeField] private float _time;

    [SerializeField] private GameObject _player;

    [ReadOnly]
    [SerializeField] private int _numCam;

    private int[] _numCamMas = new int[0];

    private void Update()
    {
        transform.position = _player.transform.position;
        if (_numCamMas.Length != 0 && _test == true)
        {
            RotCam();
            _test = false;
        }
    }

    [HorizontalGroup("TestButton")]
    [VerticalGroup("TestButton/Left")]
    [Button(ButtonSizes.Medium)]
    public void PeviousPos()
    {
        AddMas(1);
    }

    [VerticalGroup("TestButton/Right")]
    [Button(ButtonSizes.Medium)]
    public void NextPos()
    {
        AddMas(-1);
    }

    private void RotCam()
    {
        if(_numCamMas.Length != 0)
        {
            _numCam += _numCamMas[0];
            if(_numCam < 0)
                _numCam = 3;
            else if(_numCam > 3)
                _numCam = 0;
            StartCoroutine(Rot());
        }
    }

    private IEnumerator Rot()
    {
        transform.DORotate(new Vector3(transform.rotation.eulerAngles.x, _numCam * 90f, transform.rotation.eulerAngles.z), _time);
        yield return new WaitForSeconds(_time);
        DecreaseMas();
        RotCam();
        if(_numCamMas.Length == 0)
        {
            _test = true;
        }
    }

    private void AddMas(int newElement)
    {
        int[] newMas = new int[_numCamMas.Length + 1];
        for(int i = 0; i < _numCamMas.Length; i++)
        {
            newMas[i] = _numCamMas[i];
        }
        newMas[_numCamMas.Length] = newElement;
        _numCamMas = newMas;
    }

    private void DecreaseMas()
    {
        int[] newMas = new int[_numCamMas.Length -1];
        for (int i = 0; i < newMas.Length; i++)
        {
            newMas[i] = _numCamMas[i+1];
        }
        _numCamMas = newMas;
    }

    public float GetRotCam()
    {
        return transform.rotation.eulerAngles.y;
    }
}
