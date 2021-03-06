﻿using UnityEngine;
using System.Collections;
using UnityEditor;
using System.IO;
using System;

public class CreateAsset : Editor
{

    [MenuItem("CreateAsset/Level")]
    static void CreateLevel()
    {
        // 实例化类  Levels 
        ScriptableObject levels = ScriptableObject.CreateInstance<Level>();

        // 如果实例化Levels类为空，返回
        if (!levels)
        {
            Debug.LogWarning("Levels not found");
            return;
        }

        // 自定义资源保存路径
        string path = Application.dataPath + "/Resources/assetFile";

        // 如果项目总不包含该路径，创建一个
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }

        //将类名 characters 转换为字符串
        //拼接保存自定义资源（.asset） 路径
        path = string.Format("Assets/Resources/assetFile/{0}.asset", (typeof(Level).ToString()));

        // 生成自定义资源到指定路径
        AssetDatabase.CreateAsset(levels, path);
    }
}

