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
        var toggle = !_animator.GetBool("PlayCC6b");
        _animator.SetBool("PlayCC6b", toggle);

        if( toggle == false ) {
            AudioEnd();
        }
    }

    public void AudioBegin() {
        _source.Play();
    }

    public void AudioEnd() {
        _source.Stop();
        _source.time = 0;
    }
}
