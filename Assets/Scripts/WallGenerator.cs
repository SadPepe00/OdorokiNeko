using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class WallGenerator
{
    public static void CreateWalls(HashSet<Vector2Int> floorPositions, TilemapVisulizer tilemapVisulizer)
    {
        var basicWallPositions = FindWallsInDirections(floorPositions, Direction2D.cardinalDirectionList);
        var cornerWallPositions = FindWallsInDirections(floorPositions, Direction2D.diagonalDirectionList);
        CreateBasicWalls(tilemapVisulizer, basicWallPositions,floorPositions);
        CreateCornerWalls(tilemapVisulizer, cornerWallPositions, floorPositions);
    }

    private static void CreateCornerWalls(TilemapVisulizer tilemapVisulizer, HashSet<Vector2Int> cornerWallPositions, HashSet<Vector2Int> floorPositions)
    {
        foreach (var position in cornerWallPositions) 
        {
            string neighboursBinaryType = "";
            foreach (var direction in Direction2D.eightDirectionsList)
            {
                var neighbourPosition = position + direction;
                if (floorPositions.Contains(neighbourPosition))
                {
                    neighboursBinaryType += "1";
                }
                else
                {
                    neighboursBinaryType +="0";
                }
            }
            tilemapVisulizer.PaintSingleCornerWall(position, neighboursBinaryType);
        }
    }

    private static void CreateBasicWalls(TilemapVisulizer tilemapVisulizer, HashSet<Vector2Int> basicWallPositions, HashSet<Vector2Int> floorPositions)
    {
        foreach (var position in basicWallPositions)
        {
            string neighboursBinaryValue="";
            foreach (var direction in Direction2D.cardinalDirectionList)
            {
                var neighboutPosition = position + direction;
                if (floorPositions.Contains(neighboutPosition))
                {
                    neighboursBinaryValue += "1";
                }
                else
                {
                    neighboursBinaryValue += "0";
                }
            }
            tilemapVisulizer.PaintSingleBasicWall(position,neighboursBinaryValue);
        }

    }

    private static HashSet<Vector2Int> FindWallsInDirections(HashSet<Vector2Int> floorPositions, List<Vector2Int> directionsList)
    {
        HashSet<Vector2Int> wallPositions = new HashSet<Vector2Int>();
        foreach (var position in floorPositions)
        {
            foreach (var direction in directionsList)
            {
                var neighbourPosition = position + direction;
                if (floorPositions.Contains(neighbourPosition)==false)
                {
                    wallPositions.Add(neighbourPosition);
                }
            }
        }
        return wallPositions;
    }
}
