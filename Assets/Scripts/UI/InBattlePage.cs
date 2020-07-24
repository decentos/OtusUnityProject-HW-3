using UnityEngine;
using UnityEngine.UI;

public class InBattlePage : MonoBehaviour
{
    public GameController Controller;
    public Button AttackButton;
    public Button SwitchButton;

    private void Awake()
    {
        AttackButton.onClick.AddListener(OnAttackButtonClick);
        SwitchButton.onClick.AddListener(() => Controller.SwitchCharacter());
    }

    private void OnAttackButtonClick()
    {
        Controller.PlayerMove();
    }
}
