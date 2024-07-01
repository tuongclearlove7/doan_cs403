create database WEBSITE_BAN_DT_DB;
drop database WEBSITE_BAN_DT_DB;


create table nguoidung (

	mand varchar(50) primary key,
	email varchar(255),
	tennguoidung varchar(255),
	sdt varchar(255),
	matkhau varchar(255),
    trangthai int
);

create table vaitro (

	mavt varchar(50) primary key,
	tenvaitro varchar(255),
);

create table vaitro_nguoidung (

	mand varchar(50),
	mavt varchar(50),
	FOREIGN KEY (mand) REFERENCES nguoidung(mand),
    FOREIGN KEY (mavt) REFERENCES vaitro(mavt)
);

create table sanpham(

	 masp varchar(50) primary key,
	 tensp varchar(255),
	 mota text,
	 gia decimal

);

create table nhacungcap(

	 mancc varchar(50) primary key,
	 tenncc varchar(255),
	 mota text
);

create table nhaphang(

	 manh varchar(50) primary key,
	 soluong int,
	 ngaynhaphang datetime,
	 masp varchar(50),
	 mancc varchar(50),
	 mota text,
	 FOREIGN KEY (masp) REFERENCES sanpham(masp),
     FOREIGN KEY (mancc) REFERENCES nhacungcap(mancc)
);

create table dathang(

	madh varchar(50) primary key,
	soluong int,
	mand varchar(50),
	masp varchar(50),
	FOREIGN KEY (mand) REFERENCES nguoidung(mand),
    FOREIGN KEY (masp) REFERENCES sanpham(masp)
);

create table hoadon(

	mahd varchar(50) primary key,
	thanhtien decimal,
	madh varchar(50),
	FOREIGN KEY (madh) REFERENCES dathang(madh)
);

create table khuyenmai(

	makm varchar(50) primary key,
	phantram_khuyenmai int,
	masp varchar(50),
    FOREIGN KEY (masp) REFERENCES sanpham(masp)
);


create table danhgia(

	madg varchar(50) primary key,
	noidung text,
	mand varchar(50),
	masp varchar(50),
    FOREIGN KEY (mand) REFERENCES nguoidung(mand),
	FOREIGN KEY (masp) REFERENCES sanpham(masp)
);