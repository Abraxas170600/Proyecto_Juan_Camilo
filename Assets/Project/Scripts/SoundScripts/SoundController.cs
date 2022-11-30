using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading.Tasks;

public class SoundController : MonoBehaviour
{
    [SerializeField] private AudioClip[] _clip;
    [SerializeField] private AudioClip _alarmClip;
    private void Awake()
    {
        GameEvents._gameEvents.SoundAction += PlaySound;
    }
    public void PlaySound()
    {
        SoundEvent();
    }
    public async void SoundEvent()
    {
        SoundManager.Instance.StopMusic();
        await Task.Delay(TimeSpan.FromSeconds(1));
        SoundManager.Instance.PlaySound(_alarmClip);
        await Task.Delay(TimeSpan.FromSeconds(1));
        SoundManager.Instance.PlaySound(_clip[UnityEngine.Random.Range(0, 4)]);
        await Task.Delay(TimeSpan.FromSeconds(7));
        SoundManager.Instance.PlaySound(_alarmClip);
        await Task.Delay(TimeSpan.FromSeconds(1));
        SoundManager.Instance.PlayMusic();
    }
    private void OnDestroy()
    {
        GameEvents._gameEvents.SoundAction -= PlaySound;
    }
}
