using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyHolder : MonoBehaviour
{
    private List<Key.KeyType> keyList;
    AudioManager audioManager;

    private void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
        keyList = new List<Key.KeyType>();
    }

    private void AddKey(Key.KeyType keyType)
    {
        keyList.Add(keyType);
    }

    private void RemoveKey(Key.KeyType keyType)
    {
        keyList.Remove(keyType);
    }

    public bool HasKey(Key.KeyType keyType)
    {
        return keyList.Contains(keyType);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Finish"))
        {
            Destroy(collider.gameObject);
            GameManager.instance.EndGame();
        }

        Key key = collider.GetComponent<Key>();
        if (collider.GetComponent<Key>() !=null){
            
            if(key != null)
            {
                Debug.Log(key.GetKeyType() + " Key Found!");
                audioManager.Play("KeyFound");
                AddKey(key.GetKeyType());
                Destroy(key.gameObject);
            }
        }

        KeyDoor keyDoor = collider.GetComponent<KeyDoor>();
        if(keyDoor != null)
        {
           Debug.Log(keyDoor.GetKeyType() + " Door Found!");
           if (HasKey(keyDoor.GetKeyType()))
            {
                audioManager.Play("DoorOpened");
                keyDoor.OpenDoor();
                RemoveKey(keyDoor.GetKeyType());
            }
        }
    }

}
