﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using YOGBIS.Common.ConstantsModels;
using YOGBIS.Common.Extentsion;

namespace YOGBIS.Common.VModels
{
    public class KullaniciYekiYonetimVM
    {
        public string RoleId { get; set; }        
        public string RoleName { get; set; }
        public bool Selected { get; set; }
    }
}
