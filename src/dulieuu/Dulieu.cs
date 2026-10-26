using System;
using System.Collections.Generic;
using System.IO;

namespace DoAn_QuanLySinhVien {
	internal class Dulieu {
		private string thumucdulieu = "dulieu";
		private string dulieugiangvien = "dulieu/taikhoangiangvien.txt";

		public bool KiemTra() {
			try {
				Directory.CreateDirectory(this.thumucdulieu);
				return true;
			}
			catch (Exception ex) {
				Mau.InLoi("Không tạo được thư mục dữ liệu: " + ex.Message);
				return false;
			}
		}

		// đọc tài khoản giảng viên kèm lớp phụ trách từ thư mục của giảng viên
		public List<GiangVien> NapDanhSachGiangVien() {
			List<GiangVien> danhsachgiangvien = new List<GiangVien>();
			if (!File.Exists(this.dulieugiangvien)) {
				return danhsachgiangvien;
			}
			foreach (string dong in File.ReadAllLines(this.dulieugiangvien)) {
				string[] taikhoan = dong.Split(';');
				if (taikhoan.Length < 2) {
					continue;
				}
				string thumuc = this.LayThuMucGiangVien(taikhoan[0].Trim());
				if (thumuc == "") {
					continue;
				}
				string[] donglop = File.ReadAllLines(thumuc + "/tenlop.txt");
				if (donglop.Length == 0) {
					continue;
				}
				string[] lop = donglop[0].Split(';');
				if (lop.Length < 4) {
					continue;
				}
				GiangVien giangvien = new GiangVien(
					taikhoan[0].Trim(),
					lop[3].Trim(),
					taikhoan[1].Trim(),
					lop[0].Trim(),
					lop[1].Trim()
				);
				danhsachgiangvien.Add(giangvien);
			}
			return danhsachgiangvien;
		}

		public List<SinhVien> NapDanhSachSinhVien(string malop) {
			List<SinhVien> danhsachsinhvien = new List<SinhVien>();
			string thumuc = this.LayThuMucLop(malop);
			if (thumuc == "") {
				return danhsachsinhvien;
			}
			string file = thumuc + "/sinhvien.txt";
			if (!File.Exists(file)) {
				// tương thích dữ liệu cũ lưu sinh viên của lớp đầu tiên
				file = thumuc + "/lopthu1.txt";
			}
			if (!File.Exists(file)) {
				return danhsachsinhvien;
			}
			foreach (string dong in File.ReadAllLines(file)) {
				string[] cot = dong.Split(';');
				if (cot.Length >= 3 && float.TryParse(cot[2].Trim(), out float diem)) {
					danhsachsinhvien.Add(new SinhVien(cot[0].Trim(), cot[1].Trim(), diem));
				}
			}
			return danhsachsinhvien;
		}

		public void LuuDanhSachSinhVien(List<SinhVien> danhsachsinhvien, string malop) {
			string thumuc = this.LayThuMucLop(malop);
			if (thumuc == "") {
				throw new Exception("Không tìm thấy thư mục lớp " + malop);
			}
			List<string> dong = new List<string>();
			foreach (SinhVien sinhvien in danhsachsinhvien) {
				dong.Add(sinhvien.TenSinhVien + ";" + sinhvien.MaSoSinhVien + ";" + sinhvien.DiemSinhVien);
			}
			File.WriteAllLines(thumuc + "/sinhvien.txt", dong);
		}

		// ghi tài khoản giảng viên và lớp phụ trách vào thư mục dữ liệu
		public void LuuDuLieu(List<GiangVien> danhsachgiangvien) {
			Directory.CreateDirectory(this.thumucdulieu);
			List<string> taikhoan = new List<string>();
			foreach (GiangVien giangvien in danhsachgiangvien) {
				taikhoan.Add(giangvien.MaGiangVien + ";" + giangvien.MatKhau);
				string thumuc = this.LayThuMucGiangVien(giangvien.MaGiangVien);
				if (thumuc == "") {
					thumuc = this.thumucdulieu + "/" + giangvien.TenGiangVien;
					if (Directory.Exists(thumuc)) {
						thumuc += "_" + giangvien.MaGiangVien;
					}
				}
				Directory.CreateDirectory(thumuc);
				File.WriteAllText(
					thumuc + "/tenlop.txt",
					giangvien.MaLop + ";" + giangvien.TenLop + ";" + giangvien.MaGiangVien + ";" + giangvien.TenGiangVien
				);
				if (!File.Exists(thumuc + "/sinhvien.txt")) {
					File.WriteAllText(thumuc + "/sinhvien.txt", "");
				}
			}
			File.WriteAllLines(this.dulieugiangvien, taikhoan);
		}

		// tìm thư mục của giảng viên theo mã giảng viên
		private string LayThuMucGiangVien(string magiangvien) {
			if (!Directory.Exists(this.thumucdulieu)) {
				return "";
			}
			foreach (string thumuc in Directory.GetDirectories(this.thumucdulieu)) {
				string file = thumuc + "/tenlop.txt";
				if (!File.Exists(file)) {
					continue;
				}
				foreach (string dong in File.ReadAllLines(file)) {
					string[] cot = dong.Split(';');
					if (cot.Length > 2 && cot[2].Trim() == magiangvien) {
						return thumuc;
					}
				}
			}
			return "";
		}

		// tìm thư mục của lớp theo mã lớp
		private string LayThuMucLop(string malop) {
			if (!Directory.Exists(this.thumucdulieu)) {
				return "";
			}
			foreach (string thumuc in Directory.GetDirectories(this.thumucdulieu)) {
				string file = thumuc + "/tenlop.txt";
				if (!File.Exists(file)) {
					continue;
				}
				foreach (string dong in File.ReadAllLines(file)) {
					string[] cot = dong.Split(';');
					if (cot.Length > 0 && cot[0].Trim() == malop) {
						return thumuc;
					}
				}
			}
			return "";
		}
	}
}
