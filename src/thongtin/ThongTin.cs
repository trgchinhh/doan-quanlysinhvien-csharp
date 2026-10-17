using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_QuanLySinhVien {
    internal class ThongTin {
        public static string thongtin = @"
        ┌──────────────────────────────────────────────────────────────────────────────────┐
        │                       CHƯƠNG TRÌNH QUẢN LÝ SINH VIÊN C#                          │
        ├──────────────────────────────────────────────────────────────────────────────────┤
        │ Giáo viên hướng dẫn: Trần Quốc Trường                                            │
        │ Sinh viên thực hiện: Nguyễn Bảo Lam                                              │
        │ Hạn nộp: Cuối học kỳ 1                                                           │
        │ Đề tài: Xây dựng chương trình quản lý sinh viên cho giảng viên bằng ngôn ngữ C#  │ 
        ├──────────────────────────────────────────────────────────────────────────────────┤
        │ Giới thiệu                                                                       │
        │                                                                                  │
        │ Chương trình mô phỏng các vận hành của các ứng dụng/web quản lý sinh viên trong  │
        │ thực tế gồm nhiều tài khoản thầy cô vào quản lý nhiều lớp của mình gồm nhiều     │
        │ tính năng cơ bản của một hệ thống quản lý. Ngoài ra, chương trình còn phân chia  │
        │ lưu trữ tên lớp, sinh viên từng lớp vào database local bằng các file text (.txt) │
        │ theo từng folder tên giảng viên. Bên cạnh đó chương trình còn dùng SHA256 để băm │
        │ password như hệ thống thật.                                                      │
        ├──────────────────────────────────────────────────────────────────────────────────┤
        │ Tìm hiểu nghiệp vụ cơ bản                                                        │
        │                                                                                  │
        │ - Quản lý tài khoản giảng viên: đăng nhập, đăng xuất và cập nhật thông tin       │
        │   giảng viên                                                                     │
        │ - Quản lý nhiều lớp học cho mỗi giảng viên                                       │
        │ - Lưu thông tin lớp học gồm mã lớp, tên lớp, giảng viên phụ trách                │
        │   và số thứ tự lớp                                                               │
        │ - Quản lý danh sách sinh viên theo từng lớp                                      │
        │ - Lưu thông tin sinh viên gồm họ tên, mã số sinh viên và điểm                    │
        │ - Thêm sinh viên mới vào lớp                                                     │
        │ - Sửa thông tin sinh viên                                                        │
        │ - Xóa sinh viên khỏi lớp                                                         │
        │ - Hiển thị danh sách sinh viên, điểm và học lực                                  │
        │ - Tìm kiếm thông tin sinh viên theo tên, mã số (chưa)                            │
        │ - Lọc sinh viên theo tên, mã số, điểm hoặc học lực                               │
        │ - Sắp xếp danh sách sinh viên theo tên, mã số hoặc điểm                          │
        │ - Thống kê sĩ số, điểm trung bình, điểm cao nhất và điểm thấp nhất của 1 lớp     │
        │ - Thống kê sĩ số, điểm trung bình, điểm cao nhất và thấp nhất các lớp của        │
        │   giảng viên (chưa)                                                              │
        │ - Tự động sao lưu dữ liệu vào các tệp văn bản để sử dụng lại khi mở chương trình │
        ├──────────────────────────────────────────────────────────────────────────────────┤
        │ Ưu điểm                                                                          │
        │                                                                                  │
        │ - Có coding convention rõ ràng (tên biến, hàm, dễ đọc hiểu)                      │
        │ - Phân chia các module rõ ràng dễ bảo trì sau này                                │
        │ - Chống nhập sai nhiều lớp                                                       │
        │ - Database phân chia theo folder dễ theo dõi                                     │
        │ - Có database mẫu ban đầu nên không cần chạy tay                                 │
        ├──────────────────────────────────────────────────────────────────────────────────┤
        │ Nhược điểm                                                                       │
        │                                                                                  │
        │ - Chưa tối ưu và tinh gọn code                                                   │
        │ - Khó hiểu ở 1 số chỗ đặt tên chưa rõ ràng và trùng lặp                          │
        └──────────────────────────────────────────────────────────────────────────────────┘
";
        
        // in thông báo theo trang (dễ đọc từ đầu ko cần phải scroll lên )
        public static void InThongTin(){
            Console.Clear();
            string[] cacdong = thongtin.Split('\n');
            int sodongtungtrang = Console.WindowHeight - 2;
            int tongtrang = cacdong.Length / sodongtungtrang;
            int tongsotrang = (int)Math.Ceiling((double)tongtrang);
            int tranghientai = 1;
            int dem = 0;
            foreach (string dong in cacdong) {
                Console.WriteLine(dong.TrimEnd('\r'));
                dem++;
                if (dem == sodongtungtrang) {
                    Console.WriteLine();
                    Console.WriteLine($"-- Nhấn phím bất kỳ để qua trang ({tranghientai}/{tongsotrang}) --");
                    Console.Write($"-- Nhấn q để quay lại --");
                    char c = Console.ReadKey(true).KeyChar;
                    if(c == 'q'){
                        return;
                    }
                    Console.Clear();
                    dem = 0;
                    tranghientai++;
                }
            }
        }
    }
}