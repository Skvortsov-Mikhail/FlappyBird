using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class UI_Settings : MonoBehaviour
{
    [SerializeField] private Text m_DifficultText;
    [SerializeField] private Text m_VolumeText;

    private int _AddValueToNormalize = 80;

    private LevelController _levelController;
    private SettingsController _settingsController;
    [Inject]
    public void Construct(LevelController levelController, SettingsController settingsController)
    {
        _levelController = levelController;
        _settingsController = settingsController;
    }

    private void OnEnable()
    {
        RefreshText();
    }

    private void Start()
    {
        _settingsController.ChangeDifficult += OnDifficultChanged;
        _settingsController.ChangeVolume += OnVolumeChanged;

        RefreshText();
    }

    private void OnDestroy()
    {
        _settingsController.ChangeDifficult -= OnDifficultChanged;
        _settingsController.ChangeVolume -= OnVolumeChanged;
    }

    private void OnDifficultChanged(int level)
    {
        GetDifficultText(level);
    }

    private void OnVolumeChanged(float volume)
    {
        m_VolumeText.text = (volume + _AddValueToNormalize).ToString();
    }

    private void RefreshText()
    {
        GetDifficultText(_levelController.CurrentLevel);

        m_VolumeText.text = (_settingsController.CurrentVolume + _AddValueToNormalize).ToString();
    }

    private void GetDifficultText(int level)
    {
        switch (level)
        {
            case 1:
                m_DifficultText.text = "Easy";
                m_DifficultText.color = Color.green;
                break;
            case 2:
                m_DifficultText.text = "Medium";
                m_DifficultText.color = Color.yellow;
                break;
            case 3:
                m_DifficultText.text = "Hard";
                m_DifficultText.color = Color.red;
                break;
        }
    }
}