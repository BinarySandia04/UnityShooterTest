using System;
using System.Collections.Generic;
using UnityEngine;

public static class ObjectExtension
{

    private static List<UnityEngine.Object> savedObjects = new List<UnityEngine.Object>();

    public static void DontDestroyOnLoad(this UnityEngine.Object obj)
    {
        savedObjects.Add(obj);
        UnityEngine.Object.DontDestroyOnLoad(obj);
    }

    public static void Destory(this UnityEngine.Object obj)
    {
        savedObjects.Remove(obj);
        Destory(obj);
    }

    public static List<UnityEngine.Object> GetSavedObjects()
    {
        return new List<UnityEngine.Object>(savedObjects);
    }
}