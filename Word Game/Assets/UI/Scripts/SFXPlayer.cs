using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXPlayer : MonoBehaviour
{
    [SerializeField] private SFXSO sound;

    public void PlaySound()
    {
        sound.Play();
    }

}
