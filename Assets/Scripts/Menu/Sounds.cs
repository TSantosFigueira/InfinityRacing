using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// Sound manager class that utilizes a dictionary to manage sounds
/**  There are two corresponding arrays: one for the dictionary's keys and the other for the sound files.
 *   Using it is as easy as retrieving the sound game object and playing the sound identified by the dictionary key*/
[RequireComponent(typeof(AudioSource))]
public class Sounds : MonoBehaviour {

    private AudioSource source;
    public string[] gameKeys;
    public AudioClip[] gameSounds;

    private Dictionary<string, AudioClip> soundsDict = new Dictionary<string, AudioClip>();

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start () {
        source = GetComponent<AudioSource>();

        // checks if the two arrays have the same length to guarantee correspondence
        if (gameKeys.Length > 0 && gameSounds.Length > 0 && gameSounds.Length == gameKeys.Length)
        {
            for (int i = 0; i < gameSounds.Length; i++)
            {
                soundsDict.Add(gameKeys[i], gameSounds[i]);
            }
        }
	}

    public void playSound(string key, float volume)
    {
        source.PlayOneShot(soundsDict[key], volume);
    }
}
