<Query Kind="Program" />

void Main()
{
	
}



public class Solution
{
	public int MaxPoints(Point[] points)
	{
		if (points.Length < 2) return points.Length;

		var max = 0;

		var duplicates = new Dictionary<Tuple<int, int>, int>();


		for (int i = 0; i < points.Length; i++)
		{
			var tuple = Tuple.Create(points[i].x, points[i].y);
			if (!duplicates.ContainsKey(tuple))
			{
				duplicates.Add(tuple, 1);
			}
			else
			{
				var v = duplicates[tuple];
				v++;
				duplicates[tuple] = v;
				max = Math.Max(max, v);
			}

			for (int j = i + 1; j < points.Length; j++)
			{
				var p1 = points[i];
				var p2 = points[j];

				if (p1.x == p2.x && p1.y == p2.y)
				{
					continue;
				}

				var num = 0;
				var line = new Line(p1, p2);
				for (var k = 0; k < points.Length; k++)
				{
					if (line.Include(points[k])) num++;
				}

				max = Math.Max(max, num);
			}
		}

		return max;
	}


	class Line
	{
		public long A { get; private set; }
		public long B { get; private set; }
		public long C { get; private set; }

		public Line(Point p1, Point p2)
		{
			A = 0L + p2.y - p1.y;
			B = 0L + p1.x - p2.x;
			C = 0L + -A * p1.x - B * p1.y;
		}

		public bool Include(Point p)
		{
			return A * p.x + B * p.y == -C;
		}
	}
}

public class Point
{
	public int x;
	public int y;
}



/*

Given n points on a 2D plane, find the maximum number of points that lie on the same straight line.

Example 1:

Input: [[1,1],[2,2],[3,3]]
Output: 3
Explanation:
^
|
|        o
|     o
|  o  
+------------->
0  1  2  3  4
Example 2:

Input: [[1,1],[3,2],[5,3],[4,1],[2,3],[1,4]]
Output: 4
Explanation:
^
|
|  o
|     o        o
|        o
|  o        o
+------------------->
0  1  2  3  4  5  6
NOTE: input types have been changed on April 15, 2019. Please reset to default code definition to get new method signature.


*/
