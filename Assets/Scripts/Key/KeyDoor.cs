using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDoor : MonoBehaviour
{
    [SerializeField]
    private Key.KeyType keyType;

    public Key.KeyType GetKeyType()
    {
        return keyType;
    }

    internal void OpenDoor()
    {
        gameObject.SetActive(false);
    }
}
