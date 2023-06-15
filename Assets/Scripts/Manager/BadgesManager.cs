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

    [Header("Fire Badge")]
    [SerializeField]
    private Sprite _spriteFireUnblockedBadge;
    [SerializeField]
    private Image[] _levelsFireBadge;

    [Header("Sprite Levels")]
    [SerializeField]
    private GameObject[] _levelsImages;

    private bool _hasUnlockedTimerBadge;
    private bool _hasUnlockedCoinBadge;
    private bool _hasBeatTheLevel;
    private bool _hasUnlockedTheLevel;


    public void SaveData(GameData data)
    {

    }

    public void LoadData(GameData data)
    {
        
        for (int i = 1; i <= _levelsTimerBadge.Length; i++)
        {
            Color tmp = new Color(0, 0, 0, 0.7f);

            data.LevelsUnlocked.TryGetValue("Level" + i, out _hasUnlockedTheLevel);
            data.LevelsBeaten.TryGetValue("Level" + i, out _hasBeatTheLevel);
            data.LevelsTimerReached.TryGetValue("Level" + i, out _hasUnlockedTimerBadge);
            data.CoinCollect.TryGetValue("Level" + i, out _hasUnlockedCoinBadge);

            if (_hasUnlockedTheLevel)
            {

                _levelsImages[i - 1].SetActive(true);

                if (_hasBeatTheLevel)
                {
                    _levelsFireBadge[i - 1].sprite = _spriteFireUnblockedBadge;
                }
                else
                {
                    _levelsFireBadge[i - 1].sprite = _spriteTimerBlockedBadge;
                    _levelsFireBadge[i - 1].color = tmp;
                }

                if (_hasUnlockedTimerBadge)
                {
                    _levelsTimerBadge[i - 1].sprite = _spriteUnblockedBadge;
                }
                else
                {
                    _levelsTimerBadge[i - 1].sprite = _spriteTimerBlockedBadge;
                    _levelsTimerBadge[i - 1].color = tmp;
                }

                if (_hasUnlockedCoinBadge)
                {
                    _levelsCoinBadge[i - 1].sprite = _spriteCoinUnblockedBadge;
                }
                else
                {
                    _levelsCoinBadge[i - 1].sprite = _spriteTimerBlockedBadge;
                    _levelsCoinBadge[i - 1].color = tmp;
                }
            }
            else
            {
                _levelsFireBadge[i - 1].gameObject.SetActive(false);
                _levelsTimerBadge[i - 1].gameObject.SetActive(false);
                _levelsCoinBadge[i - 1].gameObject.SetActive(false);
                _levelsImages[i - 1].SetActive(false);
            }
        }
    }
}
