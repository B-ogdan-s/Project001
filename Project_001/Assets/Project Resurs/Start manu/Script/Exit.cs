using Sirenix.OdinInspector;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    [SerializeField] private MenuAnimation _menuAnimation;
    [SerializeField] private Canvas _canwas;
    [SerializeField] private GameObject _panel;
    [SerializeField] private float _time;
    [SerializeField] private float _indent;

    private void Start()
    {
        _canwas.enabled = false;
        _panel.transform.DOMoveY(_panel.transform.position.y - _indent, 0);
    }
    public void OpenPanelExit()
    {
        _canwas.enabled = true;
        _menuAnimation.Close();
        _panel.transform.DOMoveY(_panel.transform.position.y + _indent, _time);
    }

    public void ClosePanelExit()
    {
        StartCoroutine(CR_ClosePanelExit());
    }

    private IEnumerator CR_ClosePanelExit()
    {
        _menuAnimation.Open();
        _panel.transform.DOMoveY(_panel.transform.position.y - _indent, _time);
        yield return new WaitForSeconds(_time);
        _canwas.enabled = false;
    }

    public void ExitClick()
    {
        Application.Quit();
    }
}
