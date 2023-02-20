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
        GameEvents._gameEvents.InitSoundAction += InitPlaySound;
    }
    public void PlaySound() => StartCoroutine(SoundEvent());
    public void InitPlaySound() => StartCoroutine(InitSoundEvent());
    public IEnumerator SoundEvent()
    {
        SoundManager.Instance.StopMusic();
        yield return new WaitForSeconds(1f);
        SoundManager.Instance.PlaySound(_alarmClip);
        yield return new WaitForSeconds(1f);
        SoundManager.Instance.PlaySound(_clip[UnityEngine.Random.Range(0, 4)]);
        yield return new WaitForSeconds(7f);
        SoundManager.Instance.PlaySound(_alarmClip);
        yield return new WaitForSeconds(1f);
        SoundManager.Instance.PlayMusic();
    }
    public IEnumerator InitSoundEvent()
    {
        SoundManager.Instance.StopMusic();
        yield return new WaitForSeconds(1f);
        SoundManager.Instance.PlaySound(_alarmClip);
        yield return new WaitForSeconds(1f);
        SoundManager.Instance.PlayMusic();
    }
    private void OnDestroy()
    {
        GameEvents._gameEvents.SoundAction -= PlaySound;
        GameEvents._gameEvents.InitSoundAction -= InitPlaySound;
    }
    private void OnApplicationQuit() => StopAllCoroutines();
}
