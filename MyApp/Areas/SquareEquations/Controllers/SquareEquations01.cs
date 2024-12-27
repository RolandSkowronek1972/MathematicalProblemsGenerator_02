using Microsoft.AspNetCore.Mvc;
using System.Reflection.Emit;
using MathematicalProblemsGenerator.Areas.SquareEquations.Models;
//[Route("area/{controller=Home}/{action=Index}/{id?}")] ;

namespace MyApp.Areas.SquareEquations.Controllers
{
    public class SquareEquations01 : Controller
    {
        public IActionResult Index()
        {
            SquareEquations01M squareEquations01M = new SquareEquations01M();
            int wspA = 0;
            int wspB = 0;
            int wspC = 0;
            string Info1 = string.Empty;
            string znakTXT = string.Empty;
            string Eq01 = string.Empty;
            string Eq02 = string.Empty;
            string Obl_1_1 = string.Empty;
            string Obl_2_1 = string.Empty;
            string WSP_A_wynik = string.Empty;
            string WSP_B_wynik = string.Empty;

            double gora = wspC - wspA;
            double wynik = gora / wspB;
            string wynikTXT = Math.Round(wynik, 2).ToString();
            string Wynik1PoczatekTXT = string.Empty;
            string Wynik1UlamekGora1TXT = string.Empty;
            /*    Wynik1Poczatek.Text = "";8
                Wynik1UlamekGora1.Text = "";
                Wynik1UlamekDol1.Text = "";
                Wynik1UlamekSrodek1.Text = "";
                Wynik1UlamekGora2.Text = "";
                Wynik1UlamekDol2.Text = "";
                Wynik1UlamekSrodek2.Text = "";
                Wynik1UlamekruwnaSie1.Text = "";
                Wynik1UlamekruwnaSie2.Text = "";

                Wynik1.Text = "";
                Wynik1Poczatek2.Text = "";
                Wynik2UlamekGora1.Text = "";
                Wynik2UlamekDol1.Text = "";
                Wynik2UlamekSrodek1.Text = "";
                Wynik2UlamekGora2.Text = "";
                Wynik2UlamekDol2.Text = "";
                Wynik2UlamekSrodek2.Text = "";
                Wynik2UlamekruwnaSie1.Text = "";
                Wynik2UlamekruwnaSie2.Text = "";
                Wynik2UlamekruwnaSie3.Text = "";
                Wynik2UlamekSrodek3.Text = "";
                Wynik2UlamekGora3.Text = "";
                Wynik2UlamekDol3.Text = "";
                Wynik2.Text = "";
*/
            Random random = new Random();
            var a = random.Next(-30, 30);
            wspA = random.Next(-30, 30);
            wspB = random.Next(-30, 30);
            wspC = random.Next(-30, 30);
            squareEquations01M.Title = "Square Equations Part 1";
            squareEquations01M.wspA = wspA.ToString();
            squareEquations01M.wspB = wspB.ToString() +"x";
            squareEquations01M.wspC = wspC.ToString();


            if (wspB > 0) { squareEquations01M.znak1TXT = "+"; }
            if (wspB == 0) { squareEquations01M.znak1TXT = ""; squareEquations01M.wspB = ""; }
            if (wspC > 0) { squareEquations01M.znak2TXT = "+"; } 
            if (wspC == 0) { squareEquations01M.znak2TXT = ""; squareEquations01M.wspC = ""; }
            squareEquations01M.Info1 = "Rozwiązanie";
            squareEquations01M.Info2 = "Współczynniki: ";
            double delta = (wspB * wspB) - 4 * (wspA * wspC);
            if (delta>0)
            {
                squareEquations01M.Info3 = "Ponieważ delta jest dodatnia, równanie ma dwa różne rozwiązania rzeczywiste.";
            }
            /*
               Info1.Text = "  Wartość bezwzględna liczby to jej odległość od zera na osi liczbowej. Zawsze jest nieujemna. W naszym przypadku, wyrażenie będzie równe " + wspC + ", gdy:";

               if (wspB == 1)
               {
                   Eq01.Text = wspA.ToString() + znakTXT + "x = " + Math.Abs(wspC).ToString();
                   Eq02.Text = wspA.ToString() + znakTXT + "x = -" + Math.Abs(wspC).ToString();
               }
               else
               {
                   Eq01.Text = wspA.ToString() + znakTXT + wspB.ToString() + "x = " + Math.Abs(wspC).ToString(); ;
                   Eq02.Text = wspA.ToString() + znakTXT + wspB.ToString() + "x = -" + Math.Abs(wspC).ToString();
               }

               */
            /*
               if (wspA == 1)
               {
                   Obl_1_1.Text = wspA.ToString() + znakTXT + wspB.ToString() + "x = " + wspC.ToString();
                   // Obl_1_2.Text
                   Obl_1_1.Text = wspA.ToString() + znakTXT + wspB.ToString() + "x = " + wspC.ToString();
                   // Obl_1_2.Text
               }
               else
               {
                   String WSP_A_wynik = string.Empty;
                   String WSP_B_wynik = string.Empty;

                   double gora = wspC - wspA;
                   double wynik = gora / wspB;
                   string wynikTXT = Math.Round(wynik, 2).ToString();
                   Wynik1Poczatek.Text = wspA.ToString() + znakTXT + wspB.ToString() + "x = " + wspC.ToString() + "  =>    x₁ = ";

                   if (wspA < 0)
                   {
                       Wynik1UlamekGora1.Text = wspC.ToString() + "  " + wspA.ToString() + "";
                   }
                   else
                   {
                       Wynik1UlamekGora1.Text = wspC.ToString() + " - " + wspA.ToString();

                   }


                   Wynik1UlamekDol1.Text = wspB.ToString();
                   Wynik1UlamekSrodek1.Text = "―――――";

                   Wynik1UlamekGora2.Text = (wspC - wspA).ToString();
                   Wynik1UlamekDol2.Text = wspB.ToString();
                   Wynik1UlamekSrodek2.Text = "――――――";
                   Wynik1UlamekruwnaSie1.Text = " = ";
                   Wynik1UlamekruwnaSie2.Text = " = ";

                   Wynik1.Text = wynikTXT;
                   //x
                   gora = -wspC - wspA;
                   wynik = gora / wspB;

                   wynikTXT = Math.Round(wynik, 2).ToString();
                   Wynik1Poczatek2.Text = wspA.ToString() + znakTXT + wspB.ToString() + "x = -" + wspC.ToString() + "  =>    x₂ = ";
                   if (wspA < 0)
                   {
                       Wynik2UlamekGora1.Text = (0 - wspC).ToString() + "  " + wspA.ToString();
                   }
                   else
                   {
                       Wynik2UlamekGora1.Text = (0 - wspC).ToString() + " - " + wspA.ToString();

                   }
                   Wynik2UlamekDol1.Text = wspB.ToString();
                   Wynik2UlamekSrodek1.Text = "―――――";

                   Wynik2UlamekGora2.Text = (-wspC - wspA).ToString();
                   Wynik2UlamekDol2.Text = wspB.ToString();
                   Wynik2UlamekSrodek2.Text = "――――――";
                   Wynik2UlamekruwnaSie1.Text = " = ";
                   Wynik2UlamekruwnaSie2.Text = " = ";

                   Wynik2.Text = wynikTXT;

                   Odp01.Text = "Zbiorem rozwiązań równania  jest { " + Wynik1.Text + " , " + Wynik2.Text + "}.";
                   Odp02.Text = "UWAGA!!!! Wartości liczbowe rozwiązania są warościami zaokrąlonymi do swóch miejsc po przecinku.";
               }
               // "Ponieważ delta jest większa od zera (Δ > 0), równanie ma dwa różne pierwiastki rzeczywiste."
            */
            return   this.View(squareEquations01M);
            //var result = squareEquations01M.ToJson();
            //return new JsonResult(result);
         //   return View();
           // return View("Areas\\SquareEquations\\Views\\SquareEquations01\\Index.cshtml");
        }
      
    }
}
