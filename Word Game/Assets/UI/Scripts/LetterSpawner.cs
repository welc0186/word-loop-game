using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterSpawner : MonoBehaviour
{

    [SerializeField] private Letter letterPrefab;
    [SerializeField] private char letterName;

    private bool firstFrame;

    void Awake()
    {
        firstFrame = true;
    }

    void Update()
    {
        if(firstFrame)
        {
            firstFrame = false;
            SpawnLetter(letterName);
        }
    }

    public Letter SpawnLetter(char letterName)
    {
        Letter newLetter = Instantiate(letterPrefab.gameObject, this.transform).GetComponent<Letter>();
        newLetter.SetName(letterName);
        return newLetter;
    }

}
