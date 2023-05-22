using System;

class Q1018
{
    static void Main()
    {
        int[] chessSize = new int[2];
        int firstBMinCnt = -1, firstWMinCnt = -1;

        char chessCheck = 'B';

        chessSize = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        string[] chessWStart = new string[chessSize[0]];
        string[] chessBStart;

        for (int i = 0; i < chessSize[0]; i++)
        {
            chessWStart[i] = Console.ReadLine();
        }
        chessBStart = chessWStart;

        for(int i = 0; i < chessSize[0] - 7; i++)
        {
            for(int j = 0; j < chessSize[1] - 7; j++)
            {
                int BMin = 0, WMin = 0;
                for (int i2 = 0; i2 < 8; i2++)
                {
                    for (int j2 = 0; j2 < 8; j2++)
                    {
                        if (chessBStart[i2 + i][j2 + j] != chessCheck)
                        {
                            BMin++;
                        }
                        if (chessWStart[i2 + i][j2 + j] == chessCheck)
                        {
                            WMin++;
                        }
                        ChessCheckSwap(ref chessCheck);
                    }
                    ChessCheckSwap(ref chessCheck);
                }

                if (firstBMinCnt == -1 || firstBMinCnt > BMin)
                    firstBMinCnt = BMin;
                if (firstWMinCnt == -1 || firstWMinCnt > WMin)
                    firstWMinCnt = WMin;
            }
        }
        if (firstBMinCnt > firstWMinCnt)
            Console.WriteLine(firstWMinCnt);
        else
            Console.WriteLine(firstBMinCnt);
    }

    public static void ChessCheckSwap(ref char chessCheck)
    {
        if (chessCheck == 'B')
            chessCheck = 'W';
        else
            chessCheck = 'B';
    }
}