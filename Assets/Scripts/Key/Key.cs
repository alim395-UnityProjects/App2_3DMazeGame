using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField]
    private KeyType keyType;

    public KeyType GetKeyType()
    {
        return keyType;
    }

    public enum KeyType
    {
        Red, Green, Blue
    }
}
