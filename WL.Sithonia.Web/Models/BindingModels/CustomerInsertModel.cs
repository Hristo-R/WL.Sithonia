namespace WL.Sithonia.Web.Models.BindingModels
{
    using System.ComponentModel.DataAnnotations;

    public class CustomerInsertModel
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string Country { get; set; }
    }
}
