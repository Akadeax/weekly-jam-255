using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public static SFXManager instance;
    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(this.gameObject);
    }

    [SerializeField]
    List<SFXClip> clips;

    [SerializeField]
    int channelAmount = 5;

    List<AudioSource> sources = new List<AudioSource>();

    private void Start()
    {
        for(int i = 0; i < channelAmount; i++)
        {
            AudioSource src = this.gameObject.AddComponent<AudioSource>();
            sources.Add(src);
        }
    }

    private void _PlaySFX(string name, float pitch)
    {
        if(!clips.Exists(x => x.name == name))
        {
            Debug.LogWarning($"Clip {name} does not exist!");
            return;
        }

        SFXClip clip = clips.First(x => x.name == name);
        AudioClip audioClip = clip.clip;
        AudioSource src = GetFirstEmptySrc();
        src.clip = audioClip;
        src.volume = clip.volume;
        src.pitch = pitch;
        src.Play();
    }

    public static void PlaySFX(string name)
    {
        instance._PlaySFX(name, 1);
    }

    public static void PlaySFX(string name, float pitch)
    {
        instance._PlaySFX(name, pitch);
    }

    private AudioSource GetFirstEmptySrc()
    {
        foreach(AudioSource src in sources)
        {
            if (!src.isPlaying) return src;
        }

        Debug.LogError($"Couldn't find empty audio channel. Please increase the channel amount.");
        return null;
    }
}

[System.Serializable]
public class SFXClip
{
    public string name = "Clip";
    public AudioClip clip;
    [Range(0, 1)]
    public float volume = 1f;
}