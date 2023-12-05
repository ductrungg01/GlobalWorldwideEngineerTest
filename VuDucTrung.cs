using System;
using System.Collections.Specialized;

class VuDucTrung
{
    public struct Point
    {
        public float x;
        public float y;
        public float z;

        public bool ApproxEquals(Point p, float epsilon = 0.00001f)
        {
            return (Math.Abs(x - p.x) < epsilon) && (Math.Abs(y - p.y) < epsilon) && (Math.Abs(z - p.z) < epsilon);
        }
    }

    // Question 1
    // Time to solve: 10mins 
    public static string FizzBuzz(int turns)
    {
        string result = string.Empty;

        for (int i = 1; i <= turns; i++)
        {
            if (i % 3 == 0)
            {
                result += "Fizz";
            }

            if (i % 5 == 0)
            {
                result += "Buzz";
            }

            if (i % 3 != 0 && i % 5 != 0)
            {
                result += i.ToString();
            }

            result += "\n";
        }

        return result;
    }

    // Question 2
    // Time to solve: 20mins
    public static string UnrollMatrix(int[] matrix, int rows, int columns)
    {
        if (matrix.Length != rows * columns)
        {
            throw new ArgumentException("Invalid matrix size");
        }

        int top = 0, bottom = rows - 1, left = 0, right = columns - 1;
        string result = "";

        while (top <= bottom && left <= right)
        {
            // top 
            for (int i = left; i <= right; i++)
            {
                result += matrix[top * columns + i] + ",";
            }
            top++;

            // right 
            for (int i = top; i <= bottom; i++)
            {
                result += matrix[i * columns + right] + ",";
            }
            right--;

            // bottom 
            if (top <= bottom)
            {
                for (int i = right; i >= left; i--)
                {
                    result += matrix[bottom * columns + i] + ",";
                }
                bottom--;
            }

            // left 
            if (left <= right)
            {
                for (int i = bottom; i >= top; i--)
                {
                    result += matrix[i * columns + left] + ",";
                }
                left++;
            }
        }

        result = result.TrimEnd(',');

        return result;
    }

    // Question 3
    // Time to solve: 40mins
    public static Point[] OptimizeMesh(Point[] mesh, float epsilon)
    {
        List<Point> optimizedMesh = new List<Point>();

        foreach (var point in mesh)
        {
            bool foundEqual = false;
            Point averagedPoint = point;

            for (int i = 0; i < optimizedMesh.Count; i++) 
            {
                Point optimizedPoint = optimizedMesh[i];

                if (point.ApproxEquals(optimizedPoint, epsilon))
                {
                    // Points are approximately equal, collapse them
                    averagedPoint = new Point
                    {
                        x = (point.x + optimizedPoint.x) / 2,
                        y = (point.y + optimizedPoint.y) / 2,
                        z = (point.z + optimizedPoint.z) / 2
                    };

                    foundEqual = true;

                    // replace the "non-optimized point"
                    optimizedMesh[i] = averagedPoint;
                    break;
                }
            }

            if (!foundEqual)
            {
                optimizedMesh.Add(point);
            }
        }

        return optimizedMesh.ToArray();
    }


    // Question 4
    // Time to solve: 5mins
    public static int Fib(int n)
    {
        if (n < 2) return n;

        // fi: fibonacci value at index i
        // f2: f(i - 2)
        // f1: f(i - 1)
        int f2 = 0, f1 = 1, fi = 0;

        for (int i = 2; i <= n; i++)
        {
            fi = f2 + f1;
            f2 = f1;
            f1 = fi;
        }

        return fi;
    }

    static void Main()
    {
        
    }
}