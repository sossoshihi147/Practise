using UnityEngine;
using System;

namespace Oliver
{
    public class MazeGame : MonoBehaviour
    {
        private enum TileType { Road, Wall, Treasure, Exit }
        private TileType[][] maze;
        private int playerX = 0, playerY = 0;
        private int gold = 0;
        private int steps = 0;

        void Start()
        {
            InitializeMaze();
            Debug.Log("歡迎來到迷宮探險！使用 W/A/S/D 移動，找到出口！");
            PrintMaze();
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.W)) MovePlayer(-1, 0);
            if (Input.GetKeyDown(KeyCode.S)) MovePlayer(1, 0);
            if (Input.GetKeyDown(KeyCode.A)) MovePlayer(0, -1);
            if (Input.GetKeyDown(KeyCode.D)) MovePlayer(0, 1);
        }

        void InitializeMaze()
        {
            maze = new TileType[][]
            {
            new TileType[] { TileType.Road, TileType.Wall, TileType.Road, TileType.Treasure, TileType.Road },
            new TileType[] { TileType.Road, TileType.Wall, TileType.Road, TileType.Wall, TileType.Road },
            new TileType[] { TileType.Road, TileType.Road, TileType.Road, TileType.Wall, TileType.Road },
            new TileType[] { TileType.Treasure, TileType.Wall, TileType.Road, TileType.Road, TileType.Road },
            new TileType[] { TileType.Road, TileType.Road, TileType.Road, TileType.Wall, TileType.Exit }
            };
        }

        void MovePlayer(int dx, int dy)
        {
            int newX = playerX + dx;
            int newY = playerY + dy;

            if (newX < 0 || newX >= maze.Length || newY < 0 || newY >= maze[newX].Length)
            {
                Debug.Log("無法移動，超出邊界！");
                return;
            }

            if (maze[newX][newY] == TileType.Wall)
            {
                Debug.Log("無法移動，這裡是牆壁！");
                return;
            }

            playerX = newX;
            playerY = newY;
            steps++;

            if (maze[playerX][playerY] == TileType.Treasure)
            {
                gold += 10;
                maze[playerX][playerY] = TileType.Road;
                Debug.Log("你撿到了寶箱，獲得 10 金幣！目前金幣: " + gold);
            }
            else if (maze[playerX][playerY] == TileType.Exit)
            {
                Debug.Log("恭喜你找到出口！總步數: " + steps + "，總金幣: " + gold);
            }
            else
            {
                Debug.Log("你移動到新的位置: (" + playerX + ", " + playerY + ")");
            }
        }

        void PrintMaze()
        {
            for (int i = 0; i < maze.Length; i++)
            {
                string row = "";
                for (int j = 0; j < maze[i].Length; j++)
                {
                    if (i == playerX && j == playerY)
                        row += " P ";
                    else if (maze[i][j] == TileType.Road)
                        row += " . ";
                    else if (maze[i][j] == TileType.Wall)
                        row += " # ";
                    else if (maze[i][j] == TileType.Treasure)
                        row += " T ";
                    else if (maze[i][j] == TileType.Exit)
                        row += " E ";
                }
                Debug.Log(row);
            }
        }
    }
}


