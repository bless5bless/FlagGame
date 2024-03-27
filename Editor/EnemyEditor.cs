using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.Tilemaps;

[CanEditMultipleObjects,CustomEditor(typeof(Enemy))]
public class EnemyEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (GUILayout.Button("设置位置"))
        {
            Tilemap tilpMap = GameObject.Find("Grid/ground").GetComponent<Tilemap>();

            var allPos = tilpMap.cellBounds.allPositionsWithin;

            int min_x = 0;
            int min_y = 0;

            if(allPos.MoveNext())
            {
                Vector3Int current = allPos.Current;
                min_x = current.x;
                min_y = current.y;
            }

            Enemy enemy = target as Enemy;

            Vector3Int cellPos = tilpMap.WorldToCell(enemy.transform.position);

            enemy.RowIndex = Mathf.Abs(min_y - cellPos.y);
            enemy.ColIndex = Mathf.Abs(min_x - cellPos.x);

            enemy.transform.position = tilpMap.CellToWorld(cellPos) + new Vector3(0.5f,0.5f,-1);
        }
    }
}
