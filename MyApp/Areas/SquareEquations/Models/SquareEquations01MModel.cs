namespace MathematicalProblemsGenerator.Areas.SquareEquations.Models
{
    public class SquareEquations01M
    {
        public string wspA { get; set; } = string.Empty;
        public string wspATest { get; set; } = string.Empty;
        public string wspB { get; set; } = string.Empty;
        public string wspC { get; set; } = string.Empty;

        public string? Title { get; set; } = string.Empty;

        public string Info1 { get; set; } = string.Empty;
        public string Info2 { get; internal set; } = string.Empty;
        public string Info3 { get; internal set; } = string.Empty;
        public string Info4 { get; internal set; } = string.Empty;
        public string Info5 { get; internal set; } = string.Empty;
        public string Info6 { get; internal set; } = string.Empty;

        public string Info7 { get; internal set; } = string.Empty;

        public string wspAInDelta { get; internal set; } = string.Empty;
        public string wspBInDelta { get; internal set; } = string.Empty;
        public string wspCInDelta { get; internal set; } = string.Empty;

        public string deltaLiczbowo { get; internal set; } = string.Empty;

        public string znak1TXT { get; set; } = string.Empty;
        public string znak2TXT { get; set; } = string.Empty;
        public string Eq01 { get; set; } = string.Empty;
        public string Eq01WzorGora { get; set; } = string.Empty;
        public string Eq01Wzorsrodek { get; set; } = string.Empty;
        public string Eq01WzorDol { get; set; } = string.Empty;

        public string Eq01wynikGora1 { get; set; } = string.Empty;
        public string Eq01wynikGora2 { get; set; } = string.Empty;
        public string Eq01wynikDol1 { get; set; } = string.Empty;

        public string Eq02 { get; set; } = string.Empty;
        public string Obl_1_1 { get; set; } = string.Empty;
        public string Obl_2_1 { get; set; } = string.Empty;

        public string WSP_A_wynik { get; set; } = string.Empty;
        public string WSP_B_wynik { get; set; } = string.Empty;
        public bool deltaPlus { get; internal set; }
        public bool deltaZero { get; internal set; }
        public bool deltaMinus { get; internal set; }

        public string Eq01wynik1 { get; internal set; }

        public string imageToView { get; set; } = String.Empty;
        public string wspBX { get; internal set; }
        public string Eq01wynik2 { get; internal set; }
    }
}