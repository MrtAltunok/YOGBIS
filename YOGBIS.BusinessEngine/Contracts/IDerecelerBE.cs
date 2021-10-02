﻿using System.Collections.Generic;
using YOGBIS.Common.ResultModels;
using YOGBIS.Common.SessionOperations;
using YOGBIS.Common.VModels;
using YOGBIS.Data.DbModels;

namespace YOGBIS.BusinessEngine.Contracts
{
    public interface IDerecelerBE
    {
        Result<List<DerecelerVM>> DereceGetir();
        Result<DerecelerVM> DereceEkle(DerecelerVM model);//, SessionContext user

        Result<DerecelerVM> DereceGetir(int id);

        Result<DerecelerVM> DereceGuncelle(DerecelerVM model);
        
        Result<bool> DereceSil(int id);

        Result<List<DerecelerVM>> DereceGetirKullaniciId(string userId);
    }
}
