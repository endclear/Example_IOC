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
    [Authorize]
    public class PhieuXuatController : Controller
    {
        //
        // GET: /PhieuXuat/

        public ActionResult Index()
        {
            IPhieuXuat _phieuxuat = IoC.Resolve<IPhieuXuat>();
            IKhachHang _khachhang = IoC.Resolve<IKhachHang>();
            IList<PhieuXuat> lstPhieuxuat = _phieuxuat.GetAll();
            IList<PhieuXuatModel> lstModel = new List<PhieuXuatModel>();

            foreach (PhieuXuat it in lstPhieuxuat)
            {
                PhieuXuatModel phieuxuatModel = new PhieuXuatModel();
                phieuxuatModel.id = it.id;
                phieuxuatModel.Maphieuxuat = it.Maphieuxuat;
                phieuxuatModel.Mota = it.Mota;
                phieuxuatModel.Tenphieuxuat = it.Tenphieuxuat;
                phieuxuatModel.Tenkhachhang = _khachhang.Getbykey(it.Khachhangid).Hoten;
                lstModel.Add(phieuxuatModel);
            }
            return View(lstModel);
        }

        public ActionResult Create()
        {
            IKhachHang _khachhang = IoC.Resolve<IKhachHang>();
            IList<KhachHang> lstKhachhang = _khachhang.GetAll();
            ViewBag.Khachhang = new SelectList(lstKhachhang, "id", "HoTen");

            return View();
        }
        [HttpPost]
        public ActionResult Create(PhieuXuat _px)
        {
            Session["Phieuxuat"] = _px;
            return RedirectToAction("ThemChiTiet");
        }

        public IList<CT_PhieuXuatModel> LoadChiTietPhieuXuat(int phieuxuatid)
        {
            IHangHoa _hanghoa = IoC.Resolve<IHangHoa>();
            IPhieuXuat _phieuxuat = IoC.Resolve<IPhieuXuat>();
            ICT_PhieuXuat _ctphieuxuat = IoC.Resolve<ICT_PhieuXuat>();
            IList<CT_PhieuXuat> lstctphieuxuat = _ctphieuxuat.GetAll();
            IList<CT_PhieuXuatModel> lstModel = new List<CT_PhieuXuatModel>();
            foreach (CT_PhieuXuat it in lstctphieuxuat)
            {
                if (it.PhieuxuatId == phieuxuatid)
                {
                    CT_PhieuXuatModel ct_phieuxuatModel = new CT_PhieuXuatModel();
                    ct_phieuxuatModel.id = it.id;
                    //ct_phieuXuatModel.TenphieuXuat = _phieuXuat.Getbykey(it.PhieuXuatId).TenphieuXuat;
                    ct_phieuxuatModel.Tenmathang = _hanghoa.Getbykey(it.HanghoaId).Tenhang;
                    ct_phieuxuatModel.Ngayxuat = it.Ngayxuat;
                    ct_phieuxuatModel.Soluong = it.Soluong;
                    ct_phieuxuatModel.Giaban = it.Giaban;
                    ct_phieuxuatModel.Ghichu = it.Ghichu;
                    lstModel.Add(ct_phieuxuatModel);
                }

            }
            return lstModel;
        }

        public ActionResult ThemChiTiet()
        {
            TempData["ct_phieuxuatmodel"] = null;
            IHangHoa _hanghoa = IoC.Resolve<IHangHoa>();
            IList<HangHoa> lstHangHoa = _hanghoa.GetAll();
            TempData["hanghoa"] = new SelectList(lstHangHoa, "id", "TenHang");

            return View();
        }

        [HttpPost]
        public ActionResult Themchitiet(CT_PhieuXuat ct_phieuxuat)
        {
            IPhieuXuat _phieuxuat = IoC.Resolve<IPhieuXuat>();
            IList<PhieuXuat> lstphieuxuat = _phieuxuat.GetAll();
            PhieuXuat phieuxuat = Session["Phieuxuat"] as PhieuXuat;
            PhieuXuat phieuxuatCheck = lstphieuxuat.SingleOrDefault(n => n.id == ct_phieuxuat.PhieuxuatId);
            if (phieuxuatCheck == null)
            {
                if (_phieuxuat.CreatePhieuXuat(phieuxuat))
                {
                    _phieuxuat.CommitChanges();
                }
            }

            ICT_PhieuXuat _ctphieuxuat = IoC.Resolve<ICT_PhieuXuat>();
            IList<CT_PhieuXuat> lstCT_PhieuXuat = _ctphieuxuat.GetAll();
            CT_PhieuXuat ctphieuxuatCheck = lstCT_PhieuXuat.SingleOrDefault(
                n => n.HanghoaId == ct_phieuxuat.HanghoaId
                && n.PhieuxuatId == phieuxuat.id
                && n.Ngayxuat == ct_phieuxuat.Ngayxuat);
            if (ctphieuxuatCheck != null)
            {
                ctphieuxuatCheck.Soluong += ct_phieuxuat.Soluong;
                ctphieuxuatCheck.Giaban = ctphieuxuatCheck.Giaban;
                if (_ctphieuxuat.UpdateCT_PhieuXuat(ctphieuxuatCheck))
                {
                    _ctphieuxuat.CommitChanges();
                }
                TempData["ct_phieuxuatmodel"] = LoadChiTietPhieuXuat(ctphieuxuatCheck.PhieuxuatId);
            }
            else
            {
                ct_phieuxuat.PhieuxuatId = phieuxuat.id;
                if (_ctphieuxuat.CreateCT_PhieuXuat(ct_phieuxuat))
                {
                    _ctphieuxuat.CommitChanges();
                }
                TempData["ct_phieuxuatmodel"] = LoadChiTietPhieuXuat(ct_phieuxuat.PhieuxuatId);
            }


            return View();
        }

        //sua phieu xuat (method get)
        public ActionResult Edit(int id)
        {
            PhieuXuat model = new PhieuXuat();
            IPhieuXuat _phieuxuat = IoC.Resolve<IPhieuXuat>();
            IKhachHang _khachhang = IoC.Resolve<IKhachHang>();
            IList<KhachHang> lstkhachhang = _khachhang.GetAll();
            PhieuXuatModel pxModel = new PhieuXuatModel();
            model = _phieuxuat.Getbykey(id);

            pxModel.id = model.id;
            pxModel.Maphieuxuat = model.Maphieuxuat;
            pxModel.Tenphieuxuat = model.Tenphieuxuat;
            pxModel.Tenkhachhang = _khachhang.Getbykey(model.Khachhangid).Hoten;
            pxModel.Mota = model.Mota;

            TempData["Khachhang"] = new SelectList(lstkhachhang, "id", "Hoten", selectedValue: model.Khachhangid);
            return View(pxModel);
        }
        [HttpPost]
        public ActionResult Edit(PhieuXuat phieuxuat)
        {
            IPhieuXuat _phieuxuat = IoC.Resolve<IPhieuXuat>();
            if (_phieuxuat.CreatePhieuXuat(phieuxuat))
            {
                _phieuxuat.CommitChanges();
            }
            return RedirectToAction("Index");
        }

        //xem chi tiet phieu Xuat
        public ActionResult ChiTiet(int id)
        {
            IPhieuXuat _phieuxuat = IoC.Resolve<IPhieuXuat>();
            ViewBag.Tenphieuxuat = _phieuxuat.Getbykey(id).Tenphieuxuat;
            ViewBag.phieuXuatid = id;
            IList<CT_PhieuXuatModel> model = new List<CT_PhieuXuatModel>();
            model = LoadChiTietPhieuXuat(id);
            return View(model);
        }

        //xoa chi tiet phieu Xuat
        public ActionResult DeleteChiTiet(int id)
        {
            ICT_PhieuXuat _chitietphieuxuat = IoC.Resolve<ICT_PhieuXuat>();
            int phieuxuatid = _chitietphieuxuat.Getbykey(id).PhieuxuatId;
            _chitietphieuxuat.Delete(id);
            _chitietphieuxuat.CommitChanges();
            TempData["ct_phieuxuatmodel"] = LoadChiTietPhieuXuat(phieuxuatid);

            return Redirect(TempData["url"].ToString());
        }
        //xoa phieu Xuat
        public ActionResult Delete(int id)
        {
            IPhieuXuat _phieuxuat = IoC.Resolve<IPhieuXuat>();
            ICT_PhieuXuat _ictphieuxuat = IoC.Resolve<ICT_PhieuXuat>();
            IList<CT_PhieuXuat> lstctphieuxuat = _ictphieuxuat.GetAll();
            if (lstctphieuxuat != null)
            {
                foreach (var it in lstctphieuxuat)
                {
                    if (it.PhieuxuatId == id)
                    {
                        _ictphieuxuat.Delete(it);
                        _ictphieuxuat.CommitChanges();
                    }
                }
            }
            _phieuxuat.Delete(id);
            _phieuxuat.CommitChanges();
            return RedirectToAction("Index");
        }
    }
}
