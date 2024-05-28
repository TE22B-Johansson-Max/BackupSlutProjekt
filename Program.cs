


using System.ComponentModel;

Console.OutputEncoding = System.Text.Encoding.UTF8;



Metodish.Inloggning();












// VARIABLES
int[,] övrePlan = new int[8, 8];
int fullrad;
string[] ikoner = { "⬜", "⬛", "🈴", "C", "D" };
Random tärning = new Random();
int poäng = 0;
int[,] plan = new int[8, 8];
int[] spelarPos = { 0, 0 };
int liv = 3;

int[][,] blocks =
{
    new int[,] { { 0, 0 }, { 0, 1 }, { 1, 1 }, { 2, 1 }, { 2, 0 } },
    new int[,] { { 0, 0 }, { 1, 0 }, { 1, 1 }, { 1, 2 } },
    new int[,] { { 0, 0 }, { 1, 0 }, { 1, 1 }, { 1, 2 }, { 0, 2 } },
    new int[,] { { 0, 0 }, { 1, 0 }, { 1, 1 }, { 0, 1 } },
    new int[,] { { 0, 0 } },
    new int[,] { { 0, 0 }, { 1, 0 } },
    new int[,] { { 0, 0 }, { 0, 1 }, { 0, 2 } },
    new int[,] { { 0, 0 }, { 0, 1 }, { 0, 2 }, { 0, 3 } },
    new int[,] { { 0, 0 }, { 0, 1 }, { 0, 2 }, { 0, 3 }, { 0, 4 } },
    new int[,] { { 0, 0 }, { 1, 0 }, { 1, 1 }, { 2, 1 } },
    new int[,] { { 0, 0 }, { 1, 0 }, { 1, 1 } }
};
int[,] blockAnvänt = blocks[tärning.Next(blocks.Length)];

for (int i = 0; i < blockAnvänt.GetLength(0); i++)
{
    int newX = spelarPos[0] + blockAnvänt[i, 0];
    int newY = spelarPos[1] + blockAnvänt[i, 1];
    if (newX >= 0 && newX < övrePlan.GetLength(0) && newY >= 0 && newY < övrePlan.GetLength(1))
    {
        övrePlan[newX, newY] = 2;
    }
}

// Game Loop
while (true)
{
    Console.Clear();
    Console.WriteLine(Metodish.Karta(ikoner, övrePlan));
    Console.WriteLine();
    Console.WriteLine(Metodish.Karta(ikoner, plan));
    Console.WriteLine();
    Console.WriteLine("Tryck BACKSPACE om du vill använda ett av dina liv");
    Console.WriteLine();
    Console.WriteLine($"Antal liv: {liv}");
    Console.WriteLine();
    Console.WriteLine($"Poäng: {poäng}");

    var key = Console.ReadKey().Key;

    for (int i = 0; i < blockAnvänt.GetLength(0); i++)
    {
        int newX = spelarPos[0] + blockAnvänt[i, 0];
        int newY = spelarPos[1] + blockAnvänt[i, 1];
        if (newX >= 0 && newX < övrePlan.GetLength(0) && newY >= 0 && newY < övrePlan.GetLength(1))
        {
            övrePlan[newX, newY] = 0;
        }
    }

    // Move the block
    switch (key)
    {
        case ConsoleKey.W or ConsoleKey.UpArrow when spelarPos[1] > 0:
            spelarPos[1]--;
            break;
        case ConsoleKey.S or ConsoleKey.DownArrow when Metodish.RörelseRelger(spelarPos, blockAnvänt, övrePlan, "Nedåt"):
            spelarPos[1]++;
            break;
        case ConsoleKey.A or ConsoleKey.LeftArrow when spelarPos[0] > 0:
            spelarPos[0]--;
            break;
        case ConsoleKey.D or ConsoleKey.RightArrow when Metodish.RörelseRelger(spelarPos, blockAnvänt, övrePlan, "Höger"):
            spelarPos[0]++;
            break;

        case ConsoleKey.Enter:
            bool möjligplats = true;
            for (int i = 0; i < blockAnvänt.GetLength(0); i++)
            {
                int newX = spelarPos[0] + blockAnvänt[i, 0];
                int newY = spelarPos[1] + blockAnvänt[i, 1];
                if (newX < 0 || newX >= plan.GetLength(0) || newY < 0 || newY >= plan.GetLength(1) || plan[newX, newY] != 0)
                {
                    möjligplats = false;
                    break;
                }
            }
            if (möjligplats)
            {
                for (int i = 0; i < blockAnvänt.GetLength(0); i++)
                {
                    int newX = spelarPos[0] + blockAnvänt[i, 0];
                    int newY = spelarPos[1] + blockAnvänt[i, 1];
                    if (newX >= 0 && newX < plan.GetLength(0) && newY >= 0 && newY < plan.GetLength(1))
                    {
                        plan[newX, newY] = 2;
                    }
                }
                blockAnvänt = blocks[tärning.Next(blocks.Length)];
                plan = Metodish.KollaVinst(plan, ref poäng);

            }

            spelarPos = [0, 0];
            break;

        case ConsoleKey.Backspace:
            blockAnvänt = blocks[tärning.Next(blocks.Length)];
            liv -= 1;
            if (liv == 0)
            {
                Console.WriteLine($"Bra jobbat! Tyvärr har du slut på liv, men du lyckades få ihop {poäng} poäng!");
                return;
            }
            break;
    }

    // Update `övrePlan` for potential placement
    for (int i = 0; i < blockAnvänt.GetLength(0); i++)
    {
        int newX = spelarPos[0] + blockAnvänt[i, 0];
        int newY = spelarPos[1] + blockAnvänt[i, 1];
        if (newX >= 0 && newX < övrePlan.GetLength(0) && newY >= 0 && newY < övrePlan.GetLength(1))
        {
            if (övrePlan[newX, newY] != plan[newX, newY])
            {
                övrePlan[newX, newY] = 1;
            }
            else
            {
                övrePlan[newX, newY] = 2;
            }
        }
    }


}
