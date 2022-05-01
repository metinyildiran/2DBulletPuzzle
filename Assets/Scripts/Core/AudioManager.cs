﻿using Bullet;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Core
{
    [RequireComponent(typeof(AudioSource))]
    public class AudioManager : MonoBehaviour
    {
        private BulletThrower _bulletThrower;
        private AudioSource _audioSource;
        private AudioClip _shotSound;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();

            _shotSound = Resources.Load<AudioClip>("Audio/ShotSound");

            if (!Utils.IsThisSceneMainMenu())
            {
                _bulletThrower = FindObjectOfType<BulletThrower>();
                _bulletThrower.OnCreateBullet += PlayShotSound;
            }
        }

        private void PlayShotSound()
        {
            _audioSource.pitch = Random.Range(0.9f, 1.1f);
            _audioSource.PlayOneShot(_shotSound);
        }

        private void OnDestroy()
        {
            if (!Utils.IsThisSceneMainMenu())
            {
                _bulletThrower.OnCreateBullet -= PlayShotSound;
            }
        }
    }
}