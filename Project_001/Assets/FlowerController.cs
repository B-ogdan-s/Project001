using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using Object = System.Object;
using Random = UnityEngine.Random;


public class FlowerController : MonoBehaviour
{
    [SerializeField] private float _minRot;
    [SerializeField] private float _maxRot;
     private float _time = 0.5f;
    
    private void OnTriggerEnter (Collider collider)
       
    {
        if(collider.GetComponent<PlayerTransform>())
        {
            float x = Random.Range(_minRot,_maxRot);
            if (Random.Range(0,2) == 0)
            {
                x *= -1;
            }
            float z = Random.Range(_minRot, _maxRot);
            if (Random.Range(0,2) == 0)
            {
                z *= -1;
            }
            transform.DORotate(new Vector3(x, transform.rotation.y,z),_time);
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        transform.DORotate(new Vector3(0, transform.rotation.y,0),_time);
    }
}



