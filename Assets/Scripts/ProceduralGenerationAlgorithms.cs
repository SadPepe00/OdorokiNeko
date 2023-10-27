using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ProceduralGenerationAlgorithms
{
    public static HashSet<Vector2Int> SimpleRandomWalk(Vector2Int startPosition, int walkLength)
    {
        HashSet<Vector2Int> path = new HashSet<Vector2Int>();
        path.Add(startPosition);
        var prevPosition = startPosition;
        for (var i = 0; i < walkLength; i++)
        {
            var newPostition = prevPosition + Direction2D.GetRandomCardinalDirection();
            path.Add(newPostition);
            prevPosition = newPostition;
        }
        return path;
    }
}

public static class Direction2D
{
    public static List<Vector2Int> cardinalDirectionList = new List<Vector2Int>
    {
        new Vector2Int(0,1),//up
        new Vector2Int(1,0),//right
        new Vector2Int(0,-1),//down
        new Vector2Int(-1,0),//left
    };

    public static Vector2Int GetRandomCardinalDirection()
    {
            return cardinalDirectionList[Random.Range(0,cardinalDirectionList.Count)];
    }
}