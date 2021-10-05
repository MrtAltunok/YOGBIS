﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace YOGBIS.Common.VModels
{
    public class UlkelerVM:BaseVM
    {
        [Key]
        public int UlkeId { get; set; }
        [Required (ErrorMessage ="Ülke adı zorunlu bir alandır")]
        public string UlkeAdi { get; set; }
        public byte[] UlkeBayrak { get; set; }
        public string UlkeAciklama { get; set; }

        [Required(ErrorMessage = "Kıta adı zorunlu bir alandır")]
        public int KitaId { get; set; }

        [Required(ErrorMessage = "Kıta adı zorunlu bir alandır")]
        public string KitaAdi { get; set; }
        public KitalarVM KitalarVm { get; set; }
        public string KullaniciId { get; set; }
        public string KullaniciAdi { get; set; }
        public KullaniciVM KullaniciVm { get; set; }
    }
}
