using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace BulkyWebRazor_Temp.Models
{
	public class CategoryModel
	{
		[Key]
		public int Id { get; set; }

		[MaxLength(30)]
		[Required]
		public string? Name { get; set; }

		[DisplayName("Display Order")]
		[Range(1, 100, ErrorMessage = "Display Order must be between 1-100")]
		public int DisplayOrder { get; set; }
	}
}
