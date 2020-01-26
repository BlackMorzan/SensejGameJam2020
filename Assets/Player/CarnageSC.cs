﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarnageSC : MonoBehaviour
{
    [SerializeField]
    Animator m_Animator;
    [SerializeField]
    AudioSource BGSound;
    [SerializeField]
    AudioClip Song;
    [SerializeField]
    ParticleSystem Blood;

    private float ending = 0;
    private bool TheEnd = false;

    private void Update()
    {

        if (ending < Time.time && TheEnd)
            SceneManager.LoadScene("Menu", LoadSceneMode.Single);



        Debug.Log(ending + "/" + Time.time);

    }
    private void Start()
    {
        //BGsound need to have normal song on start
        BGSound.Play();
    }
    public void Spooky()
    {
        //no going back
        // sound for testing in BGsound and Song
        BGSound.clip = Song;

        BGSound.Play();
    }

    public void Carnage()
    {
        //Animation Particle
        // animation - separate heat and make is ragdoll??
        Blood.transform.parent = null;
        Blood.Play();



        m_Animator.SetBool("pain", true);
        ending = Time.time + 5f;
        Debug.Log(ending + "/" + Time.time);
        TheEnd = true;

        foreach (Transform child in this.GameObject) if (child.CompareTag("Zone")) { }

    }
}
