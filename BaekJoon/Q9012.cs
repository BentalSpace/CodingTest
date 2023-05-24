using System;
using System.Collections.Generic;

class Q9012
{
    static void Main1()
    {
        int cnt = int.Parse(Console.ReadLine());

        //for (int i = 0; i < cnt; i++)
        //{
        //    string str = Console.ReadLine();

        //    if (str[0] == ')')
        //    {
        //        Console.WriteLine("NO");
        //        continue;
        //    }

        //    int leftBracket = 1, rightBracket = 0;
        //    bool isComplete = true;

        //    for (int j = 1; j < str.Length; j++)
        //    {
        //        if (leftBracket == rightBracket && str[j] == ')')
        //        {
        //            Console.WriteLine("NO");
        //            isComplete = false;
        //            break;
        //        }

        //        else if (str[j] == '(')
        //        {
        //            leftBracket++;
        //        }
        //        else if (str[j] == ')')
        //            rightBracket++;
        //    }
        //    if (isComplete)
        //    {
        //        if (leftBracket == rightBracket)
        //            Console.WriteLine("YES");
        //        else
        //            Console.WriteLine("NO");
        //    }
        //}


        // Stack 이나 Queue 같은 자료구조를 사용해서 하면 더 좋게 할 수 있을듯

        for (int i = 0; i < cnt; i++)
        {
            string str = Console.ReadLine();

            if (IsVPSCheck(str))
                Console.WriteLine("YES");
            else
                Console.WriteLine("NO");
        }

        bool IsVPSCheck(string _str)
        {
            Queue<char> queue = new Queue<char>();

            for (int i = 0; i < _str.Length; i++)
            {
                if (_str[i] == '(')
                    queue.Enqueue('(');
                else if (_str[i] == ')' && queue.Count > 0)
                    queue.Dequeue();
                else if (_str[i] == ')' && queue.Count == 0)
                    return false;
            }

            if (queue.Count == 0)
                return true;
            else
                return false;
        }
    }
}
