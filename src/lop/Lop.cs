using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_QuanLySinhVien {
	internal class Lop {
		private string malop = "";
		private string tenlop = "";
		private string tenlopgoc = "";
		private int sothutu = 0;
		private string magiangvien = "";

		public Lop() {
			this.malop = "";
			this.tenlop = "";
		}

		public Lop(string malop, string tenlop) {
			this.MaLop = malop;
			this.TenLop = tenlop;
			this.TenLopGoc = tenlop;
		}

		public string MaLop {
			get { return this.malop; }
			set
			{
				if (!string.IsNullOrEmpty(value)) {
					this.malop = value;
				}
			}
		}

		public string TenLop {
			get { return this.tenlop; }
			set
			{
				if (!string.IsNullOrEmpty(value)) {
					this.tenlop = value;
				}
			}
		}

		public string TenLopGoc {
			get { return this.tenlopgoc; }
			set {
				if (!string.IsNullOrEmpty(value)) {
					this.tenlopgoc = value;
				}
			}
		}

		public int SoThuTu {
			get { return this.sothutu; }
			set { this.sothutu = value; }
		}

		public string MaGiangVien {
			get { return this.magiangvien; }
			set { this.magiangvien = value; }
		}

		// Phương thức 
		// tên lớp đầy đủ (mã lớp - tên lớp) phục vụ in ra màn hình
		public string LayTenLopDayDu() {
			return $"{this.MaLop} ({this.TenLop})";
		}
	}
}
