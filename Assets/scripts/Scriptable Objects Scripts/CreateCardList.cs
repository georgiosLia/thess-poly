using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

public class CreateCardList {
    #if UNITY_EDITOR
    [MenuItem("Assets/Create/Create Card List")]
    #endif
    public static CardList Create()
    {
        #if UNITY_EDITOR
        CardList asset = ScriptableObject.CreateInstance<CardList>();

        AssetDatabase.CreateAsset(asset, "Assets/Resources/CardList.asset");
        AssetDatabase.SaveAssets();

        return asset;
        #endif
        return null;
    }
}
