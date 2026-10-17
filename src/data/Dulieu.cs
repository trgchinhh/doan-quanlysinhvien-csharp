using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_QuanLySinhVien {
	internal class Dulieu {
		private string thumucdulieu = "database";
		private string dulieugiangvien = "database/datagiangvien.txt";
		public bool KiemTra() {
			try {
				Directory.CreateDirectory(thumucdulieu);
				return true;
			}
			catch (Exception ex) {
				Mau.InLoi("Không tạo được thư mục dữ liệu: " + ex.Message);
				return false;
			}
		}

		public List<Lop> NapDanhSachLop() {
			List<Lop> danhsachlop = new List<Lop>();
			string[] danhsachthumuc = Directory.GetDirectories(thumucdulieu);
			foreach (string thumuc in danhsachthumuc) {
				string teplop = thumuc + "/tenlop.txt";
				if (File.Exists(teplop)) {
					string[] thongtin = File.ReadAllText(teplop).Split(';');
					if (thongtin.Length >= 2) {
						danhsachlop.Add(new Lop(thongtin[0], thongtin[1]));
					}
				}
			}
			return danhsachlop;
		}

		public List<GiangVien> NapDanhSachGiangVien() {
			List<GiangVien> danhsachgiangvien = new List<GiangVien>();
			string[] danhsachtaikhoan = new string[0];
			if (File.Exists(dulieugiangvien)) {
				danhsachtaikhoan = File.ReadAllLines(dulieugiangvien);
			}
			string[] danhsachthumuc = Directory.GetDirectories(thumucdulieu);
			foreach (string taikhoan in danhsachtaikhoan) {
				string[] thongtintaikhoan = taikhoan.Split(';');
				if (thongtintaikhoan.Length >= 2) {
					foreach (string thumuc in danhsachthumuc) {
						string teplop = thumuc + "/tenlop.txt";
						if (File.Exists(teplop)) {
							string[] thongtinlop = File.ReadAllText(teplop).Split(';');
							if (thongtinlop.Length >= 4 && thongtinlop[2] == thongtintaikhoan[0]) {
								GiangVien giangvien = new GiangVien(thongtinlop[2], thongtinlop[3].Trim(), "x", thongtinlop[0], thongtinlop[1]);
								giangvien.GanMatKhauDaMaHoa(thongtintaikhoan[1]);
								danhsachgiangvien.Add(giangvien);
							}
						}
					}
				}
			}
			return danhsachgiangvien;
		}

		public List<SinhVien> NapDanhSachSinhVien(string malop) {
			List<SinhVien> danhsachsinhvien = new List<SinhVien>();
			string[] danhsachthumuc = Directory.GetDirectories(thumucdulieu);
			foreach (string thumuc in danhsachthumuc) {
				string teplop = thumuc + "/tenlop.txt";
				if (File.Exists(teplop)) {
					string[] thongtinlop = File.ReadAllText(teplop).Split(';');
					if (thongtinlop.Length > 0 && thongtinlop[0] == malop) {
						string tepsinhvien = thumuc + "/sinhvien.txt";
						if (File.Exists(tepsinhvien)) {
							string[] danhsachdong = File.ReadAllLines(tepsinhvien);
							foreach (string dong in danhsachdong) {
								string[] thongtinsinhvien = dong.Split(';');
								if (thongtinsinhvien.Length >= 3) {
									float diem;
									if (float.TryParse(thongtinsinhvien[2], out diem)) {
										danhsachsinhvien.Add(
											new SinhVien(thongtinsinhvien[0], 
												thongtinsinhvien[1], 
												diem
											)
										);
									}
								}
							}
						}
					}
				}
			}
			return danhsachsinhvien;
		}

		public void LuuDuLieu(List<Lop> danhsachlop, List<GiangVien> danhsachgiangvien) {
			Directory.CreateDirectory(thumucdulieu);
			List<string> danhsachtaikhoan = new List<string>();
			foreach (GiangVien giangvien in danhsachgiangvien) {
				string tenlop = "";
				foreach (Lop lop in danhsachlop) {
					if (lop.MaLop == giangvien.MaLop) {
						tenlop = lop.TenLop;
					}
				}
				string thumuc = LayThuMucGiangVien(giangvien.MaGiangVien);
				if (thumuc == "") {
					thumuc = thumucdulieu + "/" + giangvien.TenGiangVien;
					if (Directory.Exists(thumuc)) {
						thumuc += "_" + giangvien.MaGiangVien;
					}
					Directory.CreateDirectory(thumuc);
				}
				string thongtinlop = giangvien.MaLop + ";" + tenlop + ";" + giangvien.MaGiangVien + ";" + giangvien.TenGiangVien;
				File.WriteAllText(thumuc + "/tenlop.txt", thongtinlop);
				if (!File.Exists(thumuc + "/sinhvien.txt")) {
					File.WriteAllText(thumuc + "/sinhvien.txt", "");
				}
				danhsachtaikhoan.Add(giangvien.MaGiangVien + ";" + giangvien.MatKhau);
			}
			File.WriteAllLines(dulieugiangvien, danhsachtaikhoan);
		}

		public void LuuDanhSachSinhVien(List<SinhVien> danhsachsinhvien, string malop) {
			string[] danhsachthumuc = Directory.GetDirectories(thumucdulieu);
			foreach (string thumuc in danhsachthumuc) {
				string teplop = thumuc + "/tenlop.txt";
				if (File.Exists(teplop)) {
					string[] thongtinlop = File.ReadAllText(teplop).Split(';');
					if (thongtinlop.Length > 0 && thongtinlop[0] == malop) {
						List<string> danhsachdong = new List<string>();
						foreach (SinhVien sinhvien in danhsachsinhvien) {
							danhsachdong.Add(sinhvien.TenSinhVien + ";" + sinhvien.MaSoSinhVien + ";" + sinhvien.DiemSinhVien);
						}
						File.WriteAllLines(thumuc + "/sinhvien.txt", danhsachdong);
						return;
					}
				}
			}
			throw new Exception("Không tìm thấy thư mục lớp " + malop);
		}

		private string LayThuMucGiangVien(string magiangvien) {
			string[] danhsachthumuc = Directory.GetDirectories(thumucdulieu);
			foreach (string thumuc in danhsachthumuc) {
				string teplop = thumuc + "/tenlop.txt";
				if (File.Exists(teplop)) {
					string[] thongtinlop = File.ReadAllText(teplop).Split(';');
					if (thongtinlop.Length >= 3 && thongtinlop[2] == magiangvien) {
						return thumuc;
					}
				}
			}
			return "";
		}
	}
}
