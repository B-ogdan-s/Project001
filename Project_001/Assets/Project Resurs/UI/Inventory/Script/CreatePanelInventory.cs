using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePanelInventory : MonoBehaviour
{
    [SerializeField] private ScriptableObjectSaveInventory _saveInventory;
    [SerializeField] private Transform _parent;
    [ReadOnly]
    [SerializeField] private GameObject[] _inventory;
    [ReadOnly]
    [SerializeField] private float _parentStartPos;

    private void Start()
    {
        Create();
    }

    [Button(ButtonSizes.Medium)]
    public void Create()
    {
        if (_saveInventory._num > _inventory.Length)
        {
            for (int i = 0; i < _saveInventory._num; i++)
            {
                if (i >= _inventory.Length)
                {
                    AddMas();
                    _inventory[i] = Instantiate(_saveInventory._panel);
                    _inventory[i].transform.SetParent(_parent, false);
                }
            }
        }
        else if(_saveInventory._num < _inventory.Length)
        {
            for(int i = _inventory.Length - 1; i >= _saveInventory._num; i--)
            {
                Destroy(_inventory[i]);
                DecreaseMas();
            }
        }
    }

    private void AddMas()
    {
        GameObject[] newInventory = _inventory;
        _inventory = new GameObject[newInventory.Length + 1];

        for(int i = 0; i< newInventory.Length; i++)
        {
            _inventory[i] = newInventory[i];
        }
    }

    private void DecreaseMas()
    {
        GameObject[] newInventory = _inventory;
        _inventory = new GameObject[newInventory.Length - 1];

        for( int i = 0; i < _inventory.Length; i++)
        {
            _inventory[i] = newInventory[i];
        }
    }
}
