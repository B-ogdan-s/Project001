using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TipeAttac
{
    meleeAttack,
    rangedAttack
}

[CreateAssetMenu(menuName = "ScriptableObject/EnemyLogic")]
public class ScriptableObjectEnemyLogic : ScriptableObject
{
    [BoxGroup("Attac")]
    public TipeAttac _tipeAttac;
    [BoxGroup("Attac")]
    public int _attac;
    [BoxGroup("Attac")]
    public float _timeAttacPause;

    public int _health;

    [BoxGroup("Level")]
    public int _level;
    [BoxGroup("Level")]
    public int _AddAttac;
    [BoxGroup("Level")]
    public int _AddHealth;

    public float _speed;
}
