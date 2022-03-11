using System.ComponentModel.DataAnnotations;

namespace Email.Api.Models
{
    public class MailRequest
    {

        [Required(ErrorMessage = "Please enter valid email address")]
        [EmailAddress]
        public string RecipientEmailAddress { get; set; }

        [StringLength(100)]
        public string Body { get; set; }
    }
}
