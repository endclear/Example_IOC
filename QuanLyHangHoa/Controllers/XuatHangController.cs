using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Core.Entity;
using Core.IService;
using FX.Core;
using QuanLyHangHoa.Models;

namespace QuanLyHangHoa.Controllers
{
    public class XuatHangController : Controller
    {
        //
        // GET: /XuatHang/

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
            IList<KhachHang> lstKhachhang = _khachhang.GetAll();
            TempData["Khachhang"] = new SelectList(lstKhachhang, "id", "Hoten");
            return View(lstModel);
        }

        public JsonResult ViewPhieuXuat(int id)
        {
            PhieuXuat model = new PhieuXuat();
            IPhieuXuat _phieuxuat = IoC.Resolve<IPhieuXuat>();
            IKhachHang _khachhang = IoC.Resolve<IKhachHang>();
            PhieuXuatModel pnModel = new PhieuXuatModel();
            model = _phieuxuat.Getbykey(id);

            pnModel.id = model.id;
            pnModel.Tenphieuxuat = model.Tenphieuxuat;
            pnModel.Mota = model.Mota;
            pnModel.Tenkhachhang = _khachhang.Getbykey(model.Khachhangid).Hoten;
            return Json(new { id = pnModel.id, tenphieu = pnModel.Tenphieuxuat, Tenkhachhang = pnModel.Tenkhachhang });
        }

