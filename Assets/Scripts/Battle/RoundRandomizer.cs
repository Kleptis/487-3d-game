using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundRandomizer : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip[] sounds;
    [SerializeField]
    private AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
        source.clip = sounds[Random.Range(0, sounds.Length)];
        source.Play();
    }
}
