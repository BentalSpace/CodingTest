using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

class _230524_Q10814
{
    public class Info
    {
        public int age, joinCnt;
        public string name;

        public Info(int _age, int _joinCnt, string _name)
        {
            joinCnt = _joinCnt;
            age = _age;
            name = _name;
        }
    }
    static public void Main(string[] args)
    {
        //int cnt = int.Parse(Console.ReadLine());

        //List<Info> info = new List<Info>();

        //for (int i = 0; i < cnt; i++)
        //{
        //    string[] str = Console.ReadLine().Split();

        //    info.Add(new Info(int.Parse(str[0]), i, str[1]));
        //}
        //QuickSort(info, 0, info.Count - 1);

        //foreach (var item in info)
        //{
        //    Console.WriteLine(item.age + " " + item.name);
        //}

        // List Sort 할 때, 오버로드로 정렬 방법을 바꿀 수 있는데, 그 방법을 사용해도 좋을 듯

        // 굳이 정렬을 하려고 생각에 사로잡혀 있던게 잘못되었었음 (나이의 제한값이 정해져 있으므로 1 ~ 200)

        StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
        StringBuilder sb = new StringBuilder();

        string[] names = new string[201];
        int cnt = int.Parse(Console.ReadLine());

        for(int i = 0; i < cnt; i++)
        {
            string[] input = sr.ReadLine().Split();
            int age = int.Parse(input[0]);
            names[age] += input[1] + " ";
        }

        for(int i = 1; i < 201; i++)
        {
            if (names[i] == null)
                continue;

            string[] name = names[i].Split();

            for(int j = 0; j < name.Length - 1; j++)
            {
                sb.AppendLine($"{i} {name[j]}");
            }
        }
        sw.WriteLine(sb);

        sr.Close();
        sw.Close();
    }

    #region 1번 풀이용 함수
    public static void QuickSort(List<Info> l, int left, int right)
    {
        if (left >= right)
            return;

        int pi = Partition(l, left, right);

        QuickSort(l, left, pi - 1);
        QuickSort(l, pi + 1, right);
    }
    public static int Partition(List<Info> l, int left, int right)
    {
        int middle = (left + right) / 2;
        int pivotAge = l[middle].age;
        int pivotJoin = l[middle].joinCnt;

        int iL = left, iR = right;

        while (iL < iR)
        {
            while (iL < right)
            {
                if (ValueComparisonLeft(l[iL], pivotAge, pivotJoin))
                    iL++;
                else
                    break;
            }
            while (iR >= left)
            {
                if (ValueComparisonRight(l[iR], pivotAge, pivotJoin))
                    iR--;
                else
                    break;
            }
            if (iL < iR)
                Swap(ref l, iL, iR);
        }
        return iL;
    }
    public static bool ValueComparisonLeft(Info aI, int pivotAge, int pivotJoin)
    {
        if (aI.age < pivotAge)
            return true;
        if (aI.age == pivotAge && aI.joinCnt < pivotJoin)
            return true;
        return false;
    }
    public static bool ValueComparisonRight(Info aI, int pivotAge, int pivotJoin)
    {
        if (aI.age > pivotAge)
            return true;
        if (aI.age == pivotAge && aI.joinCnt > pivotJoin)
            return true;
        return false;
    }
    public static void Swap(ref List<Info> list, int a, int b)
    {
        Info temp = list[a];
        list[a] = list[b];
        list[b] = temp;
    }
    #endregion
}