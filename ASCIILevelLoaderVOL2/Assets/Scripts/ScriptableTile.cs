using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
#if UNITY_EDITOR
using UnityEditor;
#endif

[CreateAssetMenu(fileName = "NewScriptableTile", menuName = "ScriptableObjects/ScriptableTile")]
public class ScriptableTile : Tile
{
    public Sprite newSprite;

    //determines which Tiles in the vicinity are updated when this Tile is added to the Tilemap
    public override void RefreshTile(Vector3Int location, ITilemap tilemap)
    {
        base.RefreshTile(location, tilemap);
    }

    //determines what the Tile looks like on the Tilemap
    public override void GetTileData(Vector3Int location, ITilemap tilemap, ref TileData tileData)
    {
        base.GetTileData(location, tilemap, ref tileData);
        // Debug.Log(tileData.sprite);
        tileData.colliderType = ColliderType.Sprite;
        tileData.sprite = newSprite;
    }

#if UNITY_EDITOR
    [MenuItem("ScriptableObjects/ScriptableTile")]
    public static void CreateScriptableTile()
    {
        string path = EditorUtility.SaveFilePanelInProject("Save Scriptable Tile", "New Scriptable Tile", "Asset", "Save Scriptable Tile", "Assets");
        if (path == "") return;
        AssetDatabase.CreateAsset(ScriptableObject.CreateInstance<ScriptableTile>(), path);
    }
#endif

}
