using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public sealed class SettingsPanel : MonoBehaviour
{
    [SerializeField] private GameObject _rootPanel;
    [SerializeField] private Button _buttonOpenPanel;
    [SerializeField] private Button _buttonClosePanel;
    [SerializeField] private Slider _slider;
    [SerializeField] private Text _text;
    [SerializeField] private string _name;
    [SerializeField] private AudioMixer _mixer;

    private void Start()
    {
        _rootPanel.SetActive(false);
    }

    private void OnEnable()
    {
        _mixer.GetFloat(_name, out var value);
        _text.text = value.ToString("F0");
        _slider.value = value;

        _buttonOpenPanel.onClick.AddListener(ButtonOpenPanelOnClick);
        _buttonClosePanel.onClick.AddListener(ButtonClosePanelOnClick);
        _slider.onValueChanged.AddListener(Call);
    }

    private void OnDisable()
    {
        _buttonOpenPanel.onClick.RemoveListener(ButtonOpenPanelOnClick);
        _buttonClosePanel.onClick.RemoveListener(ButtonClosePanelOnClick);
        _slider.onValueChanged.RemoveListener(Call);
    }

    private void ButtonOpenPanelOnClick()
    {
        _rootPanel.SetActive(true);
    }

    private void ButtonClosePanelOnClick()
    {
        _rootPanel.SetActive(false);
    }

    private void Call(float value)
    {
        _mixer.SetFloat(_name, value);
        _text.text = value.ToString("F0");
    }
}
