namespace Day08
{
    public class Screen
    {
        public Screen(int width, int height)
        {
            Width = width;
            Height = height;
            Grid = new bool[Width, Height];
        }

        public int Width { get; private set; }

        public int Height { get; private set; }

        public bool[,] Grid { get; private set; }

        public void Rect(int a, int b)
        {
            for (var i = 0; i < a; i++)
            {
                for (var j = 0; j < b; j++)
                {
                    Grid[i, j] = true;
                }
            }
        }

        public void RotateRight(int row, int shiftsCount)
        {
            shiftsCount = shiftsCount % Width;
            var tempRow = new bool[Width];

            for (var i = 0; i < Width; i++)
            {
                var current = Grid[i, row];
                var newIndex = (i + shiftsCount) % Width;
                tempRow[newIndex] = current;
            }

            for (var i = 0; i < Width; i++)
            {
                Grid[i, row] = tempRow[i];
            }
        }

        public void RotateDown(int column, int shiftsCount)
        {
            shiftsCount = shiftsCount % Height;
            var tempRow = new bool[Height];

            for (var i = 0; i < Height; i++)
            {
                var current = Grid[column, i];
                var newIndex = (i + shiftsCount) % Height;
                tempRow[newIndex] = current;
            }

            for (var i = 0; i < Height; i++)
            {
                Grid[column, i] = tempRow[i];
            }
        }
    }
}