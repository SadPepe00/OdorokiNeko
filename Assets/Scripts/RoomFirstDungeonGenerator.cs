using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : SimpleRandomDungeonWalkGenerator
{
    [SerializeField]
    private int minRoomWidth = 4, minRoomHeight = 4;
    [SerializeField]
    private int dungeonWidth = 20, dungeonHeight = 20;
    [SerializeField]
    [Range(0,10)]
    private int offset = 1;
    [SerializeField]
    private bool randomWalkRooms = false;

    protected override void RunProceduralGeneration()
    {
        CreateRooms();
    }

    private void CreateRooms()
    {
        var roomsList = ProceduralGenerationAlgorithms.BinarySpacePartitioning(new BoundsInt((Vector3Int)startPosition,new Vector3Int(dungeonWidth,dungeonHeight,0)),minRoomWidth,minRoomHeight);
         
        HashSet<Vector2Int> floor = new HashSet<Vector2Int>();
        floor = CreatSimpleRooms(roomsList);

        tilemapVisulizer.PaintFloorTiles(floor);
        WallGenerator.CreateWalls(floor, tilemapVisulizer);
    }

    private HashSet<Vector2Int> CreatSimpleRooms(List<BoundsInt> roomsList)
    {
        HashSet<Vector2Int> floor = new HashSet<Vector2Int>();
        foreach (var room in roomsList)
        {
            for (int col = offset; col < room.size.x; col++)
            {
                for (int row = 0; row < room.size.y-offset; row++)
                {
                    Vector2Int position = (Vector2Int)room.min + new Vector2Int(col, row);
                    floor.Add(position);
                }
            }
        }
        return floor;
    }
}
