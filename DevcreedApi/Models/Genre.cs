using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevcreedApi.Models
{
    public class Genre
    {
        //el identity hena msh sha8ala auto 3lshan el type "byte"
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte Id { get; set; }
        
        [MaxLength(100)]
        public string Name { get; set; }

        // ana hena momkn a7ot List of Movies w momkn La2 3ady zai ma elhelaly katb f comment f video rakm 13
    }
}
