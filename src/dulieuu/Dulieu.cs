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
				string[] tk = cacdong[i].Split(';');
				if (tk.Length < 2) {
					continue;
				}
				string thumuc = LayThuMucGiangVien(tk[0].Trim());
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
				GiangVien gv = new GiangVien(tk[0].Trim(), lop[3].Trim(), tk[1].Trim(), lop[0].Trim(), lop[1].Trim());
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
					ds.Add(new SinhVien(cot[0].Trim(), cot[1].Trim(), diem));
				}
			}
			return ds;
		}

		public void LuuDanhSachSinhVien(List<SinhVien> ds, string malop) {
			string thumuc = LayThuMucLop(malop);
			if (thumuc == "") {
				throw new Exception("Không tìm thấy thư mục lớp " + malop);
			}
			string noidung = "";
			for (int i = 0; i < ds.Count; i++) {
				noidung += ds[i].TenSinhVien + ";" + ds[i].MaSoSinhVien + ";" + ds[i].DiemSinhVien + "\n";
			}
			File.WriteAllText(thumuc + "/sinhvien.txt", noidung);
		}

		public void LuuDuLieu(List<GiangVien> ds) {
			Directory.CreateDirectory(thumucdulieu);
			string taikhoan = "";
			for (int i = 0; i < ds.Count; i++) {
				GiangVien gv = ds[i];
				taikhoan += gv.MaGiangVien + ";" + gv.MatKhau + "\n";
				string thumuc = LayThuMucGiangVien(gv.MaGiangVien);
				if (thumuc == "") {
					thumuc = thumucdulieu + "/" + gv.TenGiangVien;
					if (Directory.Exists(thumuc)) {
						thumuc = thumuc + "_" + gv.MaGiangVien;
					}
				}
				Directory.CreateDirectory(thumuc);
				string tenlop = gv.MaLop + ";" + gv.TenLop + ";" + gv.MaGiangVien + ";" + gv.TenGiangVien;
				File.WriteAllText(thumuc + "/tenlop.txt", tenlop);
				if (!File.Exists(thumuc + "/sinhvien.txt")) {
					File.WriteAllText(thumuc + "/sinhvien.txt", "");
				}
			}
			File.WriteAllText(dulieugiangvien, taikhoan);
		}

		private string LayThuMucGiangVien(string magiangvien) {
			string[] dsthumuc = Directory.GetDirectories(thumucdulieu);
			for (int i = 0; i < dsthumuc.Length; i++) {
				string file = dsthumuc[i] + "/tenlop.txt";
				if (File.Exists(file)) {
					string[] cot = File.ReadAllText(file).Split(';');
					if (cot.Length > 2 && cot[2].Trim() == magiangvien) {
						return dsthumuc[i];
					}
				}
			}
			return "";
		}

		private string LayThuMucLop(string malop) {
			string[] dsthumuc = Directory.GetDirectories(thumucdulieu);
			for (int i = 0; i < dsthumuc.Length; i++) {
				string file = dsthumuc[i] + "/tenlop.txt";
				if (File.Exists(file)) {
					string[] cot = File.ReadAllText(file).Split(';');
					if (cot[0].Trim() == malop) {
						return dsthumuc[i];
					}
				}
			}
			return "";
		}
	}
}