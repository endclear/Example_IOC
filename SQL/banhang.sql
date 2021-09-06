create database BanHang
use BanHang
create table QuocGia(
	id int identity(1,1) primary key,
	MaQuocGia varchar(20),
	TenQuocGia nvarchar(5)
)
create table CongTy(
	id int identity(1,1) primary key,
	TenCongTy nvarchar(50),
	DienThoai varchar(12),
	Website nvarchar(150),
	Email nvarchar(50),
	MaSoThue varchar(50),
	DiaChi nvarchar(100),
	OrderNumber int
)
create table KhachHang(
	id int identity(1,1) primary key,
	HoTen nvarchar(50),
	Gioitinh nvarchar(8),
	NgaySinh date,
	DienThoai nvarchar(11),
	Email nvarchar(50),
	DiaChi nvarchar(100),
	GhiChu nvarchar(100),
	CongtyID int,
	SoCMT int,
	NgayCap datetime,
	NoiCap nvarchar(100),
	constraint fk_macongty foreign key(CongtyID) references CongTy(id)
)
create table phieunhap(
	id int identity(1,1) primary key,
	Maphieunhap varchar(20),
	TenPhieuNhap nvarchar(50),
	Mota nvarchar(200),
	CongtyID int,
	constraint fk_phieunhap_congty foreign key(CongtyID) references Congty(id)
)
create table hanghoa(
	id int identity(1,1) primary key,
	MaHang varchar(20),
	TenHang nvarchar(200),
	MoTa nvarchar(200),
	XuatXuID int,
	OrderNumber int,
	constraint fk_hanghoa_quocgia foreign key(XuatXuID) references QuocGia(id)
)
create table phieuxuat(
	id int identity(1,1) primary key,
	Maphieuxuat varchar(20),
	TenPhieuxuat nvarchar(50),
	Mota nvarchar(200),
	KhachHangID int,
	constraint fk_phieuxuat_khachhang foreign key(KhachHangID) references Khachhang(id)
)
create table phieuxuat_hanghoa(
	id int identity(1,1),
	PhieuXuatID int,
	HangHoaID int,
	NgayXuat Datetime,
	constraint pk_phieuxuat_hanghoa primary key(PhieuXuatID,HangHoaID,NgayXuat),
	SoLuong int,
	GiaBan decimal,
	GhiChu nvarchar(100),
	constraint fk_toPhieuxuat foreign key (PhieuXuatID)	references PhieuXuat(id),
	constraint fk_toHangHoa foreign key (HangHoaID)	references HangHoa(id)
)
create table phieunhap_hanghoa(
	id int identity(1,1),
	PhieuNhapID int,
	HangHoaID int,
	NgayNhap Datetime,
	constraint pk_phieunhap_hanghoa primary key(PhieuNhapID,HangHoaID,NgayNhap),
	SoLuong int,
	GiaNhap decimal,
	GhiChu nvarchar(100),
	constraint fk_toPhieunhap foreign key (PhieuNhapID)	references PhieuNhap(id),
	constraint fk_toHangHoa2 foreign key (HangHoaID)	references HangHoa(id)
)