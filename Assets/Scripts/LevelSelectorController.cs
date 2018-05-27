//Made by Luis Bazan
//luisbernardo@golstats.com

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EnhancedUI.EnhancedScroller;

public class LevelSelectorController : MonoBehaviour, IEnhancedScrollerDelegate
{

    private List<LevelData> _data;
    public EnhancedScroller myScroller;
    public LevelCellView levelCellViewPrefab;

    public Sprite[] Levels;
    public float[] timeEstimate;
    public float[] colorEstimate;
    public bool[] leanTweenActivated;

    public void LoadLevels()
    {
        _data = new List<LevelData>();

        _data.Clear();

        for(int i = 0; i < Levels.Length; i++)
        {
            _data.Add(new LevelData { LevelImage = Levels[i], LevelNumber = i + 1, time = timeEstimate[i], colorTime = colorEstimate[i], leanTween = leanTweenActivated[i] });
        }
        myScroller.Delegate = this;
        myScroller.ReloadData();
    }

    public int GetNumberOfCells(EnhancedScroller scroller)
    {
        return _data.Count;
    }
    public float GetCellViewSize(EnhancedScroller scroller, int dataIndex)
    {
        return 50f;
    }
    public EnhancedScrollerCellView GetCellView(EnhancedScroller scroller, int
    dataIndex, int cellIndex)
    {
        LevelCellView cellView = scroller.GetCellView(levelCellViewPrefab) as
        LevelCellView;
        cellView.SetData(_data[dataIndex]);
        return cellView;
    }
    }
