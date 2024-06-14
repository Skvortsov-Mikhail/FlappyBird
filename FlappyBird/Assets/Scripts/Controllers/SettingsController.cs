using System;
using UnityEngine;
using UnityEngine.Audio;
using Zenject;

public class SettingsController : MonoBehaviour
{
    public Action<int> ChangeDifficult;
    public Action<float> ChangeVolume;

    [SerializeField] private AudioMixer m_SoundsMixer;

    private int _difficultLevel = 1;
    private float _currentVolume = 20;
    public float CurrentVolume => _currentVolume;

    private readonly string _difficultKey = "difficult";
    private readonly string _volumeKey = "volume";

    private LevelController _levelController;
    [Inject]
    public void Construct(LevelController levelController)
    {
        _levelController = levelController;
    }

    private void Start()
    {
        LoadDifficult();
        LoadVolume();
    }

    #region Difficult

    public void NextDifficult()
    {
        _difficultLevel++;

        if (_difficultLevel > 3)
        {
            _difficultLevel = 1;
        }

        ChangeDifficult?.Invoke(_difficultLevel);

        SaveDifficult();
    }

    public void PreviousDifficult()
    {
        _difficultLevel--;

        if (_difficultLevel < 1)
        {
            _difficultLevel = 3;
        }

        ChangeDifficult?.Invoke(_difficultLevel);

        SaveDifficult();
    }

    private void SaveDifficult()
    {
        PlayerPrefs.SetInt(_difficultKey, _difficultLevel);

        _levelController.SetCurrentLevel(_difficultLevel);
    }

    private void LoadDifficult()
    {
        _difficultLevel = PlayerPrefs.GetInt(_difficultKey);

        _levelController.SetCurrentLevel(_difficultLevel);
    }

    #endregion

    #region Volume

    public void NextVolume()
    {
        if (_currentVolume == 20) return;

        _currentVolume += 10;

        ChangeVolume?.Invoke(_currentVolume);

        SaveVolume();
    }

    public void PreviousVolume()
    {
        if (_currentVolume == -80) return;

        _currentVolume -= 10;

        ChangeVolume?.Invoke(_currentVolume);

        SaveVolume();
    }

    private void SaveVolume()
    {
        PlayerPrefs.SetFloat(_volumeKey, _currentVolume);

        m_SoundsMixer.SetFloat("_volumeMixer", _currentVolume);
    }

    private void LoadVolume()
    {
        _currentVolume = PlayerPrefs.GetFloat(_volumeKey);

        m_SoundsMixer.SetFloat("_volumeMixer", _currentVolume);
    }

    #endregion
}