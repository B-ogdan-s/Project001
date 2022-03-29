using Sirenix.OdinInspector;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderPlayerInfo : MonoBehaviour
{
    [SerializeField] private ScriptableObjectPlayerInfo _playerinfo;
    [BoxGroup("Slider")]
    [SerializeField] private Slider _healthSlider;
    [BoxGroup("Slider")]
    [SerializeField] private Slider _experienceSlider;
    [BoxGroup("Time")]
    [SerializeField] private float _timeSlider;

    private void Start()
    {
        _healthSlider.value = 0f;
        _experienceSlider.value = 0f;

        _healthSlider.DOValue(_playerinfo._health / _playerinfo._maxHealth, _timeSlider);
        _experienceSlider.DOValue(_playerinfo._experience / _playerinfo._maxExperience, _timeSlider);
    }
    /*
    private void Update()
    {
        _healthSlider.value = _playerinfo._health / _playerinfo._maxHealth;
        _experienceSlider.value = _playerinfo._experience / _playerinfo._maxExperience;
    }
    */
}
