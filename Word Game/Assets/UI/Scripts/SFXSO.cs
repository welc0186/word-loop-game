using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "NewSFX", menuName = "Audio/New SFX")]
public class SFXSO : ScriptableObject
{
    
    public AudioClip audioClip;
    public float volume;
    public float pitch;


#if UNITY_EDITOR

    private AudioSource previewer;

    private void OnEnable()
    {
        previewer = EditorUtility.CreateGameObjectWithHideFlags("Audio Preview", HideFlags.HideAndDontSave, typeof(AudioSource)).GetComponent<AudioSource>();
    }

    private void OnDisable()
    {
        DestroyImmediate(previewer.gameObject);
    }

    public void PlayPreview()
    {
        Play(previewer);
    }

#endif


    public AudioSource Play(AudioSource audioSourceParam = null)
    {
        if (audioClip == null)
        {
            Debug.Log("No audio clip loaded");
            return null;
        }

        
        var source = audioSourceParam;
        
        if(source == null)
        {
            var obj = new GameObject("Sound", typeof(AudioSource));
            source = obj.GetComponent<AudioSource>();
        }

        source.clip = audioClip;
        source.volume = volume;
        source.pitch = pitch;

        source.Play();
        


#if UNITY_EDITOR
        if(source != previewer)
        {
            Destroy(source.gameObject, source.clip.length/source.pitch);
        }
#else
            Destroy(source.gameObject, source.clip.length/source.pitch);
#endif

        return source;
    }


}
