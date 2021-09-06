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
using log4net;

namespace QuanLyKhachHang.Controllers
{
    public class KhachHangController : Controller
    {
        //
        // GET: /KhachHang/
        //readonly ILog _log = LogManager.GetLogger(typeof(KhachHangController));
        public ActionResult Index()
        {
            IKhachHang _khachhang = IoC.Resolve<IKhachHang>();
            ICongTy _congty = IoC.Resolve<ICongTy>();
            IList<KhachHang> lst = _khachhang.GetAll();
            IList<KhachHangModel> lstModel = new List<KhachHangModel>();

            foreach (KhachHang it in lst)
            {
                KhachHangModel khModel = new KhachHangModel();
                khModel.id = it.id;
                khModel.Hoten = it.Hoten;
                khModel.Gioitinh = it.Gioitinh;
                khModel.Ngaysinh = it.Ngaysinh;
                khModel.Dienthoai = it.Dienthoai;
                khModel.Email = it.Email;
                khModel.Diachi = it.Diachi;
                khModel.Tencongty = _congty.Getbykey(it.Congtyid).TenCongTy;
                khModel.Socmt = it.Socmt;
                khModel.Ngaycap = it.Ngaycap;
                khModel.Noicap = it.Noicap;

                lstModel.Add(khModel);
            }

            return View(lstModel);
        }

        public List<Gender> getListGender() {
            var listGender = new List<Gender>
            {
                new Gender{ iValue="Nam",sText="Nam"},
                new Gender{iValue="Nữ",sText="Nữ"}
            };
            return listGender.ToList();
        }

        public ActionResult Create()
        {
            ICongTy _congty = IoC.Resolve<ICongTy>();
            IList<CongTy> lstcongty = _congty.GetAll();

            ViewBag.Congty = new SelectList(lstcongty, "id", "Tencongty");
            ViewBag.Gioitinh = new SelectList(getListGender(), "iValue", "sText");
            return View();
        }

        [HttpPost]
        public ActionResult Create(KhachHang _kh)
        {
            IKhachHang _khachhang = IoC.Resolve<IKhachHang>();
            if (_khachhang.CreateKhachHang(_kh))
            {
                _khachhang.CommitChanges();
            }
            return RedirectToAction("Index");
        }


        public ActionResult Edit(int id)
        {
            KhachHang model = new KhachHang();
            IKhachHang _khachhang = IoC.Resolve<IKhachHang>();
            ICongTy _CongTy = IoC.Resolve<ICongTy>();
            IList<CongTy> lstCongTy = _CongTy.GetAll();
            KhachHangModel khModel = new KhachHangModel();
            model = _khachhang.Getbykey(id);

            khModel.id = model.id;
            khModel.Hoten = model.Hoten;
            khModel.Gioitinh = model.Gioitinh;
            khModel.Ngaysinh = model.Ngaysinh;
            khModel.Dienthoai = model.Dienthoai;
            khModel.Email = model.Email;
            khModel.Diachi = model.Diachi;
            khModel.Tencongty = _CongTy.Getbykey(model.Congtyid).TenCongTy;
            khModel.Socmt = model.Socmt;
            khModel.Ngaycap = model.Ngaycap;
            khModel.Noicap = model.Noicap;

            ViewBag.Gioitinh = new SelectList(getListGender(), "iValue", "sText");
            ViewBag.CongTy = new SelectList(lstCongTy, "id", "TenCongTy", selectedValue: model.Congtyid);

            return View(khModel);
        }

        [HttpPost]
        public ActionResult Edit(KhachHang _kh)
        {
            IKhachHang _khachhang = IoC.Resolve<IKhachHang>();
            if (_khachhang.CreateKhachHang(_kh))
            {
                _khachhang.CommitChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            IKhachHang _khachhang = IoC.Resolve<IKhachHang>();
            _khachhang.Delete(id);
            _khachhang.CommitChanges();
            return RedirectToAction("Index");
        }
    }
}
