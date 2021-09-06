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
    public class NhapHangController : Controller
    {
        //
        // GET: /NhapHang/

        public ActionResult Index()
        {
            IPhieuNhap _phieunhap = IoC.Resolve<IPhieuNhap>();
            ICongTy _congty = IoC.Resolve<ICongTy>();
            IList<PhieuNhap> lstPhieunhap = _phieunhap.GetAll();
            IList<PhieuNhapModel> lstModel = new List<PhieuNhapModel>();

            foreach (PhieuNhap it in lstPhieunhap)
            {
                PhieuNhapModel phieunhapModel = new PhieuNhapModel();
                phieunhapModel.id = it.id;
                phieunhapModel.Maphieunhap = it.Maphieunhap;
                phieunhapModel.Mota = it.Mota;
                phieunhapModel.Tenphieunhap = it.Tenphieunhap;
                phieunhapModel.Tencongty = _congty.Getbykey(it.Congtyid).TenCongTy;
                lstModel.Add(phieunhapModel);
            }
            IList<CongTy> lstCongty = _congty.GetAll();
            TempData["Congty"] = new SelectList(lstCongty, "id", "TenCongTy");
            return View(lstModel);
        }
        //khong dung nua
        public ActionResult Search(string Tenphieunhap,int Congtyid) {
            ICongTy _congty = IoC.Resolve<ICongTy>();
            IPhieuNhap _phieunhap = IoC.Resolve<IPhieuNhap>();
            IList<PhieuNhapModel> lstModel = new List<PhieuNhapModel>();
            foreach (PhieuNhap it in _phieunhap.getPhieuNhap(Tenphieunhap, Congtyid)) {
                PhieuNhapModel phieunhapModel = new PhieuNhapModel();
                phieunhapModel.id = it.id;
                phieunhapModel.Maphieunhap = it.Maphieunhap;
                phieunhapModel.Mota = it.Mota;
                phieunhapModel.Tenphieunhap = it.Tenphieunhap;
                phieunhapModel.Tencongty = _congty.Getbykey(it.Congtyid).TenCongTy;
                lstModel.Add(phieunhapModel);
            }
            return View("Index",lstModel);
        }

        public ActionResult Create()
        {
            IHangHoa _hanghoa = IoC.Resolve<IHangHoa>();
            IList<HangHoa> lstHanghoa = _hanghoa.GetAll();
            ICongTy _congty = IoC.Resolve<ICongTy>();
            IList<CongTy> lstCongty = _congty.GetAll();
            TempData["Congty"] = new SelectList(lstCongty, "id", "TenCongTy");
            TempData["Hanghoa"] = new SelectList(lstHanghoa, "id", "tenhang");

            return View();
        }

        [HttpPost]
        public ActionResult Create(PhieuNhap _phieunhap, string PubDatasource) {
            IPhieuNhap _pn = IoC.Resolve<IPhieuNhap>();
            if (_pn.CreatePhieunhap(_phieunhap))
            {
                _pn.CommitChanges();
            }

            //DateTime _ngaynhap = DateTime.ParseExact(Ngaynhap, "{HH:mm:ss, dd/MM/yyyy}", CultureInfo.InvariantCulture);
            JavaScriptSerializer jss = new JavaScriptSerializer();
            IList<CT_PhieuNhap> lstCT_PhieuNhap = jss.Deserialize<IList<CT_PhieuNhap>>(PubDatasource);
            ICT_PhieuNhap _ctphieunhap = IoC.Resolve<ICT_PhieuNhap>();


            foreach (CT_PhieuNhap it in lstCT_PhieuNhap) {
                it.PhieunhapId = _phieunhap.id;
                //it.Ngaynhap = _ngaynhap;
                if (_ctphieunhap.CreateCT_PhieuNhap(it))
                {
                    _ctphieunhap.CommitChanges();
                }
            }

            

            return RedirectToAction("Index");
        }

        public JsonResult ViewPhieuNhap(int id) {
            PhieuNhap model = new PhieuNhap();
            IPhieuNhap _phieunhap = IoC.Resolve<IPhieuNhap>();
            ICongTy _congty = IoC.Resolve<ICongTy>();
            PhieuNhapModel pnModel = new PhieuNhapModel();
            model = _phieunhap.Getbykey(id);

            pnModel.id = model.id;
            pnModel.Tenphieunhap = model.Tenphieunhap;
            pnModel.Mota = model.Mota;
            pnModel.Tencongty = _congty.Getbykey(model.Congtyid).TenCongTy;
            return Json(new { id = pnModel.id, tenphieu = pnModel.Tenphieunhap, tencongty = pnModel.Tencongty });
        }

        //load chi tiet phieu nhap theo ma phieu nhap tra ve json
        public String LoadChiTietPhieuNhap(int id)
        {
            IHangHoa _hanghoa = IoC.Resolve<IHangHoa>();
            IPhieuNhap _phieunhap = IoC.Resolve<IPhieuNhap>();
            ICT_PhieuNhap _ctphieunhap = IoC.Resolve<ICT_PhieuNhap>();
            IList<CT_PhieuNhap> lstctphieunhap = _ctphieunhap.GetAll();
            IList<CT_PhieuNhapModel> lstModel = new List<CT_PhieuNhapModel>();
            foreach (CT_PhieuNhap it in lstctphieunhap)
            {
                if (it.PhieunhapId == id)
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
            JavaScriptSerializer js = new JavaScriptSerializer();
            string json = js.Serialize(lstModel);
            return json;
        }
        //tra ve model
        public IList<CT_PhieuNhapModel> LoadChiTietPhieuNhap2(int id)
        {
            IHangHoa _hanghoa = IoC.Resolve<IHangHoa>();
            IPhieuNhap _phieunhap = IoC.Resolve<IPhieuNhap>();
            ICT_PhieuNhap _ctphieunhap = IoC.Resolve<ICT_PhieuNhap>();
            IList<CT_PhieuNhap> lstctphieunhap = _ctphieunhap.GetAll();
            IList<CT_PhieuNhapModel> lstModel = new List<CT_PhieuNhapModel>();
            foreach (CT_PhieuNhap it in lstctphieunhap)
            {
                if (it.PhieunhapId == id)
                {
                    CT_PhieuNhapModel ct_phieunhapModel = new CT_PhieuNhapModel();
                    ct_phieunhapModel.id = it.id;
                    //ct_phieunhapModel.Tenphieunhap = _phieunhap.Getbykey(it.PhieunhapId).Tenphieunhap;
                    ct_phieunhapModel.TenMatHang = it.HanghoaId.ToString();
                    ct_phieunhapModel.Ngaynhap = it.Ngaynhap;
                    ct_phieunhapModel.Soluong = it.Soluong;
                    ct_phieunhapModel.Gianhap = it.Gianhap;
                    ct_phieunhapModel.Ghichu = it.Ghichu;
                    lstModel.Add(ct_phieunhapModel);
                }

            }
            return lstModel;
        }
        //Edit
        public ActionResult Edit(int id) {
            PhieuNhap model = new PhieuNhap();
            IPhieuNhap _phieunhap = IoC.Resolve<IPhieuNhap>();
            ICongTy _CongTy = IoC.Resolve<ICongTy>();
            IList<CongTy> lstCongTy = _CongTy.GetAll();
            PhieuNhapModel pnModel = new PhieuNhapModel();
            IHangHoa _hanghoa = IoC.Resolve<IHangHoa>();
            IList<HangHoa> lstHanghoa = _hanghoa.GetAll();

            model = _phieunhap.Getbykey(id);

            pnModel.id = model.id;
            pnModel.Tenphieunhap = model.Tenphieunhap;
            pnModel.Mota = model.Mota;
            pnModel.Tencongty = _CongTy.Getbykey(model.Congtyid).TenCongTy;
            pnModel.Mota = model.Mota;

            TempData["CT_phieunhap"] = LoadChiTietPhieuNhap2(id);
            ViewBag.listhanghoa = lstHanghoa;
            TempData["Congty"] = new SelectList(lstCongTy, "id", "TenCongTy", selectedValue: model.Congtyid);
            return View(pnModel);
        }
        [HttpPost]
        public ActionResult Edit(PhieuNhap _phieunhap,string PubDatasource) {
            IPhieuNhap _pn = IoC.Resolve<IPhieuNhap>();
            if (_pn.CreatePhieunhap(_phieunhap))
            {
                _pn.CommitChanges();
            }

            //DateTime _ngaynhap = DateTime.ParseExact(Ngaynhap, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            JavaScriptSerializer jss = new JavaScriptSerializer();
            IList<CT_PhieuNhap> lstCT_PhieuNhap = jss.Deserialize<IList<CT_PhieuNhap>>(PubDatasource);
            ICT_PhieuNhap _ctphieunhap = IoC.Resolve<ICT_PhieuNhap>();


            foreach (CT_PhieuNhap it in lstCT_PhieuNhap)
            {
                //it.Ngaynhap = _ngaynhap;
                if (_ctphieunhap.UpdateCT_PhieuNhap(it))
                {
                    _ctphieunhap.CommitChanges();
                }
            }
            return RedirectToAction("Index");
        }
        //xoa phieu nhap
        public ActionResult Delete(int id)
        {
            IPhieuNhap _phieunhap = IoC.Resolve<IPhieuNhap>();
            ICT_PhieuNhap _ictphieunhap = IoC.Resolve<ICT_PhieuNhap>();
            IList<CT_PhieuNhap> lstctphieunhap = _ictphieunhap.GetAll();
            if (lstctphieunhap != null)
            {
                foreach (var it in lstctphieunhap)
                {
                    if (it.PhieunhapId == id)
                    {
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
