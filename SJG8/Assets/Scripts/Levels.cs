using UnityEngine;
using System;
using System.Collections.Generic;

public enum EnemyType
{
    TrueEnemy,
    falseEnemy
}
[System.Serializable]
public struct WavaData
{

    public EnemyType type;
    //生成点
    public Vector2 bornPoint;
}
[System.Serializable]
public struct Wave       //每波怪物的设定
{
    public WavaData []enemyData;
}
public class Level : ScriptableObject
{
    public List<Wave> waves; 
}
