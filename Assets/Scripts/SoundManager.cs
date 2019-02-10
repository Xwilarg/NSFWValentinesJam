using System.Collections.Generic;
using System;
using UnityEngine;

namespace Sound
{
    public class SoundManager : MonoBehaviour
    {
        [SerializeField]
        private AudioClip[] audioClips;
        public Dictionary<string, AudioClip> sounds;

        private void Start()
        {
            sounds = new Dictionary<string, AudioClip>();

            sounds.Add("breathing", audioClips[0]);
            sounds.Add("dmgClothe", audioClips[1]);
            sounds.Add("dedStudent", audioClips[2]);
            sounds.Add("dedTeacher", audioClips[3]);
            sounds.Add("doorLocked", audioClips[4]);
            sounds.Add("doorOpen", audioClips[5]);
            sounds.Add("eatClothe", audioClips[6]);
            sounds.Add("evilDoor", audioClips[7]);
            sounds.Add("lockedDoorOpen", audioClips[8]);
            sounds.Add("dmgSoul", audioClips[9]);
            sounds.Add("menuBack", audioClips[10]);
            sounds.Add("menuConfirm", audioClips[11]);
            sounds.Add("footstep", audioClips[12]);
            sounds.Add("intro", audioClips[13]);
            sounds.Add("end1", audioClips[14]);
            sounds.Add("end2", audioClips[15]);
            sounds.Add("end3", audioClips[16]);
            sounds.Add("duoCG", audioClips[17]);
            sounds.Add("invoCthulhu", audioClips[18]);
            sounds.Add("dedSoul", audioClips[19]);
            sounds.Add("cum1", audioClips[20]);
            sounds.Add("cum2", audioClips[21]);
            sounds.Add("cum3", audioClips[22]);
            sounds.Add("cum4", audioClips[23]);
            sounds.Add("cum5", audioClips[24]);
        }
    }
}
