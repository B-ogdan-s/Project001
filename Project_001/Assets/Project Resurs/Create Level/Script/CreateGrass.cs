using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateGrass : MonoBehaviour
{
    [SerializeField] private GameObject[] _grassMas;
    [SerializeField] private Material[] _materialMas;
    [SerializeField] private Transform _parents;


    [BoxGroup("Num")]
    [SerializeField] private int _minNum;
    [BoxGroup("Num")]
    [SerializeField] private int _maxNum;

    [Button]
    public void Creae()
    {
        int num = Random.Range(_minNum, _maxNum+1);
        for (int i = 0; i < num; i++)
        {
            var obj = Instantiate(_grassMas[Random.Range(0, _grassMas.Length)], _parents);
            obj.transform.localPosition = new Vector3(Random.Range(GetComponent<Collider>().bounds.min.x, GetComponent<Collider>().bounds.max.x),
                obj.transform.localPosition.y, Random.Range(GetComponent<Collider>().bounds.min.z, GetComponent<Collider>().bounds.max.z));
            obj.GetComponentInChildren<MeshRenderer>().material = _materialMas[Random.Range(0, _materialMas.Length)];
            obj.transform.rotation = Quaternion.Euler(0, Random.Range(0f, 360f), 0);
        }
    }
}
