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
    [Authorize]
    public class PhieuNhapController : Controller
    {
        //
        // GET: /PhieuNhap/

        public ActionResult Index()
        {
            IPhieuNhap _phieunhap = IoC.Resolve<IPhieuNhap>();
            ICongTy _congty = IoC.Resolve<ICongTy>();
            IList<PhieuNhap> lstPhieunhap = _phieunhap.GetAll();
            IList<PhieuNhapModel> lstModel = new List<PhieuNhapModel>();

            foreach (PhieuNhap it in lstPhieunhap) {
                PhieuNhapModel phieunhapModel = new PhieuNhapModel();
                phieunhapModel.id = it.id;
                phieunhapModel.Maphieunhap = it.Maphieunhap;
                phieunhapModel.Mota = it.Mota;
                phieunhapModel.Tenphieunhap = it.Tenphieunhap;
                phieunhapModel.Tencongty = _congty.Getbykey(it.Congtyid).TenCongTy;
                lstModel.Add(phieunhapModel);
            }
            return View(lstModel);
        }

        public ActionResult Create() {
            ICongTy _congty = IoC.Resolve<ICongTy>();
            IList<CongTy> lstCongty = _congty.GetAll();
            ViewBag.Congty = new SelectList(lstCongty, "id", "TenCongTy");

            return View();
        }
        [HttpPost]
        public ActionResult Create(PhieuNhap _pn) {
            Session["Phieunhap"] = _pn;
            return RedirectToAction("ThemChiTiet");
        }

        public ActionResult ThemChiTiet() {
            TempData["ct_phieunhapmodel"] = null;
            IHangHoa _hanghoa = IoC.Resolve<IHangHoa>();
            IList<HangHoa> lstHangHoa = _hanghoa.GetAll();
            TempData["hanghoa"] = new SelectList(lstHangHoa, "id", "TenHang");

            return View();
        }

        [HttpPost]
        public ActionResult Themchitiet(CT_PhieuNhap ct_phieunhap) {
            IPhieuNhap _phieunhap = IoC.Resolve<IPhieuNhap>();
            IList<PhieuNhap> lstphieunhap = _phieunhap.GetAll();
            PhieuNhap phieunhap = Session["Phieunhap"] as PhieuNhap;
            PhieuNhap phieunhapCheck = lstphieunhap.SingleOrDefault(n => n.id == ct_phieunhap.PhieunhapId);
            if (phieunhapCheck == null) {
                if (_phieunhap.CreatePhieunhap(phieunhap))
                {
                    _phieunhap.CommitChanges();
                }
            }

            ICT_PhieuNhap _ctphieunhap = IoC.Resolve<ICT_PhieuNhap>();
            IList<CT_PhieuNhap> lstCT_PhieuNhap = _ctphieunhap.GetAll();
            CT_PhieuNhap ctphieunhapCheck = lstCT_PhieuNhap.SingleOrDefault(
                n => n.HanghoaId == ct_phieunhap.HanghoaId 
                && n.PhieunhapId == phieunhap.id
                &&n.Ngaynhap==ct_phieunhap.Ngaynhap);
            if (ctphieunhapCheck != null)
            {
                ctphieunhapCheck.Soluong += ct_phieunhap.Soluong;
                ctphieunhapCheck.Gianhap = ctphieunhapCheck.Gianhap;
                if (_ctphieunhap.UpdateCT_PhieuNhap(ctphieunhapCheck))
                {
                    _ctphieunhap.CommitChanges();
                }
                TempData["ct_phieunhapmodel"] = LoadChiTietPhieuNhap(ctphieunhapCheck.PhieunhapId);
            }
            else
            {
                ct_phieunhap.PhieunhapId = phieunhap.id;
                if (_ctphieunhap.CreateCT_PhieuNhap(ct_phieunhap))
                {
                    _ctphieunhap.CommitChanges();
                }
                TempData["ct_phieunhapmodel"] = LoadChiTietPhieuNhap(ct_phieunhap.PhieunhapId);
            }
            

            return View();
        }


     
        ////lấy chi tiết phiếu nhập
        //public IList<CT_PhieuNhap> LayChiTietPhieuNhap() {
        //    IList<CT_PhieuNhap> lstctPhieunhap = Session["ct_phieunhap"] as IList<CT_PhieuNhap>;
        //    //ktra gio hàng tồn tại hay ko
        //    if (lstctPhieunhap == null) {
        //        lstctPhieunhap = new List<CT_PhieuNhap>();
        //        Session["ct_phieunhap"] = lstctPhieunhap;
        //        return lstctPhieunhap;
        //    }
        //    return lstctPhieunhap;
        //}


        //load chi tiet phieu nhap theo ma phieu nhap
        public IList<CT_PhieuNhapModel> LoadChiTietPhieuNhap(int phieunhapid) {
            IHangHoa _hanghoa = IoC.Resolve<IHangHoa>();
            IPhieuNhap _phieunhap = IoC.Resolve<IPhieuNhap>();
            ICT_PhieuNhap _ctphieunhap = IoC.Resolve<ICT_PhieuNhap>();
            IList<CT_PhieuNhap> lstctphieunhap = _ctphieunhap.GetAll();
            IList<CT_PhieuNhapModel> lstModel = new List<CT_PhieuNhapModel>();
            foreach (CT_PhieuNhap it in lstctphieunhap)
            {
                if (it.PhieunhapId == phieunhapid)
                {
                    CT_PhieuNhapModel ct_phieunhapModel = new CT_PhieuNhapModel();
                    ct_phieunhapModel.id = it.id;
                    //ct_phieunhapModel.Tenphieunhap = _phieunhap.Getbykey(it.PhieunhapId).Tenphieunhap;
                    ct_phieunhapModel.TenMatHang = _hanghoa.Getbykey(it.HanghoaId).Tenhang;
                    ct_phieunhapModel.Ngaynhap = it.Ngaynhap;
                    ct_phieunhapModel.Soluong = it.Soluong;
                    ct_phieunhapModel.Gianhap = it.Gianhap;
                    ct_phieunhapModel.Ghichu = it.Ghichu;
                    lstModel.Add(ct_phieunhapModel);
                }
                
            }
            return lstModel;
        }
        //sua phieu nhap (method get)
        public ActionResult Edit(int id) {
            PhieuNhap model = new PhieuNhap();
            IPhieuNhap _phieunhap = IoC.Resolve<IPhieuNhap>();
            ICongTy _CongTy = IoC.Resolve<ICongTy>();
            IList<CongTy> lstCongTy = _CongTy.GetAll();
            PhieuNhapModel pnModel = new PhieuNhapModel();
            model = _phieunhap.Getbykey(id);

            pnModel.id = model.id;
            pnModel.Maphieunhap = model.Maphieunhap;
            pnModel.Tenphieunhap = model.Tenphieunhap;
            pnModel.Mota = model.Mota;
            pnModel.Tencongty = _CongTy.Getbykey(model.Congtyid).TenCongTy;
            pnModel.Mota = model.Mota;

            TempData["Congty"] = new SelectList(lstCongTy, "id", "TenCongTy", selectedValue: model.Congtyid);
            return View(pnModel);
        }
        [HttpPost]
        public ActionResult Edit(PhieuNhap phieunhap) {
            IPhieuNhap _phieunhap = IoC.Resolve<IPhieuNhap>();
            if (_phieunhap.CreatePhieunhap(phieunhap)) {
                _phieunhap.CommitChanges();
            }
            return RedirectToAction("Index");
        }

        //xem chi tiet phieu nhap
        public ActionResult ChiTiet(int id) {
            IPhieuNhap _phieunhap = IoC.Resolve<IPhieuNhap>();
            ViewBag.Tenphieunhap = _phieunhap.Getbykey(id).Tenphieunhap;
            ViewBag.phieunhapid = id; 
            IList<CT_PhieuNhapModel> model = new List<CT_PhieuNhapModel>();
            model = LoadChiTietPhieuNhap(id);
            return View(model);
        }

        //xoa chi tiet phieu nhap
        public ActionResult DeleteChiTiet(int id) {
            ICT_PhieuNhap _chitietphieunhap = IoC.Resolve<ICT_PhieuNhap>();
            int phieunhapid = _chitietphieunhap.Getbykey(id).PhieunhapId;
            _chitietphieunhap.Delete(id);
            _chitietphieunhap.CommitChanges();
            TempData["ct_phieunhapmodel"] = LoadChiTietPhieuNhap(phieunhapid);
            
            return Redirect(TempData["url"].ToString());
        }
        //xoa phieu nhap
        public ActionResult Delete(int id) {
            IPhieuNhap _phieunhap = IoC.Resolve<IPhieuNhap>();
            ICT_PhieuNhap _ictphieunhap = IoC.Resolve<ICT_PhieuNhap>();
            IList<CT_PhieuNhap> lstctphieunhap = _ictphieunhap.GetAll();
            if (lstctphieunhap != null) {
                foreach (var it in lstctphieunhap)
                {
                    if (it.PhieunhapId == id) {
                        _ictphieunhap.Delete(it);
                        _ictphieunhap.CommitChanges();
                    }
                }
            }
            _phieunhap.Delete(id);
            _phieunhap.CommitChanges();
            return RedirectToAction("Index");
        }

        
    }
}
