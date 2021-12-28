﻿using System.ComponentModel.DataAnnotations;

namespace YOGBIS.Common.VModels
{
    public class MulakatSorulariVM:BaseVM
    {
        [Key]
        public int MulakatSorulariId { get; set; }
                
        [Required(ErrorMessage = "Soru Sıra Numarası yazınız...")]
        public int SoruSiraNo { get; set; }
                
        [Required(ErrorMessage = "Soru Numarası yazınız...")]
        public int SoruId { get; set; }
                       
        [Required(ErrorMessage = "Kategori seçimi yazınız...")]
        public int SoruKategoriId { get; set; }
        public string SoruKategoriAdi { get; set; }
        
        [Required(ErrorMessage = "Soru Derecesini seçiniz...")]
        public int DereceId { get; set; }
        public string DereceAdi { get; set; }
       
        [Required(ErrorMessage = "Soruyu yazınız...")]
        public string Soru { get; set; }

        [Required(ErrorMessage = "Cevabı yazınız...")]
        public string Cevap { get; set; }
        public int MulakatId { get; set; }
        public string MulakatAdi { get; set; }
        public MulakatlarVM Mulakatlar { get; set; }
        public string KaydedenId { get; set; }
        public string KullaniciAdi { get; set; }
        public KullaniciVM Kullanici { get; set; }
    }
}
