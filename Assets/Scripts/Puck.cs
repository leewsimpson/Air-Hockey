using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puck : MonoBehaviour {

    public AudioClip Hit1Sound;
    public AudioClip Hit2Sound;
    public AudioClip GoalSound;

    private AudioSource audioSource;
    private DateTime lastHitTime;
    private Vector3 start;

    public void Start()
    {
        audioSource = GetComponent<AudioSource>();
        start = transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if ((DateTime.Now-lastHitTime).Milliseconds>100)  // wait a bit - avoid repetitive collisions
        {
            audioSource.volume = collision.relativeVelocity.magnitude / 40;
            if (collision.gameObject.name.StartsWith("Player"))
            {
                audioSource.PlayOneShot(Hit2Sound);
            }
            else
            {
                audioSource.PlayOneShot(Hit1Sound);
            }
            lastHitTime = DateTime.Now;
        }
    }

    public void PlayGoalSound()
    {
        audioSource.PlayOneShot(GoalSound);
    }

    public void Update()
    {
        if (transform.position.y < 0)
        {
            Reset();
        }
    }

    public void Reset()
    {
        transform.position = start;
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
    }
}
