using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YOGBIS.Common.VModels
{
    public class SubelerVM:BaseVM
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid SubeId { get; set; }
        public string OkulAdi { get; set; }
        public DateTime SubeAcilisTarihi { get; set; }
        public Guid OkulId { get; set; }
        public OkullarVM Okullar { get; set; }
        public string KaydedenId { get; set; }
        public KullaniciVM Kullanici { get; set; }
        public List<SiniflarVM> Siniflars { get; set; }
    }
}
