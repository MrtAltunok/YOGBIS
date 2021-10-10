﻿using System.Collections.Generic;
using YOGBIS.Common.ResultModels;
using YOGBIS.Common.SessionOperations;
using YOGBIS.Common.VModels;
using YOGBIS.Data.DbModels;

namespace YOGBIS.BusinessEngine.Contracts
{
    public interface IOkulBilgiBE
    {
        Result<List<OkulBilgiVM>> OkulBilgileriGetir();
        Result<OkulBilgiVM> OkulBilgiEkle(OkulBilgiVM model, SessionContext user);

        Result<OkulBilgiVM> OkulBilgiGetir(int id);

        Result<OkulBilgiVM> OkulBilgiGuncelle(OkulBilgiVM model, SessionContext user);
        
        Result<bool> OkulBilgiSil(int id);

        Result<List<OkulBilgiVM>> OkulBilgiGetirKullaniciId(string userId);
    }
}
