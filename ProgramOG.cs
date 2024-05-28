/*Console.OutputEncoding = System.Text.Encoding.UTF8;


// PROBLEM

// 1. OBJEKT GÅR OUT OF BOUNDS



// SAKER ATT GÖRA

// 1. Poäng-system
// 2. Kunna spara information




// VARIABLER
int[,] övrePlan = new int[8, 8];
int fullrad;
string[] ikoner = { "⬜", "⬛", "🈴", "C", "D", };
Random tärning = new Random();
int poäng = 0;
int[,] plan = new int[8, 8];
int[] spelarPos = { 0, 0 };



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
int[,] blockAnvänt = blocks[tärning.Next(12)];

for (int i = 0; i < blockAnvänt.GetLength(0); i++)
{
    övrePlan[spelarPos[0] + blockAnvänt[i, 0], spelarPos[1] + blockAnvänt[i, 1]] = 2;
}


// Spel-loop
while (true)
{
    // Skriver ut och refreshar mappen efter varje gång man rör sig eller sätter ut något
    Console.Clear();
    Console.WriteLine(Metodish.Karta(ikoner, övrePlan));
    Console.WriteLine();
    Console.WriteLine(Metodish.Karta(ikoner, plan));
    Console.WriteLine();
    Console.WriteLine(poäng);

    var key = Console.ReadKey().Key;

    for (int i = 0; i < blockAnvänt.GetLength(0); i++)
    {
        övrePlan[spelarPos[0] + blockAnvänt[i, 0], spelarPos[1] + blockAnvänt[i, 1]] = 0;
    }

    // Funkar inte just nu för att objekten är större än spelar positionen, får fixa sen

    // Flyttar objekten
    switch (key)
    {
        // Flyttar objekt uppåt
        case ConsoleKey.W or ConsoleKey.UpArrow when spelarPos[1] > 0:
            spelarPos[1]--;
            break;

        // Flyttar objekt nedåt
        case ConsoleKey.S or ConsoleKey.DownArrow when spelarPos[1] < 7:
            if (Metodish.RörelseRegler(spelarPos, blockAnvänt, plan) == true)
            {
                spelarPos[1]++;
            }
            break;

        // Flyttar objekt till vänster
        case ConsoleKey.A or ConsoleKey.LeftArrow when spelarPos[0] > 0:
            if (Metodish.RörelseRegler(spelarPos, blockAnvänt, plan) == true)
            {
                spelarPos[0]--;
            }
            break;

        // Flyttar objekt till höger
        case ConsoleKey.D or ConsoleKey.RightArrow when spelarPos[0] < 7:
            if (Metodish.RörelseRegler(spelarPos, blockAnvänt, plan) == false)
            {
                break;
            } else {
                spelarPos[0]++;
            }
            break;

        // Sätter ut objekten
        case ConsoleKey.Enter:
            bool möjligplats = true;
            for (int i = 0; i < blockAnvänt.GetLength(0); i++)
            {
                if (plan[spelarPos[0] + blockAnvänt[i, 0], spelarPos[1] + blockAnvänt[i, 1]] != 0)
                {
                    möjligplats = false;
                }
            }

            if (möjligplats == true)
            {
                for (int i = 0; i < blockAnvänt.GetLength(0); i++)
                {
                    plan[spelarPos[0] + blockAnvänt[i, 0], spelarPos[1] + blockAnvänt[i, 1]] = 2;
                }
                blockAnvänt = blocks[tärning.Next(11)];


                // Funkar ej häller
                plan = Metodish.KollaVinst(ikoner, plan, out fullrad);

                if (fullrad == 8)
                {
                    poäng++;
                }
            }
            break;
    }




    // Visar ifall man kan sätta ut ett objekt eller ej med hjälp av svarta ikoner
    for (int i = 0; i < blockAnvänt.GetLength(0); i++)
    {

        if (övrePlan[spelarPos[0] + blockAnvänt[i, 0], spelarPos[1] + blockAnvänt[i, 1]] != plan[spelarPos[0] + blockAnvänt[i, 0], spelarPos[1] + blockAnvänt[i, 1]])
        {
            övrePlan[spelarPos[0] + blockAnvänt[i, 0], spelarPos[1] + blockAnvänt[i, 1]] = 1;
        }

        else
        {
            övrePlan[spelarPos[0] + blockAnvänt[i, 0], spelarPos[1] + blockAnvänt[i, 1]] = 2;
        }
    }

}












//TEMPORÄRT TESTAR ALLT FÖR EN FORM FÖR ATT JAG INTE ORKAR SITTA MED DETTA ÄN

// ALLA FORMER
/*int[][,] föremål = {
    new int[,] { { 0, 0 }, { 1, 0 }, { 1, 1 }, { 1, 2 } },
    new int[,] { { 0, 0 }, { 1, 0 }, { 1, 1 }, { 1, 2 }, { 0, 2 } },
    new int[,] { { 0, 0 }, { 1, 0 }, { 1, 1 }, { 0, 1 } },
    new int[,] { { 0, 0 } },
    new int[,] { { 0, 0 }, { 1, 0 } },
    new int[,] { { 0, 0 }, { 0, 1 }, { 0, 2 } },
    new int[,] { { 0, 0 }, { 0, 1 }, { 0, 2 }, { 0, 3 } },
    new int[,] { { 0, 0 }, { 0, 1 }, { 0, 2 }, { 0, 4 } },
    new int[,] { { 0, 0 }, { 1, 0 }, { 1, 1 }, { 2, 1 } },
    new int[,] { { 0, 0 }, { 1, 0 }, { 1, 1 } }
}; 


// Funkar för tiden inte,  måste ändra senare. Den kör igenom alla, vilket är det jag ber den att göra just nu, men senare ska jag få den att köra random på 1 i arrayen.
for (int i = 0; i < föremål.Length; i++)
{
    int[,] IndividFöremål = föremål[i];
}


Random random = new Random();

int RandomX = random.Next(föremål.GetLength(0));
int RandomY = random.Next(föremål.GetLength(1));

int spelObjekt = random.Next(RandomX, RandomY);





    for (int a = 0; a < IndividFöremål.GetLength(0); a++)
    {
        plan[spelarPos[0] + IndividFöremål[a, 0], spelarPos[1] + IndividFöremål[a, 1]] = 2;
    } 
*/