using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace vardar.Models
{//entity framework kullanıyoruz
    public class Category
    {//database tabanlı bir koruma var
        //hangisinin pk olduğunu data anotion diye bir şey ile belirtiyoruz
        [Key]//kütüphane olarak DataAnnotaitons olarak eklenen şey yardımıyla bunun pk olduğunu belirtiyoruz eğer id olaraksa szaten otomatik olarak pk ayarlanır
        public int Id { get; set; } //pk olarak işaretleyeceğiz burada yaptıklarımız sql kısmında tablonun kolonlarıdır
        [Required]//not null olarak işaretlenir doldurulması gerekir name kısmının
        [MaxLength(30)]
        [DisplayName("Kategori İsmi")]
        public string Name { get; set; }
        [DisplayName("Gösterim Sırası")]
        [Range(1,100,ErrorMessage="Gösterim Sırası 1-100 arasında olmalıdır.")]
        public int DisplayOrder { get; set; }//hangi kategorinin önce gösterilmesini istediğimizi burdan ayarlarız

    }
}
