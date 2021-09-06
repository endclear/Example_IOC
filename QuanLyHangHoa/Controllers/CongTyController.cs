using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Core.Entity;
using Core.IService;
using FX.Core;
using QuanLyHangHoa.Models;

namespace QuanLyHangHoa.Controllers
{
    public class CongTyController : Controller
    {
        //
        // GET: /Company/

        public ActionResult Index()
        {
            ICongTy _congTy = IoC.Resolve<ICongTy>();
            //IList<CongTy> lst = new List<CongTy>() { _congTy.Getbykey(1) };
            IList<CongTy> lst = _congTy.GetAll();
            IList<CongTyModel> lstModel = new List<CongTyModel>();
            foreach (CongTy it in lst)
            {
                CongTyModel cModel = new CongTyModel();
                cModel.id = it.id;
                cModel.TenCongTy = it.TenCongTy;
                cModel.DienThoai = it.DienThoai;
                cModel.Website = it.Website;
                cModel.Email = it.Email;
                cModel.MaSoThue = it.MaSoThue;
                cModel.DiaChi = it.DiaChi;
                cModel.OrderNumber = it.OrderNumber;

                lstModel.Add(cModel);
            }
            return View(lstModel);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CongTy c)
        {
            ICongTy _congty = IoC.Resolve<ICongTy>();
            if (_congty.CreateCongTy(c))
            {
                _congty.CommitChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            ICongTy _congty = IoC.Resolve<ICongTy>();
            return View(_congty.Getbykey(id));
        }

        [HttpPost]
        public ActionResult Edit(CongTy c)
        {
            ICongTy _congty = IoC.Resolve<ICongTy>();
            if (_congty.CreateCongTy(c))
            {
                _congty.CommitChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            ICongTy _congty = IoC.Resolve<ICongTy>();
            _congty.Delete(id);
            _congty.CommitChanges();
            return RedirectToAction("Index");
        }
    }
}
