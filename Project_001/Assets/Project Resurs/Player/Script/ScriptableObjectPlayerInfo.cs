using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/PlayerInfo")]
public class ScriptableObjectPlayerInfo : ScriptableObject
{
    [BoxGroup("Max Parameters")]
    public float _maxHealth;
    [BoxGroup("Max Parameters")]
    public float _maxExperience;

    [BoxGroup("Parameters")]
    public float _health;
    [BoxGroup("Parameters")]
    public float _experience;
    [BoxGroup("Parameters")]
    public float _attack;
    [BoxGroup("Parameters")]
    public float _speed;
}
