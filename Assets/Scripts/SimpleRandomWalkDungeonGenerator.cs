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
    private int iterations = 10;
    [SerializeField]
    public int walkLength = 10;
    [SerializeField]
    public bool startRandomlyEachIteration = true;

    protected override void RunProceduralGeneration()
    {
        HashSet<Vector2Int> floorPositions = RunRandomWalk();
        tilemapVisulizer.Clear();
        tilemapVisulizer.PaintFloorTiles(floorPositions);
    }

    protected HashSet<Vector2Int> RunRandomWalk()
    {
        var currentPosition = startPosition;
        HashSet<Vector2Int> floorPositions = new HashSet<Vector2Int>();
        for (var i = 0; i < iterations; i++)
        {
            var path = ProceduralGenerationAlgorithms.SimpleRandomWalk(currentPosition, walkLength);
            floorPositions.UnionWith(path);
            if(startRandomlyEachIteration)
            { 
               currentPosition = floorPositions.ElementAt(Random.Range(0,floorPositions.Count)); 
            }
        }
        return floorPositions;
    }
}
