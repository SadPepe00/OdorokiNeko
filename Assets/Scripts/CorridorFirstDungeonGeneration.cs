using System;

using System.Collections.Generic;
using System.Linq;

using UnityEngine;
using UnityEngine.UIElements;


public class CorridorFirstRandomGenerator : SimpleRandomDungeonWalkGenerator
{
    [SerializeField]
    private int corridorLength = 14, corridorCount = 5;
    [SerializeField]
    [Range(0.1f, 1)]
    private float roomPercent = 0.8f;

    private Dictionary<Vector2Int, HashSet<Vector2Int>> roomsDictionary = new Dictionary<Vector2Int, HashSet<Vector2Int>>();
    private HashSet<Vector2Int> floorPositions, corridorPositions;
    private DataManager data_Manager;

    [SerializeField]
    private GameObject mainCharacter;
    [SerializeField]
    private GameObject roomEnemy;
    [SerializeField]
    private GameObject portal;

    private void Start()
    {
        tilemapVisulizer.Clear();
        data_Manager = FindObjectOfType<DataManager>();

        if (data_Manager.level_num == 2)
        {
            data_Manager.ChangeMusic("lvl");
        }
        
        if (data_Manager.level_num == 11)
        {
            data_Manager.ChangeMusic("boss");
        }

        RunProceduralGeneration();
    }

    protected override void RunProceduralGeneration()
    {
        tilemapVisulizer.Clear();
        ClearEntities();
        CorridorFirstGeneration();
        SpawnMainCharacter();
        SpawnEnemies();
    }

    private void ClearEntities()
    {

        GameObject[] targetEnemy = GameObject.FindGameObjectsWithTag("Enemy");
        var targetPlayer = GameObject.FindWithTag("Player");
        var targetPortal = GameObject.FindWithTag("Portal");
        for (var i = 0; i < targetEnemy.Length - 1; i++)
        {
            Destroy(targetEnemy[i]);
        }
        Destroy(targetPortal);
        Destroy(targetPlayer);
    }

    private void SpawnEnemies()
    {
        //var roomFloorsToSpawn = roomsDictionary.ElementAt(UnityEngine.Random.Range(0, roomsDictionary.Count)).Value;
        //for (var i = 0; i < 10; i++)
        //{
        //    var position = roomFloorsToSpawn.ElementAt(UnityEngine.Random.Range(0, roomFloorsToSpawn.Count));
        //    Instantiate(roomEnemy, new Vector3Int(position.x, position.y, -1), roomEnemy.transform.rotation);
        //}
        //var portal_position = roomFloorsToSpawn.ElementAt(UnityEngine.Random.Range(0, roomFloorsToSpawn.Count));
        //Instantiate(portal, new Vector3Int(portal_position.x, portal_position.y, -1), roomEnemy.transform.rotation);
        //1 �������
        //2 ���
        for (var j = 0; j < 3; j++)
        {
            var rooms_to_spawn = roomsDictionary.ElementAt(UnityEngine.Random.Range(0, roomsDictionary.Count)).Key;
            for (var i = 0; i < 5; i++)
            {
                var position = roomsDictionary[rooms_to_spawn].ElementAt(UnityEngine.Random.Range(0, roomsDictionary[rooms_to_spawn].Count));
                Instantiate(roomEnemy, new Vector3Int(position.x, position.y, -1), roomEnemy.transform.rotation);
            }
        }
        var roomFloorsToSpawn = roomsDictionary.ElementAt(UnityEngine.Random.Range(0, roomsDictionary.Count)).Value;
        var portal_position = roomFloorsToSpawn.ElementAt(UnityEngine.Random.Range(0, roomFloorsToSpawn.Count));
        Instantiate(portal, new Vector3Int(portal_position.x, portal_position.y, -1), roomEnemy.transform.rotation);
    }
    private void SpawnMainCharacter()
    {
        //var roomFloorsToSpawn = roomsDictionary.ElementAt(UnityEngine.Random.Range(0, roomsDictionary.Count)).Value;
        //var position = roomFloorsToSpawn.ElementAt(UnityEngine.Random.Range(0, roomFloorsToSpawn.Count));
        Instantiate(mainCharacter, new Vector3Int(startPosition.x, startPosition.y, -1), roomEnemy.transform.rotation);
    }

    private void CorridorFirstGeneration()
    {
        HashSet<Vector2Int> floorPositions = new HashSet<Vector2Int>();
        HashSet<Vector2Int> potentialRoomPositions = new HashSet<Vector2Int>();

        CreateCorridors(floorPositions, potentialRoomPositions);

        HashSet<Vector2Int> roomPositions = CreateRooms(potentialRoomPositions);

        List<Vector2Int> deadEnds = FindAllDeadEnds(floorPositions);

        CreateRoomsAtDeadEnds(deadEnds, roomPositions);

        floorPositions.UnionWith(roomPositions);

        tilemapVisulizer.PaintFloorTiles(floorPositions);
        WallGenerator.CreateWalls(floorPositions, tilemapVisulizer);
    }

    private void CreateRoomsAtDeadEnds(List<Vector2Int> deadEnds, HashSet<Vector2Int> roomFloors)
    {
        foreach (var position in deadEnds)
        {
            if (!(roomFloors.Contains(position)))
            {
                var room = RunRandomWalk(randomWalkParameters, position);
                roomFloors.UnionWith(room);
            }
        }
    }

    private List<Vector2Int> FindAllDeadEnds(HashSet<Vector2Int> floorPositions)
    {
        List<Vector2Int> deadEnds = new List<Vector2Int>();
        foreach (var position in floorPositions)
        {
            int neighboursCount = 0;
            foreach (var direction in Direction2D.cardinalDirectionList)
            {
                if (floorPositions.Contains(position + direction))
                {
                    neighboursCount++;
                }
            }
            if (neighboursCount == 1)
            {
                deadEnds.Add(position);
            }
        }
        return deadEnds;
    }

    private HashSet<Vector2Int> CreateRooms(HashSet<Vector2Int> potentialRoomPositions)
    {
        HashSet<Vector2Int> roomPositions = new HashSet<Vector2Int>();
        int roomToCreateCount = Mathf.RoundToInt(potentialRoomPositions.Count * roomPercent);

        List<Vector2Int> roomsToCreate = potentialRoomPositions.OrderBy(x => Guid.NewGuid()).Take(roomToCreateCount).ToList();
        ClearRoomData();
        foreach (var roomPosition in roomsToCreate)
        {
            var roomFloor = RunRandomWalk(randomWalkParameters, roomPosition);

            SaveRoomData(roomPosition, roomFloor);
            roomPositions.UnionWith(roomFloor);
        }
        return roomPositions;
    }

    private void SaveRoomData(Vector2Int roomPosition, HashSet<Vector2Int> roomFloor)
    {
        roomsDictionary[roomPosition] = roomFloor;
    }

    private void ClearRoomData()
    {
        roomsDictionary.Clear();
    }


    private void CreateCorridors(HashSet<Vector2Int> floorPositions, HashSet<Vector2Int> potentialRoomPositions)
    {
        var currentPosition = startPosition;
        potentialRoomPositions.Add(currentPosition);
        for (int i = 0; i < corridorCount; i++)
        {
            var corridor = ProceduralGenerationAlgorithms.RandomWalkCorridor(currentPosition, corridorLength);
            currentPosition = corridor[corridorCount - 1];
            potentialRoomPositions.Add(currentPosition);
            floorPositions.UnionWith(corridor);
        }
        corridorPositions = new HashSet<Vector2Int>(floorPositions);
    }
}
