﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YOGBIS.BusinessEngine.Contracts;
using YOGBIS.Common.ConstantsModels;
using YOGBIS.Common.SessionOperations;
using YOGBIS.Common.VModels;

namespace YOGBIS.UI.Controllers
{
    [Authorize] //(Roles = ResultConstant.Admin_Role)]
    public class MulakatController : Controller
    {

        private readonly IMulakatBE _mulakatBE;
        public MulakatController(IMulakatBE mulakatBE)
        {
            _mulakatBE = mulakatBE;
        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Index(int id, string derece)
        {
            var user = JsonConvert.DeserializeObject<SessionContext>(HttpContext.Session.GetString(ResultConstant.LoginUserInfo));
            var sorugetirmodel = _mulakatBE.GetAllMulakatSorulariById(id, derece);
            if (sorugetirmodel.IsSuccess)
            {
                return View(sorugetirmodel);
            }
            return View();
        }

    }
}
