using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogButton : MonoBehaviour
{
    [SerializeField] private AB_ScriptableObjectDialog _nextDealog;
    [SerializeField] private DialogController _controler;

    public void NextDealog()
    {
        _controler.SetScript(_nextDealog);
        _controler.StartDialoge();
    }

    public AB_ScriptableObjectDialog _NextDealog
    {
        get
        {
            return _nextDealog;
        }
        set
        {
            _nextDealog = value;
        }
    }
}
