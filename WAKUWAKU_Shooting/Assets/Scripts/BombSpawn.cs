﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawn : MonoBehaviour
{
    [SerializeField]
    private Bomb _bomb = null;

    //爆弾の最大数
    public int _maxBombNum = 100;
    private Bomb[] _bombs = null;

    //開始時の爆弾の数
    public int _startBombNum = 5;
    //爆弾の出現時間
    public float _startSpawnTime = 5.0f;

    //爆弾の出現時間
    public int _bombsTimeIntervalCount = 10;
    //爆弾の出現時間が減る間隔
    public float _bombsTimeInterval = 0.5f;
    //最終的な爆弾の出現時間
    public float _minSpawnTime = 2.0f;


    private int _bombsTotalCount = 0;
    private int _bombsNawCount = 0;

    public void DecrementTotalbombsCount() {
        _bombsNawCount--;
    }

    void Start()
    {
        _bombsNawCount = 0;
        _bombs = new Bomb[_maxBombNum];
        for (int i = 0; i < _startBombNum; ++i)
        {
            CreateBomb();
        }
        StartCoroutine(SpawnBomb());
    }

    private void CreateBomb()
    {
        if (_bombsNawCount < _maxBombNum) {
            var i = 0;
            while (_bombs[i] != null)
            {
                i++;
            }
            _bombs[i] = Instantiate(_bomb);
            Vector3 pos = new Vector3(Random.Range(-5.2f, 5.2f), -5.0f, Random.Range(-3.2f,2.1f));
            _bombs[i].transform.Translate(pos);
            _bombsTotalCount++;
            _bombsNawCount++;

            if (_bombsTotalCount > _bombsTimeIntervalCount&& _startSpawnTime>_minSpawnTime) {
                _bombsTimeIntervalCount += 10;
                _startSpawnTime -= _bombsTimeInterval;
            }
        }
    }

    private IEnumerator CreateBombCoroutine() {
        CreateBomb();
        yield return null;//1フレーム
    }

    private IEnumerator SpawnBomb()
    {
        while (true)
        {
            yield return new WaitForSeconds(_startSpawnTime);//秒待つ
            yield return StartCoroutine(CreateBombCoroutine());
        }
    }
}
