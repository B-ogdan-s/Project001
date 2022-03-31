using Sirenix.OdinInspector;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    [SerializeField] private ScriptableObjectPlayerInfo _playerInfo;
    [SerializeField] private MenuAnimation _menuAnimation;
    [SerializeField] private Canvas _canwas;
    [SerializeField] private Image _fon;
    [BoxGroup("Slider")]
    [SerializeField] private Slider _slider;
    [BoxGroup("Slider")]
    [SerializeField] private Image _fonSlider;
    [BoxGroup("Slider")]
    [SerializeField] private Image _fillSlider;
    [BoxGroup("Time")]
    [SerializeField] private float _time;
    [BoxGroup("Time")]
    [SerializeField] private float _timePause;

    private void Start()
    {
        _fon.DOFade(0, 0);
        _fonSlider.DOFade(0, 0);
        _fillSlider.DOFade(0, 0);
        _canwas.enabled = false;
    }
    public void StartGameClick()
    {
        StartCoroutine(CR_StartCatScene());
    }

    private IEnumerator CR_StartCatScene()
    {
        var Seq = DOTween.Sequence();
        _canwas.enabled=true;
        _menuAnimation.Close();
        yield return new WaitForSeconds(_timePause);
        _fon.DOFade(1, _time);
        _fonSlider.DOFade(0.5f, _time);
        _fillSlider.DOFade(1, _time);

        SceneManager.LoadScene(_playerInfo._numScene);
        StartCoroutine(CR_StartScene());
    }

    private IEnumerator CR_StartScene()
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(_playerInfo._numScene);
        while(!asyncOperation.isDone)
        {
            _slider.value = asyncOperation.progress;
            yield return null;
        }
    }
}
