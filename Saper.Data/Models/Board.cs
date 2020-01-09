using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saper.Data.Models
{
    public class Board
    {
        public Board(int columns, int rows, int mines)
        {
            Rows = rows;
            Mines = mines;
            Columns = columns;
            Fields = new Field[columns * rows];
            for (int r = 0; r < rows; r++)
                for (int c = 0; c < columns; c++)
                    Fields[r * columns + c] = new Field(c, r);
            IsEmpty = true;
        }
        public int Columns { get; }
        public int Rows { get; }
        public int Mines { get; }
        public bool IsEmpty { get; set; }
        public Field[] Fields { get; }
        public Field this[int x, int y]
        {
            get => Fields[y * Columns + x];
        }
        public IEnumerable<Field> GetSurroundings(int x, int y)
        {
            for (int j = 0, x0 = x - 1; j < 3; j++, x0++)
                for (int k = 0, y0 = y - 1; k < 3; k++, y0++)
                {
                    if (x0 < 0 || y0 < 0 || x0 >= Columns || y0 >= Rows || (x == x0 && y == y0))
                        continue;
                    yield return this[x0, y0];
                }
        }
        public IEnumerable<Field> GetEnvironment(int x, int y)
        {
            for (int j = 0, x0 = x - 1; j < 3; j++, x0++)
                for (int k = 0, y0 = y - 1; k < 3; k++, y0++)
                {
                    if (x0 < 0 || y0 < 0 || x0 >= Columns || y0 >= Rows)
                        continue;
                    yield return this[x0, y0];
                }
        }
    }
}