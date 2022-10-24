using System;
using System.Collections.Generic;
using System.Globalization;

namespace CoordinateComparer
{
    class Program
    {
        class DistanceComparer : IComparer<(float, float, float, float, double)>
        {
            public int Compare((float, float, float, float, double) x1y1, (float, float, float, float, double) x2y2)
            {
                return x1y1.Item5.CompareTo(x2y2.Item5);
            }
        }
        static double distance(float x1, float y1, float x2, float y2)
        {
            return Math.Sqrt(Math.Pow(x2 - x1, 2) +
                          Math.Pow(y2 - y1, 2) * 1.0);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter pair of coordinates");
            string[] pairOfPoints = Console.ReadLine().Split(' ');
            if (pairOfPoints.Length > 9)
            {
                Console.WriteLine("Pair of coordinates limit is exceeded");
                return;
            }
            var coordinatesDistance = new List<Tuple<float, float, float, float, double>>() { };
            var average=0.0;
            for (int i=0;i< pairOfPoints.Length;i++)
            {
                for(int j = i + 1; j < pairOfPoints.Length; j++)
                {
                    string[] x1y1 = pairOfPoints[i].Split(',');
                    if (x1y1.Length < 2)
                    {
                        Console.WriteLine("Please enter valid coordinates");
                        return;
                    }
                    float test = float.Parse(x1y1[1]);
                    float tes = float.Parse(x1y1[0]);
                    double test2 = Convert.ToDouble(x1y1[1]);
                    double test3 = Convert.ToDouble(x1y1[0]);
                    string[] x2y2 = pairOfPoints[j].Split(',');
                    double dist = Math.Round(distance(float.Parse(x1y1[0]), float.Parse(x1y1[1]), float.Parse(x2y2[0]), float.Parse(x2y2[1]))
               * 100.0) / 100.0;
                    average = average + dist;                    
                    coordinatesDistance.Add(new Tuple<float, float, float, float, double>(float.Parse(x1y1[0]), float.Parse(x1y1[1]), float.Parse(x2y2[0]), float.Parse(x2y2[1]), dist));

                }
            }
            coordinatesDistance.Sort((a, b) => a.Item5.CompareTo(b.Item5));
            var coordinatesDistanceArray = coordinatesDistance.ToArray();
            
            Console.WriteLine("Closest "+ String.Format(CultureInfo.InvariantCulture, "{0:0.0}",coordinatesDistanceArray[0].Item1) + ","+ String.Format(CultureInfo.InvariantCulture, "{0:0.0}", coordinatesDistanceArray[0].Item2, 1)+" "+ String.Format(CultureInfo.InvariantCulture, "{0:0.0}", coordinatesDistanceArray[0].Item3, 1)+","+ String.Format(CultureInfo.InvariantCulture, "{0:0.0}", coordinatesDistanceArray[0].Item4, 1)+" Distance "+ coordinatesDistanceArray[0].Item5);
            Console.WriteLine("Furthest " + String.Format(CultureInfo.InvariantCulture, "{0:0.0}", coordinatesDistanceArray[coordinatesDistance.Count - 1].Item1, 1) + "," + String.Format(CultureInfo.InvariantCulture, "{0:0.0}", coordinatesDistanceArray[coordinatesDistance.Count - 1].Item2, 1) + " " + String.Format(CultureInfo.InvariantCulture, "{0:0.0}", coordinatesDistanceArray[coordinatesDistance.Count - 1].Item3, 1) + "," + String.Format(CultureInfo.InvariantCulture, "{0:0.0}", coordinatesDistanceArray[coordinatesDistance.Count - 1].Item4, 1) + " Distance " + coordinatesDistanceArray[coordinatesDistance.Count - 1].Item5);
            Console.WriteLine("Average Distance " + Math.Round(average/ coordinatesDistance.Count,2));

        }
    }
}
