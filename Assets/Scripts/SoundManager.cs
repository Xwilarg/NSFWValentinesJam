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
            sounds.Add("1stYear1", audioClips[25]);
            sounds.Add("1stYear2", audioClips[26]);
            sounds.Add("2ndYear1-1", audioClips[27]);
            sounds.Add("2ndYear1-2", audioClips[28]);
            sounds.Add("2ndYear1-3", audioClips[29]);
            sounds.Add("2ndYear2-1", audioClips[30]);
            sounds.Add("2ndYear2-2", audioClips[31]);
            sounds.Add("3rdYear1", audioClips[32]);
            sounds.Add("3rdYear2", audioClips[33]);
            sounds.Add("spirit1-1", audioClips[34]);
            sounds.Add("spirit1-2", audioClips[35]);
            sounds.Add("spirit2-1", audioClips[36]);
            sounds.Add("spirit2-2", audioClips[37]);
            sounds.Add("invocation1", audioClips[38]);
            sounds.Add("invocation2", audioClips[39]);
            sounds.Add("invocation3", audioClips[40]);
            sounds.Add("invocation4", audioClips[41]);
            sounds.Add("invocation5", audioClips[42]);
            sounds.Add("invocation6", audioClips[43]);
            sounds.Add("invocation7", audioClips[44]);
            sounds.Add("end0", audioClips[45]);
        }
    }
}
