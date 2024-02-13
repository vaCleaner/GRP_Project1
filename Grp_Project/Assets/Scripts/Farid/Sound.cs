
using UnityEngine;
[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;


    //if needed
    [Range(0f,1f)]
    public float Volume;
    [Range(.1f,3f)]
    public float pitch;

    public bool loop;

    [HideInInspector]
    public AudioSource source;


}
