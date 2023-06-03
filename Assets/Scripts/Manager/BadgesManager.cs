using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BadgesManager : MonoBehaviour, IDataPersistence
{
    [Header("Timers Badge")]
    [SerializeField]
    private Sprite _spriteTimerBlockedBadge;
    [SerializeField]
    private Sprite _spriteUnblockedBadge;
    [SerializeField]
    private Image[] _levelsTimerBadge;

    [Header("Coins Badge")]
    [SerializeField]
    private Sprite _spriteCoinUnblockedBadge;
    [SerializeField]
    private Image[] _levelsCoinBadge;




    private bool _hasUnlockedTimerBadge;
    private bool _hasUnlockedCoinBadge;


    public void SaveData(GameData data)
    {

    }

    public void LoadData(GameData data)
    {
        for (int i = 0 + 1; i <= _levelsTimerBadge.Length; i++)
        {
            data.LevelsTimerReached.TryGetValue("Level" + i.ToString(), out _hasUnlockedTimerBadge);
            if (_hasUnlockedTimerBadge)
            {
                _levelsTimerBadge[i - 1].sprite = _spriteUnblockedBadge;
            }
            else
            {
                _levelsTimerBadge[i - 1].sprite = _spriteTimerBlockedBadge;
            }

            data.CoinCollect.TryGetValue("Level" + i.ToString(), out _hasUnlockedCoinBadge);
            if (_hasUnlockedCoinBadge)
            {
                _levelsCoinBadge[i - 1].sprite = _spriteCoinUnblockedBadge;
            }
            else
            {
                _levelsCoinBadge[i - 1].sprite = _spriteTimerBlockedBadge;
            }
        }
    }
}
