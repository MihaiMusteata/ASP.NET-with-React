using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Domain.Entities.Enums;

namespace Project.Domain.Entities.User
{
     public class UDbTable
     {
          [Key]
          [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
          public int Id { get; set; }

          [Required]
          [Display(Name = "Username")]
          [StringLength(30, MinimumLength = 5, ErrorMessage = "Username must be between 5 and 30 characters")]
          public string Username { get; set; }

          [Required]
          [Display(Name = "Password")]
          [StringLength(50, MinimumLength = 8, ErrorMessage = "Password must be between 8 and 50 characters")]
          public string Password { get; set; }

          [Required]
          [Display(Name = "Email Address")]
          [StringLength(30)]
          public string Email { get; set; }

          [Required]
          [Display(Name = "Gender")]
          public string Gender { get; set; }

          [Required]
          [Display(Name = "District")]
          public string District { get; set; }

          [Required]
          [Display(Name = "Region")]
          public string Region { get; set; }

          [DataType(DataType.Date)]
          public DateTime LastLogin { get; set; }

          [StringLength(30)]
          public string LastIp { get; set; }

          public URole Level { get; set; }

     }
}
