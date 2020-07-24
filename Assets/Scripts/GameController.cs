using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Character[] playerCharacters;
    public Character[] enemyCharacters;
    Character currentTarget;
    bool waitingPlayerInput;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GameLoop());
    }

    [ContextMenu("Player Move")]
    public void PlayerMove()
    {
        if (waitingPlayerInput)
            waitingPlayerInput = false;
    }

    [ContextMenu("Switch character")]
    public void SwitchCharacter()
    {
        for (int i = 0; i < enemyCharacters.Length; i++) {
            // Найти текущего персонажа (i = индекс текущего)
            if (enemyCharacters[i] == currentTarget) {
                int start = i;
                ++i;
                // Идем в сторону конца массива и ищем живого персонажа
                for (; i < enemyCharacters.Length; i++) {
                    if (enemyCharacters[i].IsDead())
                        continue;

                    // Нашли живого, меняем currentTarget
                    currentTarget.GetComponentInChildren<TargetIndicator>(true).gameObject.SetActive(false);
                    currentTarget = enemyCharacters[i];
                    currentTarget.GetComponentInChildren<TargetIndicator>(true).gameObject.SetActive(true);

                    return;
                }
                // Идем от начала массива до текущего и смотрим, если там кто живой
                for (i = 0; i < start; i++) {
                    if (enemyCharacters[i].IsDead())
                        continue;

                    // Нашли живого, меняем currentTarget
                    currentTarget.GetComponentInChildren<TargetIndicator>(true).gameObject.SetActive(false);
                    currentTarget = enemyCharacters[i];
                    currentTarget.GetComponentInChildren<TargetIndicator>(true).gameObject.SetActive(true);

                    return;
                }
                // Живых больше не осталось, не меняем currentTarget
                return;
            }
        }
    }

    void PlayerWon()
    {
        Debug.Log("Player won");
    }

    void PlayerLost()
    {
        Debug.Log("Player lost");
    }

    Character FirstAliveCharacter(Character[] characters)
    {
        foreach (var character in characters) {
            if (!character.IsDead())
                return character;
        }
        return null;
    }

    bool CheckEndGame()
    {
        if (FirstAliveCharacter(playerCharacters) == null) {
            PlayerLost();
            return true;
        }

        if (FirstAliveCharacter(enemyCharacters) == null) {
            PlayerWon();
            return true;
        }

        return false;
    }

    IEnumerator GameLoop()
    {
        while (!CheckEndGame()) {
            foreach (var player in playerCharacters) {
                if (player.IsDead())
                    continue;

                Character target = FirstAliveCharacter(enemyCharacters);
                if (target == null)
                    break;

                currentTarget = target;
                currentTarget.GetComponentInChildren<TargetIndicator>(true).gameObject.SetActive(true);

                waitingPlayerInput = true;
                while (waitingPlayerInput)
                    yield return null;

                currentTarget.GetComponentInChildren<TargetIndicator>().gameObject.SetActive(false);

                player.target = currentTarget;
                player.AttackEnemy();
                while (!player.IsIdle())
                    yield return null;
            }

            foreach (var enemy in enemyCharacters) {
                if (enemy.IsDead())
                    continue;

                Character target = FirstAliveCharacter(playerCharacters);
                if (target == null)
                    break;

                enemy.target = target;
                enemy.AttackEnemy();
                while (!enemy.IsIdle())
                    yield return null;
            }
        }
    }
}
