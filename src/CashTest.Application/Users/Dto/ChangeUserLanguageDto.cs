using System.ComponentModel.DataAnnotations;

namespace CashTest.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}