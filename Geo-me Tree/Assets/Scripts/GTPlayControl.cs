using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GTPlayControl : MonoBehaviour
{
    AudioSource _source;
    Animator _animator;

    void Awake() {
        _source = GetComponent<AudioSource>();
        _animator = GetComponent<Animator>();
    }

    public void Play() {
        _animator.SetTrigger("PlayCC6");
    }

    public void AudioBegin() {
        _source.Play();
    }
}
