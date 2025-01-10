using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MathematicalProblemsGenerator.Areas.SquareEquations.Models
{
    public class SEQ1Model 
    {
        public int wspA { get; set; } = 0;
        public int wspB { get; set; } = 0;
        public int wspC { get; set; } = 0;

        public string? Title { get; set; } = string.Empty;

        public string Info1 { get; set; } = string.Empty;
        public string Info2 { get; set; } = string.Empty;
        public string Info3 { get; set; } = string.Empty;
        public string Info4 { get; set; } = string.Empty;
        public string znakTXT { get; set; } = string.Empty;

        public bool deltaPlus {  get; set; } = false;
        public bool deltaMinus { get; set; } = false;
        public bool deltaZerro { get; set; } = false;

        public string Eq01 { get; set; } = string.Empty;
        public string Eq02 { get; set; } = string.Empty;
        public string Obl_1_1 { get; set; } = string.Empty;
        public string Obl_2_1 { get; set; } = string.Empty;

        public string WSP_A_wynik { get; set; } = string.Empty;
        public string WSP_B_wynik { get; set; } = string.Empty;

    }
}