        //load chi tiet phieu Xuat theo ma phieu Xuat tra ve json
        public String LoadChiTietPhieuXuat(int id)
        {
            IHangHoa _hanghoa = IoC.Resolve<IHangHoa>();
            IPhieuXuat _phieuxuat = IoC.Resolve<IPhieuXuat>();
            ICT_PhieuXuat _ctphieuxuat = IoC.Resolve<ICT_PhieuXuat>();
            IList<CT_PhieuXuat> lstctphieuxuat = _ctphieuxuat.GetAll();
            IList<CT_PhieuXuatModel> lstModel = new List<CT_PhieuXuatModel>();
            foreach (CT_PhieuXuat it in lstctphieuxuat)
            {
                if (it.PhieuxuatId == id)
                {
                    CT_PhieuXuatModel ct_phieuxuatModel = new CT_PhieuXuatModel();
                    ct_phieuxuatModel.id = it.id;
                    //ct_phieuxuatModel.Tenphieuxuat = _phieuxuat.Getbykey(it.PhieuxuatId).Tenphieuxuat;
                    ct_phieuxuatModel.Tenmathang = _hanghoa.Getbykey(it.HanghoaId).Tenhang;
                    ct_phieuxuatModel.Ngayxuat = it.Ngayxuat;
                    ct_phieuxuatModel.Soluong = it.Soluong;
                    ct_phieuxuatModel.Giaban = it.Giaban;
                    ct_phieuxuatModel.Ghichu = it.Ghichu;
                    lstModel.Add(ct_phieuxuatModel);
                }

            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            string json = js.Serialize(lstModel);
            return json;
        }

        public ActionResult Create()
        {
            IHangHoa _hanghoa = IoC.Resolve<IHangHoa>();
            IList<HangHoa> lstHanghoa = _hanghoa.GetAll();
            IKhachHang _khachhang = IoC.Resolve<IKhachHang>();
            IList<KhachHang> lstKhachhang = _khachhang.GetAll();
            TempData["Khachhang"] = new SelectList(lstKhachhang, "id", "Hoten");
            TempData["Hanghoa"] = new SelectList(lstHanghoa, "id", "tenhang");

            return View();
        }

        [HttpPost]
        public ActionResult Create(PhieuXuat _phieuxuat, string PubDatasource, string Ngayxuat)
        {
            IPhieuXuat _pn = IoC.Resolve<IPhieuXuat>();
            if (_pn.CreatePhieuXuat(_phieuxuat))
            {
                _pn.CommitChanges();
            }

            DateTime _ngayxuat = DateTime.ParseExact(Ngayxuat, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            JavaScriptSerializer jss = new JavaScriptSerializer();
            IList<CT_PhieuXuat> lstCT_PhieuXuat = jss.Deserialize<IList<CT_PhieuXuat>>(PubDatasource);
            ICT_PhieuXuat _ctphieuxuat = IoC.Resolve<ICT_PhieuXuat>();


            foreach (CT_PhieuXuat it in lstCT_PhieuXuat)
            {
                it.PhieuxuatId = _phieuxuat.id;
                it.Ngayxuat = _ngayxuat;
                if (_ctphieuxuat.CreateCT_PhieuXuat(it))
                {
                    _ctphieuxuat.CommitChanges();
                }
            }



            return RedirectToAction("Index");
        }

        public IList<CT_PhieuXuatModel> LoadChiTietPhieuXuat2(int id)
        {
            IHangHoa _hanghoa = IoC.Resolve<IHangHoa>();
            IPhieuXuat _phieuxuat = IoC.Resolve<IPhieuXuat>();
            ICT_PhieuXuat _ctphieuxuat = IoC.Resolve<ICT_PhieuXuat>();
            IList<CT_PhieuXuat> lstctphieuxuat = _ctphieuxuat.GetAll();
            IList<CT_PhieuXuatModel> lstModel = new List<CT_PhieuXuatModel>();
            foreach (CT_PhieuXuat it in lstctphieuxuat)
            {
                if (it.PhieuxuatId == id)
                {
                    CT_PhieuXuatModel ct_phieuxuatModel = new CT_PhieuXuatModel();
                    ct_phieuxuatModel.id = it.id;
                    //ct_phieuxuatModel.Tenphieuxuat = _phieuxuat.Getbykey(it.PhieuxuatId).Tenphieuxuat;
                    ct_phieuxuatModel.Tenmathang = it.HanghoaId.ToString();
                    ct_phieuxuatModel.Ngayxuat = it.Ngayxuat;
                    ct_phieuxuatModel.Soluong = it.Soluong;
                    ct_phieuxuatModel.Giaban = it.Giaban;
                    ct_phieuxuatModel.Ghichu = it.Ghichu;
                    lstModel.Add(ct_phieuxuatModel);
                }

            }
            return lstModel;
        }
        //Edit
        public ActionResult Edit(int id)
        {
            PhieuXuat model = new PhieuXuat();
            IPhieuXuat _phieuxuat = IoC.Resolve<IPhieuXuat>();
            IKhachHang _khachhang = IoC.Resolve<IKhachHang>();
            IList<KhachHang> lstKhachhang = _khachhang.GetAll();
            PhieuXuatModel pnModel = new PhieuXuatModel();
            IHangHoa _hanghoa = IoC.Resolve<IHangHoa>();
            IList<HangHoa> lstHanghoa = _hanghoa.GetAll();

            model = _phieuxuat.Getbykey(id);

            pnModel.id = model.id;
            pnModel.Tenphieuxuat = model.Tenphieuxuat;
            pnModel.Mota = model.Mota;
            pnModel.Tenkhachhang = _khachhang.Getbykey(model.Khachhangid).Hoten;
            pnModel.Mota = model.Mota;

            TempData["CT_phieuxuat"] = LoadChiTietPhieuXuat2(id);
            ViewBag.listhanghoa = lstHanghoa;
            TempData["Khachhang"] = new SelectList(lstKhachhang, "id", "Hoten", selectedValue: model.Khachhangid);
            return View(pnModel);
        }
        [HttpPost]
        public ActionResult Edit(PhieuXuat _phieuxuat, string PubDatasource)
        {
            IPhieuXuat _pn = IoC.Resolve<IPhieuXuat>();
            if (_pn.CreatePhieuXuat(_phieuxuat))
            {
                _pn.CommitChanges();
            }

            //DateTime _ngayxuat = DateTime.ParseExact(Ngayxuat, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            JavaScriptSerializer jss = new JavaScriptSerializer();
            IList<CT_PhieuXuat> lstCT_PhieuXuat = jss.Deserialize<IList<CT_PhieuXuat>>(PubDatasource);
            ICT_PhieuXuat _ctphieuxuat = IoC.Resolve<ICT_PhieuXuat>();


            foreach (CT_PhieuXuat it in lstCT_PhieuXuat)
            {
                //it.Ngayxuat = _ngayxuat;
                if (_ctphieuxuat.UpdateCT_PhieuXuat(it))
                {
                    _ctphieuxuat.CommitChanges();
                }
            }
            return RedirectToAction("Index");
        }
        //xoa phieu xuat
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
