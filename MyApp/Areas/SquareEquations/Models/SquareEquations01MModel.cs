using System.ComponentModel.DataAnnotations;

namespace MathematicalProblemsGenerator.Areas.SquareEquations.Models
{

    public class SquareEquations01M
    {
        public string wspA { get; set; } = string.Empty;
        public string wspB { get; set; } = string.Empty;
        public string wspC { get; set; } = string.Empty;

        public string? Title { get; set; } = string.Empty;

        public string Info1 { get; set; } = string.Empty;
        public string Info2 { get; internal set; } = string.Empty;
        public string Info3 { get; internal set; } = string.Empty;
        public string Info4 { get; internal set; } = string.Empty;
        public string Info5 { get; internal set; } = string.Empty;

        public string znak1TXT { get; set; } = string.Empty;
        public string znak2TXT { get; set; } = string.Empty;
        public string Eq01 { get; set; } = string.Empty;
        public string Eq02 { get; set; } = string.Empty;
        public string Obl_1_1 { get; set; } = string.Empty;
        public string Obl_2_1 { get; set; } = string.Empty;

        public string WSP_A_wynik { get; set; } = string.Empty;
        public string WSP_B_wynik { get; set; } = string.Empty;
       
    }
}
