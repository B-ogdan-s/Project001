using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SlimeLogic : MonoBehaviour
{
    [SerializeField] private ScriptableObjectEnemyLogic _logic;
    [SerializeField] private float _timePause;
    [SerializeField] private Transform[] _positinMas;

    private NavMeshAgent _control;
    [SerializeField] private int _variant = 0;
    
    private void Start()
    {
        _control = GetComponent<NavMeshAgent>();
    }

    [Button]
    private void Test()
    {
        _control.SetDestination(_positinMas[_variant].position);
    }
}
