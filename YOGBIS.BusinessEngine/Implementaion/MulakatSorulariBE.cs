﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using YOGBIS.BusinessEngine.Contracts;
using YOGBIS.Common.ConstantsModels;
using YOGBIS.Common.ResultModels;
using YOGBIS.Common.SessionOperations;
using YOGBIS.Common.VModels;
using YOGBIS.Data.Contracts;
using YOGBIS.Data.DbModels;

namespace YOGBIS.BusinessEngine.Implementaion
{
    public class MulakatSorulariBE : IMulakatSorulariBE
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public MulakatSorulariBE(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Result<List<MulakatSorulariVM>> MulakatSorulariGetir()
        {
            //1. Yöntem
            //var data = _unitOfWork.mulakatSorulariRepository.GetAll().ToList();            
            //var mulakatSorulari = _mapper.Map<List<MulakatSorulari>, List<MulakatSorulariVM>>(data);
            //return new Result<List<MulakatSorulariVM>>(true, ResultConstant.RecordFound, mulakatSorulari);

            #region 2.Yöntem
            var data = _unitOfWork.mulakatSorulariRepository.GetAll(includeProperties: "SoruBankasi,SoruKategoriler,Dereceler,Mulakatlar,Kullanici").ToList();
            var soruBankasi = _mapper.Map<List<MulakatSorulari>, List<MulakatSorulariVM>>(data);

            if (data != null)
            {
                List<MulakatSorulariVM> returnData = new List<MulakatSorulariVM>();

                foreach (var item in data)
                {
                    returnData.Add(new MulakatSorulariVM()
                    {
                        MulakatSorulariId=item.MulakatSorulariId,
                        SoruSiraNo=item.SoruSiraNo,
                        //SoruId=item.SoruBankasi.SoruBankasiId,
                        //SoruKategoriId=item.SoruKategoriler.SoruKategorilerId,
                        //SoruKategoriAdi=item.SoruKategoriler.SoruKategorilerAdi,
                        //DereceId=item.Dereceler.DereceId,
                        //DereceAdi=item.Dereceler.DereceAdi,
                        Soru=item.Soru,
                        Cevap=item.Cevap,
                        MulakatId=item.Mulakatlar.MulakatId,
                        MulakatAdi=item.Mulakatlar.MulakatAdi,
                        KullaniciId=item.Kullanici.Id,
                        KullaniciAdi=item.Kullanici.Ad+" "+item.Kullanici.Soyad
                    });
                }
                return new Result<List<MulakatSorulariVM>>(true, ResultConstant.RecordFound, returnData);
            }
            else
            {
                return new Result<List<MulakatSorulariVM>>(false, ResultConstant.RecordNotFound);
            }
            #endregion
        }

        public Result<MulakatSorulariVM> MulakatSorulariGetir(int id)
        {
            var data = _unitOfWork.mulakatSorulariRepository.Get(id);
            if (data!=null)
            {
                var mulakatSoru = _mapper.Map<MulakatSorulari, MulakatSorulariVM>(data);
                return new Result<MulakatSorulariVM>(true, ResultConstant.RecordFound, mulakatSoru);
            }
            else
            {
                return new Result<MulakatSorulariVM>(false, ResultConstant.RecordNotFound);
            }
        }

        public Result<MulakatSorulariVM> MulakatSorusuEkle(MulakatSorulariVM model, SessionContext user)
        {
            if (model!=null)
            {
                try
                {
                    var mulakatSoru = _mapper.Map<MulakatSorulariVM, MulakatSorulari>(model);
                    mulakatSoru.KaydedenId = user.LoginId;
                    _unitOfWork.mulakatSorulariRepository.Add(mulakatSoru);
                    _unitOfWork.Save();
                    return new Result<MulakatSorulariVM>(true, ResultConstant.RecordCreateSuccess);
                }
                catch (Exception ex)
                {

                    return new Result<MulakatSorulariVM>(false, ResultConstant.RecordCreateNotSuccess +" "+ ex.Message.ToString());
                }
            }
            else
            {
                return new Result<MulakatSorulariVM>(false, "Boş veri olamaz");
            }
        }

        public Result<MulakatSorulariVM> MulakatSorusuGuncelle(MulakatSorulariVM model, SessionContext user)
        {
            if (model != null)
            {
                try
                {
                    var mulakatSoru = _mapper.Map<MulakatSorulariVM, MulakatSorulari>(model);
                    mulakatSoru.KaydedenId = user.LoginId;
                    _unitOfWork.mulakatSorulariRepository.Update(mulakatSoru);
                    _unitOfWork.Save();
                    return new Result<MulakatSorulariVM>(true, ResultConstant.RecordCreateSuccess);
                }
                catch (Exception ex)
                {

                    return new Result<MulakatSorulariVM>(false, ResultConstant.RecordCreateNotSuccess + " " + ex.Message.ToString());
                }
            }
            else
            {
                return new Result<MulakatSorulariVM>(false, "Boş veri olamaz");
            }
        }

        public Result<bool> MulakatSorusuSil(int id)
        {
            var data = _unitOfWork.mulakatSorulariRepository.Get(id);
            if (data!=null)
            {
                _unitOfWork.mulakatSorulariRepository.Remove(data);
                _unitOfWork.Save();
                return new Result<bool>(true, ResultConstant.RecordRemoveSuccessfully);
            }
            else
            {
                return new Result<bool>(false, ResultConstant.RecordRemoveNotSuccessfully);
            }
        }
       
        public Result<List<MulakatSorulariVM>> MulakatSorulariGetir(int id, string derece)
        {
            var data = _unitOfWork.mulakatSorulariRepository.GetAll(k => k.SoruSiraNo == id).ToList(); //&& k.Dereceler.DereceAdi == derece (parantez içi eklenecek)
            if (data != null)
            {
                List<MulakatSorulariVM> returnData = new List<MulakatSorulariVM>();
                foreach (var item in data)
                {
                    returnData.Add(new MulakatSorulariVM()
                    {
                        MulakatSorulariId = item.MulakatSorulariId,
                        SoruSiraNo = item.SoruSiraNo,
                        SoruId = item.SoruId,
                        SoruKategoriId = item.SoruKategoriId,
                        SoruKategoriAdi = item.SoruKategoriAdi,
                        //DereceAdi=item.Dereceler.DereceAdi,
                        Soru = item.Soru,
                        Cevap = item.Cevap
                    });
                }
                return new Result<List<MulakatSorulariVM>>(true, ResultConstant.RecordFound, returnData);
            }
            else
            {
                return new Result<List<MulakatSorulariVM>>(false, ResultConstant.RecordNotFound);
            }
        }
    }
}
