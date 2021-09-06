using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Core.Entity;
using Core.IService;
using FX.Core;
using FX.Data;
using QuanLyHangHoa.Models;

namespace QuanLyHangHoa.Controllers
{
    public class HangHoaController : Controller
    {
        //
        // GET: /HangHoa/

        public ActionResult Index()
        {
            IHangHoa _hanghoa = IoC.Resolve<IHangHoa>();
            IQuocGia _quocgia = IoC.Resolve<IQuocGia>();
            IList<HangHoa> lst = _hanghoa.GetAll();
            IList<HangHoaModel> lstModel = new List<HangHoaModel>();

            foreach (HangHoa it in lst)
            {
                HangHoaModel hhModel = new HangHoaModel();
                hhModel.id = it.id;
                hhModel.Mahang = it.Mahang;
                hhModel.Tenhang = it.Tenhang;
                hhModel.Tenquocgia = _quocgia.Getbykey(it.Xuatxuid).TenQuocGia;
                hhModel.Mota = it.Mota;
                hhModel.Ordernumber = it.Ordernumber;

                lstModel.Add(hhModel);
            }

            return View(lstModel);
        }

        public ActionResult Create()
        {
            IQuocGia _quocgia = IoC.Resolve<IQuocGia>();
            IList<QuocGia> lstQuocgia = _quocgia.GetAll();

            ViewBag.Quocgia = new SelectList(lstQuocgia, "id", "TenQuocGia");
            return View();
        }

        [HttpPost]
        public ActionResult Create(HangHoa _hh)
        {
            IHangHoa _hanghoa = IoC.Resolve<IHangHoa>();
            if (_hanghoa.CreateHangHoa(_hh))
            {
                _hanghoa.CommitChanges();
            }
            return RedirectToAction("Index");
            //return View();
        }


        public ActionResult Edit(int id)
        {
            HangHoa model = new HangHoa();
            IHangHoa _hanghoa = IoC.Resolve<IHangHoa>();
            IQuocGia _quocgia = IoC.Resolve<IQuocGia>();
            IList<QuocGia> lstquocgia = _quocgia.GetAll();
            HangHoaModel hhModel = new HangHoaModel();
            model = _hanghoa.Getbykey(id);

            hhModel.id = model.id;
            hhModel.Mahang = model.Mahang;
            hhModel.Tenhang = model.Tenhang;
            hhModel.Mota = model.Mota;
            hhModel.Tenquocgia = _quocgia.Getbykey(model.Xuatxuid).TenQuocGia;

            ViewBag.Quocgia = new SelectList(lstquocgia, "id", "TenQuocGia",selectedValue:model.Xuatxuid);

            return View(hhModel);
        }

        [HttpPost]
        public ActionResult Edit(HangHoa _hh)
        {
            IHangHoa _hanghoa = IoC.Resolve<IHangHoa>();
            if (_hanghoa.CreateHangHoa(_hh))
            {
                _hanghoa.CommitChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            IHangHoa _hanghoa = IoC.Resolve<IHangHoa>();
            _hanghoa.Delete(id);
            _hanghoa.CommitChanges();
            return RedirectToAction("Index");
        }
    }
}
