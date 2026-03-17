using UnityEngine;
using System;
public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource _flapSource;
    [SerializeField] private AudioSource _scoreSource;
    [SerializeField] private AudioSource _dieSource;

    private void OnEnable()
    {
        GameEventHandler.OnFlap += PlayFlap;
        GameEventHandler.OnScore += PlayScore;
        GameEventHandler.OnDie += PlayDie;
    }

    private void OnDisable()
    {
        GameEventHandler.OnFlap -= PlayFlap;
        GameEventHandler.OnScore -= PlayScore;
        GameEventHandler.OnDie -= PlayDie;  
    }

    private void PlayFlap()
    {
        _flapSource.Play();
    }

    private void PlayScore()
    {
        _scoreSource.Play();
    }

    private void PlayDie()
    {
        _dieSource.Play();
    }

}
