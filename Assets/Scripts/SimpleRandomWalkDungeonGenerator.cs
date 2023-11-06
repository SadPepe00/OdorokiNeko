using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;
using Debug = UnityEngine.Debug;
using Random = UnityEngine.Random;

public class SimpleMapDungeonWlakGenerator : AbstractDungeonGenerator
{
    [SerializeField]
    private SimpleRandomWalkSO randomWalkParameters;

    protected override void RunProceduralGeneration()
    {
        HashSet<Vector2Int> floorPositions = RunRandomWalk();
        tilemapVisulizer.Clear();
        tilemapVisulizer.PaintFloorTiles(floorPositions);
        WallGenerator.CreateWalls(floorPositions,tilemapVisulizer);
    }

    protected HashSet<Vector2Int> RunRandomWalk()
    {
        var currentPosition = startPosition;
        HashSet<Vector2Int> floorPositions = new HashSet<Vector2Int>();
        for (var i = 0; i < randomWalkParameters.iterations; i++)
        {
            var path = ProceduralGenerationAlgorithms.SimpleRandomWalk(currentPosition, randomWalkParameters.walkLength);
            floorPositions.UnionWith(path);
            if(randomWalkParameters.startRandomlyEachIteration)
            { 
               currentPosition = floorPositions.ElementAt(Random.Range(0,floorPositions.Count)); 
            }
        }
        return floorPositions;
    }
}
