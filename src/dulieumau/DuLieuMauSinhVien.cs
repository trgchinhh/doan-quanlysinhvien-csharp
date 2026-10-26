using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_QuanLySinhVien {
    internal class DuLieuMauSinhVien {
        public static List<(string ten, string mssv, float diem, string malop)> danhsachsinhvienmau =
            new List<(string ten, string mssv, float diem, string malop)> {
            // Lớp OOP1
            ("Nguyễn Trường Chinh", "DH52400001", 7.6f, "OOP1"),
            ("Trần Minh Gia Bảo", "DH52400002", 7.6f, "OOP1"),
            ("Trần Minh Anh", "DH52400003", 7.1f, "OOP1"),
            ("Hoàng Ngọc Hân", "DH52400004", 6.2f, "OOP1"),
            ("Bùi Đức Anh", "DH52400005", 3.0f, "OOP1"),
            ("Hồ Thùy Dương", "DH52400006", 9.9f, "OOP1"),
            ("Phan Mai Phương", "DH52400007", 1.5f, "OOP1"),
            ("Đoàn Gia Huy", "DH52400008", 7.9f, "OOP1"),
            ("Kiều Thanh Tâm", "DH52400009", 6.8f, "OOP1"),
            ("Lương Minh Quân", "DH52400010", 8.1f, "OOP1"),
            // Lớp CSDL1
            ("Lê Hoàng Nam", "DH52400011", 8.3f, "CSDL1"),
            ("Vũ Võ Tuấn Kiệt", "DH52400012", 6.7f, "CSDL1"),
            ("Đỗ Khánh Linh", "DH52400013", 5.8f, "CSDL1"),
            ("Lý Hoàng Long", "DH52400014", 7.8f, "CSDL1"),
            ("Đặng Văn Lâm", "DH52400015", 10.0f, "CSDL1"),
            ("Nguyễn Duy Quang", "DH52400016", 9.1f, "CSDL1"),
            ("Phùng Anh Thư", "DH52400017", 9.4f, "CSDL1"),
            ("Châu Quốc Việt", "DH52400018", 5.9f, "CSDL1"),
            ("Thái Ngọc Ánh", "DH52400019", 7.2f, "CSDL1"),
            ("Quách Đình Phong", "DH52400020", 8.7f, "CSDL1"),
            // Lớp IPC1
            ("Nguyễn Thanh Tùng", "DH52400021", 9.1f, "IPC1"),
            ("Đặng Phương Thảo", "DH52400022", 3.5f, "IPC1"),
            ("Ngô Quốc Huy", "DH52400023", 7.6f, "IPC1"),
            ("Võ Đình Khang", "DH52400024", 6.4f, "IPC1"),
            ("Trần Văn Đan", "DH52400025", 8.0f, "IPC1"),
            ("Nguyễn Duy Minh", "DH52400026", 9.2f, "IPC1"),
            ("Nguyễn Trường An", "DH52400027", 8.5f, "IPC1"),
            ("Lê Thị Ngọc Tú", "DH52400028", 10.0f, "IPC1"),
            ("La Thúy Hằng", "DH52400029", 6.6f, "IPC1"),
            ("Âu Hoàng Sơn", "DH52400030", 7.5f, "IPC1"),
            // Lớp MHUD1
            ("Phạm Quốc Bảo", "DH52400031", 8.2f, "MHUD1"),
            ("Lê Minh Châu", "DH52400032", 7.4f, "MHUD1"),
            ("Trần Hải Đăng", "DH52400033", 6.5f, "MHUD1"),
            ("Võ Thanh Hà", "DH52400034", 9.0f, "MHUD1"),
            ("Huỳnh Gia Hưng", "DH52400035", 5.5f, "MHUD1"),
            ("Đinh Ngọc Mai", "DH52400036", 8.8f, "MHUD1"),
            ("Dương Anh Khoa", "DH52400037", 7.0f, "MHUD1"),
            ("Lâm Thu Hiền", "DH52400038", 9.5f, "MHUD1"),
            ("Mai Văn Phúc", "DH52400039", 4.8f, "MHUD1"),
            ("Tạ Bảo Ngọc", "DH52400040", 8.0f, "MHUD1"),
            // Lớp KTLT1
            ("Phạm Thanh Hà", "DH52400041", 7.7f, "KTLT1"),
            ("Lê Gia Hưng", "DH52400042", 6.9f, "KTLT1"),
            ("Trần Bảo Ngọc", "DH52400043", 9.3f, "KTLT1"),
            ("Bùi Anh Khoa", "DH52400044", 5.2f, "KTLT1"),
            ("Hoàng Thu Hiền", "DH52400045", 8.6f, "KTLT1"),
            ("Đỗ Minh Châu", "DH52400046", 7.3f, "KTLT1"),
            ("Ngô Hải Đăng", "DH52400047", 6.1f, "KTLT1"),
            ("Vương Khánh Vy", "DH52400048", 9.7f, "KTLT1"),
            ("Cao Đức Thịnh", "DH52400049", 4.5f, "KTLT1"),
            ("Trịnh Mỹ Linh", "DH52400050", 8.4f, "KTLT1"),
            // Lớp NMLT1
            ("Nguyễn Thành Đạt", "DH52400051", 7.5f, "NMLT1"),
            ("Lê Thị Hồng Nhung", "DH52400052", 8.2f, "NMLT1"),
            ("Trần Quốc Khánh", "DH52400053", 6.4f, "NMLT1"),
            ("Phạm Thị Thanh Mai", "DH52400054", 9.0f, "NMLT1"),
            ("Võ Hoàng Anh", "DH52400055", 5.3f, "NMLT1"),
            ("Đặng Minh Hiếu", "DH52400056", 7.8f, "NMLT1"),
            ("Bùi Thị Ngọc Ánh", "DH52400057", 8.6f, "NMLT1"),
            ("Hoàng Văn Toàn", "DH52400058", 4.7f, "NMLT1"),
            ("Lý Gia Hân", "DH52400059", 9.3f, "NMLT1"),
            ("Ngô Đức Duy", "DH52400060", 6.9f, "NMLT1"),
            // Lớp CTDLGT1
            ("Phan Thành Công", "DH52400061", 7.1f, "CTDLGT1"),
            ("Trương Mỹ Linh", "DH52400062", 8.4f, "CTDLGT1"),
            ("Đỗ Quang Huy", "DH52400063", 5.9f, "CTDLGT1"),
            ("Lê Thị Kim Ngân", "DH52400064", 9.5f, "CTDLGT1"),
            ("Nguyễn Hữu Nghĩa", "DH52400065", 6.2f, "CTDLGT1"),
            ("Huỳnh Bảo Trân", "DH52400066", 7.7f, "CTDLGT1"),
            ("Vũ Minh Khang", "DH52400067", 3.4f, "CTDLGT1"),
            ("Dương Thị Thu Thảo", "DH52400068", 8.9f, "CTDLGT1"),
            ("Tô Văn Hải", "DH52400069", 6.6f, "CTDLGT1"),
            ("Lâm Ngọc Diệp", "DH52400070", 9.2f, "CTDLGT1"),
            // Lớp QTCSDL1
            ("Trần Văn Lộc", "DH52400071", 7.3f, "QTCSDL1"),
            ("Nguyễn Thị Phương Anh", "DH52400072", 8.0f, "QTCSDL1"),
            ("Lê Hoàng Phúc", "DH52400073", 5.6f, "QTCSDL1"),
            ("Phạm Gia Bảo", "DH52400074", 9.1f, "QTCSDL1"),
            ("Võ Thị Mỹ Duyên", "DH52400075", 6.8f, "QTCSDL1"),
            ("Đinh Quốc Thắng", "DH52400076", 7.9f, "QTCSDL1"),
            ("Mai Thị Bích Trâm", "DH52400077", 4.9f, "QTCSDL1"),
            ("Cao Minh Tuấn", "DH52400078", 8.3f, "QTCSDL1"),
            ("Bùi Thanh Tùng", "DH52400079", 6.0f, "QTCSDL1"),
            ("Hồ Thị Thu Hà", "DH52400080", 9.6f, "QTCSDL1"),
            // Lớp LTWEB1
            ("Nguyễn Anh Khoa", "DH52400081", 8.1f, "LTWEB1"),
            ("Trần Thị Cẩm Vân", "DH52400082", 7.0f, "LTWEB1"),
            ("Lê Văn Đức", "DH52400083", 5.5f, "LTWEB1"),
            ("Phạm Thùy Linh", "DH52400084", 9.4f, "LTWEB1"),
            ("Đặng Trọng Nhân", "DH52400085", 6.3f, "LTWEB1"),
            ("Võ Hải Yến", "DH52400086", 7.6f, "LTWEB1"),
            ("Hoàng Gia Huy", "DH52400087", 3.9f, "LTWEB1"),
            ("Lưu Thị Ngọc Hà", "DH52400088", 8.7f, "LTWEB1"),
            ("Chu Minh Đạt", "DH52400089", 6.5f, "LTWEB1"),
            ("Vương Thảo Nguyên", "DH52400090", 9.8f, "LTWEB1"),
            // Lớp LTWIN1
            ("Phan Đình Long", "DH52400091", 7.4f, "LTWIN1"),
            ("Trương Thị Hoa", "DH52400092", 8.5f, "LTWIN1"),
            ("Đỗ Minh Nhật", "DH52400093", 5.1f, "LTWIN1"),
            ("Lê Bảo Ngọc", "DH52400094", 9.0f, "LTWIN1"),
            ("Nguyễn Văn Sơn", "DH52400095", 6.7f, "LTWIN1"),
            ("Huỳnh Thị Tố Uyên", "DH52400096", 7.2f, "LTWIN1"),
            ("Vũ Quang Vinh", "DH52400097", 4.3f, "LTWIN1"),
            ("Dương Hoài An", "DH52400098", 8.8f, "LTWIN1"),
            ("Tô Thị Thanh Tâm", "DH52400099", 6.1f, "LTWIN1"),
            ("Lâm Đức Thành", "DH52400100", 9.3f, "LTWIN1"),
        };
    }
}