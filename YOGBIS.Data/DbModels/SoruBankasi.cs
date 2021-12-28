﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YOGBIS.Data.DbModels
{
    public class SoruBankasi:Base
    {
        [Key]
        public int SoruBankasiId { get; set; }
        public string Soru { get; set; }
        public string Cevap { get; set; }
        public int SorulmaSayisi { get; set; }
        public bool SoruDurumu { get; set; }
        public int? OnayDurumu { get; set; }
        public string OnayAciklama { get; set; }
        public string KaydedenId { get; set; }
        [ForeignKey("KaydedenId")]
        public Kullanici Kaydeden { get; set; }
        public string OnaylayanId { get; set; }
        [ForeignKey("OnaylayanId")]
        public Kullanici Onaylayan { get; set; }
        public List<SoruKategori> SoruKategoris { get; set; }
        public List<SoruDerece> SoruDereces { get; set; }
    }
}
