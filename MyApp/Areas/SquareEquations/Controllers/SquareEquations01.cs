using Microsoft.AspNetCore.Mvc;
using System.Reflection.Emit;
using MathematicalProblemsGenerator.Areas.SquareEquations.Models;


using Microsoft.EntityFrameworkCore.Sqlite.Query.Internal;
using System.Web.Helpers;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.Extensions.Localization;
using System;
using System.Drawing;
using System.IO;

namespace MathematicalProblemsGenerator.Areas.SquareEquations.Controllers
{
    public class SquareEquations01 : Controller
    {
        
            
            
            private readonly ILogger<SquareEquations01> _logger;
        private readonly IStringLocalizer<SquareEquations01> _localizer;
        CommonParts commonParts = new CommonParts();
        public SquareEquations01(ILogger<SquareEquations01> logger, IStringLocalizer<SquareEquations01> localizer)
        {
            _logger = logger;
            _localizer = localizer;
        }

        public IActionResult Index()
        {




            SquareEquations01M squareEquations01M = new SquareEquations01M();
            int canvasWidth = 400;
            int canvasHeight = 400;
            using (Bitmap image = new Bitmap(canvasWidth, canvasHeight))
            {
                using (Graphics g = Graphics.FromImage(image))
                {
                    Color white = Color.White;
                    Color black = Color.Black;
                    g.Clear(white);
                    Pen forLine = new Pen(black, 1);
                    Pen forCart = new Pen(Color.Blue, 1);
                    g.DrawLine(forLine, 0, canvasWidth / 2, canvasHeight, canvasWidth / 2);
                    g.DrawLine(forLine, canvasHeight / 2, 0, canvasHeight / 2, canvasWidth);
                    int step = 10;
                    do
                    {
                        g.DrawLine(forLine, step, (canvasWidth / 2) - 1, step, (canvasWidth / 2) + 1);
                        g.DrawLine(forLine, (canvasWidth / 2) - 1, step, (canvasWidth / 2) + 1, step);
                        step = step + 10;
                    } while (step < canvasWidth);

                    //strałki                    
                    g.DrawLine(forLine, canvasWidth, (canvasWidth / 2), canvasWidth - 10, (canvasWidth / 2) - 2);
                    g.DrawLine(forLine, canvasWidth, (canvasWidth / 2), canvasWidth - 10, (canvasWidth / 2) + 2);

                    g.DrawLine(forLine, (canvasWidth / 2), 0, (canvasWidth / 2) - 2, 10);
                    g.DrawLine(forLine, (canvasWidth / 2), 0, (canvasWidth / 2) + 2, 10);
                    //parabola
                    int lastY = 0;
                    int lastX = 0;
                    int wynikY = 0;
                  

                }
                IFormFile ufile;
         

                Guid guid = Guid.NewGuid();

                var fileName = Path.GetFileName(guid + ".bmp");
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\images", fileName);
                image.Save(filePath);
                squareEquations01M.imageToView = guid + ".bmp";

            }



            double krok = 0;
         List<int> wspolczynniki = [0, 0, 0];
           
            int wspA = 0;
            int wspB = 0;
            int wspC = 0;
            do
            {

                wspolczynniki  = commonParts.GenerujWspolczynniki();
                wspA = wspolczynniki[0];
                wspB = wspolczynniki[1];
                wspC = wspolczynniki[2];
            } while (wspA == 0);

            double gora = wspC - wspA;
            double wynik = gora / wspB;
            string wynikTXT = Math.Round(wynik, 2).ToString();
            string Wynik1PoczatekTXT = string.Empty;
            string Wynik1UlamekGora1TXT = string.Empty;

            squareEquations01M.Title = "Square Equations Part 1";// _localizer["Title"];
            squareEquations01M.wspA = wspA.ToString();
            squareEquations01M.wspBX = wspB.ToString() + "x";
            squareEquations01M.wspB = wspB.ToString();
            squareEquations01M.wspC = wspC.ToString();

            switch (wspB)
            {
                case int n when n > 0:
                    {
                        squareEquations01M.znak1TXT = "+";
                        squareEquations01M.wspBInDelta = "(" + wspB.ToString() + " * " + wspB.ToString() + ")";
                    }

                    break;

                case int n when n < 0:
                    {
                        squareEquations01M.wspBInDelta = "((" + wspB.ToString() + ") * (" + wspB.ToString() + "))";
                    }

                    break;

                case int n when n == 0:
                    {
                        squareEquations01M.znak1TXT = ""; squareEquations01M.wspB = "";
                    }

                    break;
            }

            switch (wspC)
            {
                case int n when n > 0:
                    {
                        squareEquations01M.znak2TXT = "+";
                        squareEquations01M.wspCInDelta = wspC.ToString();
                    }

                    break;

                case int n when n < 0:
                    {
                        squareEquations01M.wspCInDelta = "(" + wspC.ToString() + ")";
                    }

                    break;

                case int n when n == 0:
                    {
                        squareEquations01M.znak1TXT = "";
                        squareEquations01M.wspCInDelta = "";
                    }

                    break;
            }

            if (wspA < 0)
            { squareEquations01M.wspAInDelta = "(" + wspA.ToString() + ")"; }
            else
            {
                squareEquations01M.wspAInDelta = wspA.ToString();
            }
            squareEquations01M.Info1 = "Rozwiązanie";
            squareEquations01M.Info2 = "Współczynniki: ";
            squareEquations01M.Info3 = "Obliczamy deltę ze wzoru:";
            squareEquations01M.Info7 = "Wykres";
            double delta = (wspB * wspB) - 4 * (wspA * wspC);
            squareEquations01M.deltaLiczbowo = delta.ToString();

            if (delta > 0)
            {
                squareEquations01M.Info4 = "Ponieważ delta jest dodatnia, równanie ma dwa różne rozwiązania rzeczywiste.";
                squareEquations01M.deltaPlus = true;
                squareEquations01M.deltaZero = false;
                squareEquations01M.deltaMinus = false;

                squareEquations01M.Eq01 = "";
                double wynikGora1 = (0 - wspB) - Math.Sqrt(delta);
                double wynikGora2 = (0 - wspB) + Math.Sqrt(delta);
                double wynikDol1 = 4 * wspA;
                squareEquations01M.Eq01wynikGora1 = Math.Round(wynikGora1, 2).ToString();
                squareEquations01M.Eq01wynikGora2 = Math.Round(wynikGora2, 2).ToString();
                squareEquations01M.Eq01wynikDol1 = Math.Round(wynikDol1, 2).ToString();

                int wynikX0 = wspC;
                squareEquations01M.Info6 = "Przecięcie paraboli z osią Y, znajduje się w punkcie " + wspC.ToString();
                squareEquations01M.Eq01wynik1 = Math.Round(wynikGora1 / wynikDol1, 2).ToString();
                squareEquations01M.Eq01wynik2 = Math.Round(wynikGora2 / wynikDol1, 2).ToString();
              
                doWykresu wspolrzedna = new doWykresu();
                IList<doWykresu> Punkty = new List<doWykresu>();

                int X = -200;
                double XX = -10;
                int Y = 0;
                do
                {
                    Y = (int)(wspA * (XX * XX) + wspB * (XX) + wspC);


                    wspolrzedna = new doWykresu()
                    {
                        x = X,
                        y = Y,
                        punkty = 0

                    };

                    Punkty.Add(wspolrzedna);
                    krok = krok++;
                    X = X + 1;
                    XX = XX + 0.05;
                } while (X < 200);


                using (Bitmap image = new Bitmap(canvasWidth, canvasHeight))
                {
                    using (Graphics g = Graphics.FromImage(image))
                    {
                        Color white = Color.White;
                        Color black = Color.Black;
                        g.Clear(white);
                        Pen forLine = new Pen(black, 1);
                        Pen forCart = new Pen(Color.Blue, 1);
                        g.DrawLine(forLine, 0, canvasWidth / 2, canvasHeight, canvasWidth / 2);
                        g.DrawLine(forLine, canvasHeight / 2, 0, canvasHeight / 2, canvasWidth);
                        int step = 10;
                        do
                        {
                            g.DrawLine(forLine, step, (canvasWidth / 2) - 1, step, (canvasWidth / 2) + 1);
                            g.DrawLine(forLine, (canvasWidth / 2) - 1, step, (canvasWidth / 2) + 1, step);
                            step = step + 10;
                        } while (step < canvasWidth);

                        //strałki                    
                        g.DrawLine(forLine, canvasWidth, (canvasWidth / 2), canvasWidth - 10, (canvasWidth / 2) - 2);
                        g.DrawLine(forLine, canvasWidth, (canvasWidth / 2), canvasWidth - 10, (canvasWidth / 2) + 2);

                        g.DrawLine(forLine, (canvasWidth / 2), 0, (canvasWidth / 2) - 2, 10);
                        g.DrawLine(forLine, (canvasWidth / 2), 0, (canvasWidth / 2) + 2, 10);
                        //parabola
                        int lastY = 0;
                        int lastX = 0;
                        int wynikY = 0;
                        List<int> lines = new List<int>();
                        foreach (var item in Punkty)
                        {
                            wynikY = Math.Abs(item.y);
                            lines.Add(wynikY);
                        }
                        var theMaxValues = (int)lines.Max() / 400;
                        int TheY = 0;
                        for (int i = 0; i < 400; i++)
                        {
                            var point = Punkty[i];

                            int pointX = i;
                            int pointY =0- ((point.y) * 2) + 200;

                            g.DrawLine(forCart, lastX, lastY, pointX, pointY);

                            lastY = pointY;
                            lastX = pointX;
                        }

                    }
                    IFormFile ufile;
                    MemoryStream ms = new MemoryStream();

                    Guid guid = Guid.NewGuid();

                    var fileName = Path.GetFileName(guid + ".bmp");
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\images", fileName);
                    image.Save(filePath);
                    squareEquations01M.imageToView = guid + ".bmp";

                }

                // (-b - √Δ)
            }
            if (delta == 0)
            {
                squareEquations01M.deltaPlus = false;
                squareEquations01M.deltaZero = true;
                squareEquations01M.deltaMinus = false;
                squareEquations01M.Info4 = "Ponieważ delta jest równa  0 , równanie ma jedno rozwiązanie rzeczywiste.";

                squareEquations01M.Eq01 = "";
                double wynikGora1 = (0 - wspB) ;
                
                double wynikDol1 = 4 * wspA;
                squareEquations01M.Eq01wynikGora1 = Math.Round(wynikGora1, 2).ToString();
                squareEquations01M.Eq01wynikDol1 = Math.Round(wynikDol1, 2).ToString();




            }
            if (delta < 0)
            {
                squareEquations01M.deltaPlus = false;
                squareEquations01M.deltaZero = false;
                squareEquations01M.deltaMinus = true;
                squareEquations01M.Info4 = "Ponieważ delta jest ujemna, równanie nie ma rozwiązania rzeczywistego.";
            }





      

         
         
         



            return View(squareEquations01M);
        }
        /*
        private List<int> GenerujWspolczynniki()
        {
            Random random = new Random();
            int wspA = 0;
            int wspB = 0;
            int wspC = 0;
            var a = random.Next(-30, 30);
            wspA = random.Next(-30, 30);
            wspB = random.Next(-30, 30);
            wspC = random.Next(-30, 30);
            return new List<int> { wspA, wspB, wspC };
        }
        */
    }
    public class doWykresu()
    { 
        public int x { get; set; }
        public int y { get; set; }

        public int punkty { get; set; }
    }
}