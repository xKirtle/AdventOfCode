﻿using System;
using System.Runtime.InteropServices;

namespace AdventOfCode
{
    public static class Day1
    {
        public static int[] entries =
        {
            1899, 1358, 1824, 1541, 1801, 1950, 1441, 1848, 1259, 1715, 1222, 1097, 1127, 1531, 1330, 1841, 1662,
            1075, 1631, 1844, 1209, 1940, 2006, 1085, 1615, 1132, 1345, 1736, 1885, 1919, 1995, 1893, 1464, 1701,
            1373, 1390, 1717, 1238, 1707, 1088, 1566, 1971, 1804, 1630, 1920, 1445, 1948, 1123, 1917, 1944, 1448,
            1965, 1118, 1986, 1498, 1847, 1730, 1418, 1771, 1352, 1207, 1276, 1716, 1502, 1922, 1473, 1528, 1038,
            1228, 1983, 1746, 1695, 1698, 1910, 1283, 1145, 1967, 1304, 1651, 1898, 1450, 1042, 1051, 1619, 1505,
            1643, 1136, 1517, 1907, 1354, 1960, 1733, 1769, 1942, 43, 1743, 1981, 1711, 1141, 1169, 1239, 1032,
            1148, 1045, 1768, 1173, 1389, 2007, 1614, 1028, 1729, 1083, 1165, 1461, 1850, 1913, 1958, 1121, 1613,
            1341, 1055, 1510, 1054, 1064, 1875, 1429, 1799, 1570, 1293, 1702, 1313, 1576, 1050, 1340, 1117, 1342,
            1914, 1773, 1281, 1176, 1371, 1520, 1131, 1438, 1741, 1583, 1840, 1412, 1792, 1656, 1628, 1089, 1124,
            1291, 1476, 1367, 1467, 1529, 1925, 1555, 1518, 1496, 1745, 1533, 1557, 1861, 1091, 1364, 1894, 1760,
            1622, 1149, 1776, 1547, 1329, 1988, 1697, 989, 1604, 1296, 319, 1459, 1860, 1916, 1838, 527, 1370,
            1881, 1213, 2003, 1223, 1095, 1560, 1784, 1157, 1573, 1023, 1758, 1857, 1723,
        };

        public static void Part1()
        {
            int[] indices = new int[2];
            for (int i = 0; i < entries.Length; i++)
            for (int j = 0; j < entries.Length; j++)
                if (entries[i] + entries[j] == 2020)
                    indices = new int[] {i, j};

            Console.WriteLine($"Numbers are {entries[indices[0]]} and {entries[indices[1]]}");
            Console.WriteLine($"Product of both numbers is {entries[indices[0]] * entries[indices[1]]}");
        }

        public static void Part2()
        {
            int[] entriesClone = (int[]) entries.Clone();
            Array.Sort(entriesClone);
            find3Numbers(entriesClone, 2020);

            //Dar loop sobre o array (sorted) e fixar dois pontos (i + 1 e n - 1) além do arr[i].
            //Se a soma dos três for maior que o pedido, reduzir o índice do ponto no fim do array.
            //Se a soma dos três for menor que o pedido, aumentar o índice do ponto no início do array.
            //Se a soma dos três for igual ao pedido, existe um triplet no array.
            bool find3Numbers(int[] arr, int expectedResult)
            {
                int leftPoint, rightPoint;
                for (int i = 0; i < arr.Length - 2; i++)
                {
                    leftPoint = i + 1; // index of the first element, excluding i 
                    rightPoint = arr.Length - 1; // index of the last element , excluding i
                    while (leftPoint < rightPoint)
                    {
                        int sumOfIndices = arr[i] + arr[leftPoint] + arr[rightPoint];
                        if (sumOfIndices == expectedResult)
                        {
                            Console.WriteLine($"Numbers are {arr[i]}, {arr[leftPoint]} and {arr[rightPoint]}");
                            Console.WriteLine($"Product of 3 numbers is {arr[i] * arr[leftPoint] * arr[rightPoint]}");
                            return true;
                        }
                        else if (sumOfIndices < expectedResult)
                            leftPoint++;
                        else // sumOfIndices > sum 
                            rightPoint--;
                    }
                }

                return false;
            }
        }
    }
}