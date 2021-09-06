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
    public class QuocGiaController : Controller
    {
        //
        // GET: /QuocGia/

        public ActionResult Index()
        {
            IQuocGia _quocgia = IoC.Resolve<IQuocGia>();
            IList<QuocGia> lst = _quocgia.GetAll();
            IList<QuocGiaModel> lstModel = new List<QuocGiaModel>();
            foreach (QuocGia it in lst)
            {
                QuocGiaModel qgModel = new QuocGiaModel();
                qgModel.id = it.id;
                qgModel.MaQuocGia = it.MaQuocGia;
                qgModel.TenQuocGia = it.TenQuocGia;

                lstModel.Add(qgModel);
            }
            return View(lstModel);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(QuocGia qg)
        {
            IQuocGia _quocgia = IoC.Resolve<IQuocGia>();
            if (_quocgia.CreateQuocGia(qg))
            {
                _quocgia.CommitChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            IQuocGia _quocgia = IoC.Resolve<IQuocGia>();
            return View(_quocgia.Getbykey(id));
        }

        [HttpPost]
        public ActionResult Edit(QuocGia qg)
        {
            IQuocGia _quocgia = IoC.Resolve<IQuocGia>();
            if (_quocgia.CreateQuocGia(qg))
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            IQuocGia _quocgia = IoC.Resolve<IQuocGia>();
            _quocgia.Delete(id);
            _quocgia.CommitChanges();
            return RedirectToAction("Index");
        }

    }
}
