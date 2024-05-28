using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
using System.Xml.Schema;

public class Metodish
{
    static public string Karta(string[] ikoner, int[,] plan)
    {
        string planString = "";

        for (int y = 0; y < plan.GetLength(0); y++)
        {
            for (int x = 0; x < plan.GetLength(1); x++)
            {
                planString += ikoner[plan[x, y]];
            }
            planString += "\n";
        }

        return planString;
    }


    static public int[,] KollaVinst(int[,] plan, ref int poäng)
    {

        // Startar om räknaren
        int fullrad = 0;


        // Kollar Rader
        for (int x = 0; x < plan.GetLength(0); x++)
        {
            for (int y = 0; y < plan.GetLength(1); y++)
            {
                if (plan[x, y] != 0)
                {
                    fullrad++;
                }
            }

            if (fullrad == 8)
            {

                for (int y = 0; y < plan.GetLength(1); y++)
                {
                    plan[x, y] = 0;
                }

                poäng++;
            }


            fullrad = 0;
        }
        // Kollar Kolumner
        for (int y = 0; y < plan.GetLength(1); y++)
        {
            for (int x = 0; x < plan.GetLength(0); x++)
            {
                if (plan[x, y] != 0)
                {
                    fullrad++;
                }
            }

            if (fullrad == 8)
            {

                for (int x = 0; x < plan.GetLength(0); x++)
                {
                    plan[x, y] = 0;
                }

                poäng++;


            }


            fullrad = 0;
        }

        return plan;



    }

    // Delvis CHAT-GPT
    static public bool RörelseRelger(int[] spelarPos, int[,] blockAnvänt, int[,] plan, string riktning)
    {
        for (int i = 0; i < blockAnvänt.GetLength(0); i++)
        {
            int newX = spelarPos[0] + blockAnvänt[i, 0];
            int newY = spelarPos[1] + blockAnvänt[i, 1];

            if (riktning == "Höger")
            {
                if (newX >= plan.GetLength(0) - 1)
                {
                    return false;
                }
            }

            if (riktning == "Nedåt")
            {
                if (newY >= plan.GetLength(1) - 1)
                {
                    return false;
                }
            }
        }
        return true;
    }




    static public bool PlaceringsCheck(int[] spelarPos, int[,] blockAnvänt, int[,] plan)
    {

        for (int i = 0; i < blockAnvänt.GetLength(0); i++)
        {
            int x = blockAnvänt[i, 0];
            int y = blockAnvänt[i, 1];


            if (plan[x, y] != 0)
            {
                return false;
            }
        }

        return true;



    }



    static public string Inloggning()
    {
        string fil = "konton.txt";

        Console.WriteLine("Har du en tidigare profil? Svara med j/n:  ");
        string svar = Console.ReadLine().ToLower();

        switch (svar)
        {
            case "j":



                break;

            case "n":


                break;




            default:
                Console.Write("Svara endast med \"j\" eller \"n\": ");
                svar = Console.ReadLine();
            break;
        }


        return "";
    }

}