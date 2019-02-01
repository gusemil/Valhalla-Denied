﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class SpriteManager
{
    private Font font;
    private Sprite[] sprites;
    private Sprite block;

    public Font Font { get { return font; } }

    public SpriteManager()
    {
        font = AssetDatabase.LoadAssetAtPath<Font>("Assets/Fonts/PressStart2P-Regular.ttf");
        sprites = Array.ConvertAll(AssetDatabase.LoadAllAssetsAtPath("Assets/Sprites/Scavengers_SpriteSheet.png"), item => item as Sprite);
        block = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Sprites/woodenmenu.png");
    }

    public Sprite GetSprite(int index)
    {
        if (sprites.Length > index)
            return sprites[index];

        return null;
    }

    public Sprite GetBlockSprite()
    {
        return block;
    }

    public static void CreateImage(Transform parent, Sprite sprite)
    {
        GameObject child = new GameObject();
        child.transform.SetParent(parent);
        child.AddComponent<Image>();

        Image image = child.GetComponent<Image>();
        image.sprite = sprite;

        RectTransform rect = image.GetComponent<RectTransform>();
        rect.localPosition = Vector3.zero;
        rect.localScale = new Vector3(0.75f, 0.75f, 0.75f);
    }

    public static Text CreateText(Transform parent, int size, Vector3 position, bool centered)
    {
        GameObject go = new GameObject();
        go.transform.SetParent(parent);
        go.AddComponent<Text>();

        Text text = go.GetComponent<Text>();
        text.font = GameManager.instance.SpriteManager.Font;
        text.fontSize = size;
        text.color = Color.white;
        text.horizontalOverflow = HorizontalWrapMode.Overflow;
        text.verticalOverflow = VerticalWrapMode.Overflow;

        RectTransform textTransform = text.GetComponent<RectTransform>();
        textTransform.localPosition = position;

        if (centered)
        {
            text.alignment = TextAnchor.MiddleCenter;
        }
        else
        {
            text.alignment = TextAnchor.MiddleLeft;
            textTransform.anchorMin = new Vector2(0, 0.5f);
            textTransform.anchorMax = new Vector2(0, 0.5f);
        }

        return text;
    }
}
