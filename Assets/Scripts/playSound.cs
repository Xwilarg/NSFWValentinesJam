﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sound;

namespace Sound
{
    namespace play
    {
        public class playSound : MonoBehaviour
        {
            public AudioSource source;
            private SoundManager sm;
            private string isPlayingName;
            private bool loop;

            private void Start()
            {
                isPlayingName = "";
                source = gameObject.GetComponent<AudioSource>();
                sm = GameObject.FindGameObjectWithTag("Sound").GetComponent<SoundManager>();
            }

            public SoundManager GetSoundManager()
            {
                return sm;
            }

            public void play(string name)
            {
                if (sm.sounds.ContainsKey(name))
                {
                    source.clip = sm.sounds[name];
                    source.Play();
                    if (loop == true)
                        source.loop = true;
                        source.clip = sm.sounds[isPlayingName];
                }
            }

            public void loopStop()
            {
                loop = false;
                source.loop = false;
            }

            public void loopPlay(string name)
            {
                if (sm.sounds.ContainsKey(name))
                {
                    source.loop = true;
                    source.clip = sm.sounds[name];
                    source.Play();
                    loop = true;
                    isPlayingName = name;
                }
            }
        }
    }
}
