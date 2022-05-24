using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace TowerDefense.Model
{
    public class PathFinder
    {
        private readonly int _startRow;
        private readonly int _startCol;

        private readonly int _destRow;
        private readonly int _destCol;

        private readonly int _rowCount;
        private readonly int _colCount;

        private Position _startPosition;
        private Position _endPosition;

        private readonly GameBoard _grid;

        private readonly bool[,] _visited;

        private readonly Dictionary<Position, Position> _parents = new Dictionary<Position, Position>();
        private LinkedList<Position> _shortestPath = new LinkedList<Position>();

        private readonly int[] dRow = { -1, 0, 1, 0 };
        private readonly int[] dCol = { 0, 1, 0, -1 };
        
        public PathFinder(GameBoard igrid,int istart_row, int istart_col, int idest_row, int idest_col)
        {
            _grid = igrid;

            _startRow = istart_row;
            _startCol = istart_col;

            _destRow = idest_row;
            _destCol = idest_col;

            _rowCount = _grid.MapHeight;
            _colCount = _grid.MapWidth;

            _visited = new bool[_grid.MapHeight, _grid.MapWidth];
        }

        private void GatherShortestPath()
        {
            Position current = _endPosition;

            while (current != _startPosition)
            {
                _shortestPath.AddFirst(current);
                current = _parents[current];
            }
        }

        private bool IsValid(int row, int col)
        {
            if (row < 0 || col < 0 || row >= _rowCount || col >= _colCount)
                return false;

            if (_visited[row, col])
                return false;

            if (_grid.GetObjects(row, col).Count == 0)
                return true;

            if (!_grid.GetObjects(row, col)[0].Stepable)
                return false;

            return true;
        }

        private void BFS()
        {

            Queue<Position> q = new Queue<Position>();

            Position fst = new Position(_startRow, _startCol);

            _startPosition = fst;

            q.Enqueue(fst);
            _visited[_startRow, _startCol] = true;


            while (q.Count != 0)
            {
                Position cell = q.Peek();

                int x = cell.X;
                int y = cell.Y;

                if (x == _destRow && y == _destCol)
                {
                    _endPosition = cell;
                    //_shortestPath.AddFirst(_endPosition);
                    GatherShortestPath();
                    q.Clear();
                    return;
                }

                q.Dequeue();

                for (int i = 0; i < 4; i++)
                {
                    int adjx = x + dRow[i];
                    int adjy = y + dCol[i];

                    if (IsValid(adjx, adjy))
                    {
                        Position tmp = new Position(adjx, adjy);

                        q.Enqueue(tmp);
                        _parents[tmp] = cell;

                        _visited[adjx, adjy] = true;
                    }
                }
            }

        }
        public LinkedList<Position> GetShortestPath()
        {
            BFS();
            return _shortestPath;
        }

        public static bool InRange(int sx, int sy, int dx, int dy)
        {
            return Math.Abs(dx - sx) <= 1 && Math.Abs(dy - sy) <= 1;
        }
    }
}
