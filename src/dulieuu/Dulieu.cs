using System;
using System.Collections.Generic;
using System.IO;

namespace DoAn_QuanLySinhVien {
	internal class Dulieu {
		private string thumucdulieu = "dulieu";
		private string dulieugiangvien = "dulieu/taikhoangiangvien.txt";

		public bool KiemTra() {
			try {
				if (!Directory.Exists(thumucdulieu)) {
					Directory.CreateDirectory(thumucdulieu);
				}
				return true;
			}
			catch (Exception ex) {
				Mau.InLoi("Không tạo được thư mục dữ liệu: " + ex.Message);
				return false;
			}
		}

		public List<GiangVien> NapDanhSachGiangVien() {
			List<GiangVien> ds = new List<GiangVien>();
			if (!File.Exists(dulieugiangvien)) {
				return ds;
			}
			string[] cacdong = File.ReadAllLines(dulieugiangvien);
			for (int i = 0; i < cacdong.Length; i++) {
				string[] taikhoan = cacdong[i].Split(';');
				if (taikhoan.Length < 2) {
					continue;
				}
				string thumuc = LayThuMucGiangVien(taikhoan[0].Trim());
				if (thumuc == "") {
					continue;
				}
				string[] dongtenlop = File.ReadAllLines(thumuc + "/tenlop.txt");
				if (dongtenlop.Length == 0) {
					continue;
				}
				string[] lop = dongtenlop[0].Split(';');
				if (lop.Length < 4) {
					continue;
				}
				GiangVien gv = new GiangVien(
					taikhoan[0].Trim(), 
					lop[3].Trim(), 
					taikhoan[1].Trim(), 
					lop[0].Trim(), 
					lop[1].Trim()
				);
				ds.Add(gv);
			}
			return ds;
		}

		public List<SinhVien> NapDanhSachSinhVien(string malop) {
			List<SinhVien> ds = new List<SinhVien>();
			string thumuc = LayThuMucLop(malop);
			if (thumuc == "") {
				return ds;
			}
			string file = thumuc + "/sinhvien.txt";
			if (!File.Exists(file)) {
				file = thumuc + "/lopthu1.txt";
			}
			if (!File.Exists(file)) {
				return ds;
			}
			string[] cacdong = File.ReadAllLines(file);
			for (int i = 0; i < cacdong.Length; i++) {
				string[] cot = cacdong[i].Split(';');
				if (cot.Length >= 3) {
					float diem = 0;
					float.TryParse(cot[2].Trim(), out diem);
					SinhVien sinhvien = new SinhVien(
						cot[0].Trim(), 
						cot[1].Trim(), 
						diem
					);
					ds.Add(sinhvien);
				}
			}
			return ds;
		}

		public void LuuDanhSachSinhVien(List<SinhVien> danhsachsinhvien, string malop) {
			string thumuc = LayThuMucLop(malop);
			if (thumuc == "") {
				throw new Exception("Không tìm thấy thư mục lớp " + malop);
			}
			string noidung = "";
			for (int i = 0; i < danhsachsinhvien.Count; i++) {
				noidung += danhsachsinhvien[i].TenSinhVien + ";" 
						+ danhsachsinhvien[i].MaSoSinhVien + ";" 
						+ danhsachsinhvien[i].DiemSinhVien + "\n";
			}
			File.WriteAllText(thumuc + "/sinhvien.txt", noidung);
		}

		public void LuuDuLieu(List<GiangVien> danhsachgiangvien) {
			Directory.CreateDirectory(thumucdulieu);
			string taikhoan = "";
			for (int i = 0; i < danhsachgiangvien.Count; i++) {
				GiangVien giangvien = danhsachgiangvien[i];
				taikhoan += giangvien.MaGiangVien + ";" + giangvien.MatKhau + "\n";
				string thumuc = LayThuMucGiangVien(giangvien.MaGiangVien);
				if (thumuc == "") {
					thumuc = thumucdulieu + "/" + giangvien.TenGiangVien;
					if (Directory.Exists(thumuc)) {
						thumuc = thumuc + "_" + giangvien.MaGiangVien;
					}
				}
				Directory.CreateDirectory(thumuc);
				string tenlop = giangvien.MaLop + ";" 
							  + giangvien.TenLop + ";"
							  + giangvien.MaGiangVien + ";" 
							  + giangvien.TenGiangVien;
				File.WriteAllText(thumuc + "/tenlop.txt", tenlop);
				if (!File.Exists(thumuc + "/sinhvien.txt")) {
					File.WriteAllText(thumuc + "/sinhvien.txt", "");
				}
			}
			File.WriteAllText(dulieugiangvien, taikhoan);
		}

		private string LayThuMucGiangVien(string magiangvien) {
			string[] danhsachthumuc = Directory.GetDirectories(thumucdulieu);
			for (int i = 0; i < danhsachthumuc.Length; i++) {
				string file = danhsachthumuc[i] + "/tenlop.txt";
				if (File.Exists(file)) {
					string[] cot = File.ReadAllText(file).Split(';');
					if (cot.Length > 2 && cot[2].Trim() == magiangvien) {
						return danhsachthumuc[i];
					}
				}
			}
			return "";
		}

		private string LayThuMucLop(string malop) {
			string[] danhsachthumuc = Directory.GetDirectories(thumucdulieu);
			for (int i = 0; i < danhsachthumuc.Length; i++) {
				string file = danhsachthumuc[i] + "/tenlop.txt";
				if (File.Exists(file)) {
					string[] cot = File.ReadAllText(file).Split(';');
					if (cot[0].Trim() == malop) {
						return danhsachthumuc[i];
					}
				}
			}
			return "";
		}
	}
}