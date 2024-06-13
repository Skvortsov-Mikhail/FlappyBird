using UnityEngine;
using UnityEngine.UI;

public class UI_Settings : MonoBehaviour
{
    [SerializeField] private SettingsController m_SettingsController;

    [SerializeField] private Text m_DifficultText;
    [SerializeField] private Text m_VolumeText;

    private LevelController _levelController;
    private int _AddValueToNormalize = 80;

    private void OnEnable()
    {
        _levelController = m_SettingsController.LevelController;

        RefreshText();
    }

    private void Start()
    {
        m_SettingsController.ChangeDifficult += OnDifficultChanged;
        m_SettingsController.ChangeVolume += OnVolumeChanged;

        RefreshText();
    }

    private void OnDestroy()
    {
        m_SettingsController.ChangeDifficult -= OnDifficultChanged;
        m_SettingsController.ChangeVolume -= OnVolumeChanged;
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

        m_VolumeText.text = (m_SettingsController.CurrentVolume + _AddValueToNormalize).ToString();
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
                m_DifficultText.text = "High";
                m_DifficultText.color = Color.red;
                break;
        }
    }
}