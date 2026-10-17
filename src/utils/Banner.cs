using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_QuanLySinhVien {
    internal class Banner {
        public static string BannerDoAnTinHoc = @" _____   ____             _   _   _______ _____ _   _   _    _  ____   _____ 
|  __ \ / __ \      /\   | \ | | |__   __|_   _| \ | | | |  | |/ __ \ / ____|
| |  | | |  | |    /  \  |  \| |    | |    | | |  \| | | |__| | |  | | |     
| |  | | |  | |   / /\ \ | . ` |    | |    | | | . ` | |  __  | |  | | |     
| |__| | |__| |  / ____ \| |\  |    | |   _| |_| |\  | | |  | | |__| | |____ 
|_____/ \____/  /_/    \_\_| \_|    |_|  |_____|_| \_| |_|  |_|\____/ \_____|
 
                                        - GVHD: TRẦN QUỐC TRƯỜNG
                                        - SVTH: NGUYỄN BẢO LAM
                                        - ĐỀ TÀI: XÂY DỰNG CHƯƠNG TRÌNH QUẢN LÝ SINH VIÊN 
        ";

        public static string BannerXacThuc = @"__   __          _____   _______ _    _ _    _  _____ 
\ \ / /    /\   / ____| |__   __| |  | | |  | |/ ____|
 \ V /    /  \ | |         | |  | |__| | |  | | |     
  > <    / /\ \| |         | |  |  __  | |  | | |     
 / . \  / ____ \ |____     | |  | |  | | |__| | |____ 
/_/ \_\/_/    \_\_____|    |_|  |_|  |_|\____/ \_____|
 
                                        - GVHD: TRẦN QUỐC TRƯỜNG
                                        - SVTH: NGUYỄN BẢO LAM
                                        - ĐỀ TÀI: XÂY DỰNG CHƯƠNG TRÌNH QUẢN LÝ SINH VIÊN    
        ";

        public static string BannerTaiKhoanMau = @" _______       _____   _  ___    _  ____          _   _   __  __         _    _ 
|__   __|/\   |_   _| | |/ / |  | |/ __ \   /\   | \ | | |  \/  |   /\  | |  | |
   | |  /  \    | |   | ' /| |__| | |  | | /  \  |  \| | | \  / |  /  \ | |  | |
   | | / /\ \   | |   |  < |  __  | |  | |/ /\ \ | . ` | | |\/| | / /\ \| |  | |
   | |/ ____ \ _| |_  | . \| |  | | |__| / ____ \| |\  | | |  | |/ ____ \ |__| |
   |_/_/    \_\_____| |_|\_\_|  |_|\____/_/    \_\_| \_| |_|  |_/_/    \_\____/ 
 
                                        - GVHD: TRẦN QUỐC TRƯỜNG
                                        - SVTH: NGUYỄN BẢO LAM
                                        - ĐỀ TÀI: XÂY DỰNG CHƯƠNG TRÌNH QUẢN LÝ SINH VIÊN 
        ";

        public static string BannerDangKy = @" _____          _   _  _____   _  ____     __
|  __ \   /\   | \ | |/ ____| | |/ /\ \   / /
| |  | | /  \  |  \| | |  __  | ' /  \ \_/ / 
| |  | |/ /\ \ | . ` | | |_ | |  <    \   /  
| |__| / ____ \| |\  | |__| | | . \    | |   
|_____/_/    \_\_| \_|\_____| |_|\_\   |_|   
 
                                        - GVHD: TRẦN QUỐC TRƯỜNG
                                        - SVTH: NGUYỄN BẢO LAM
                                        - ĐỀ TÀI: XÂY DỰNG CHƯƠNG TRÌNH QUẢN LÝ SINH VIÊN 
        ";

        public static string BannerDangNhap = @" _____          _   _  _____   _   _ _    _          _____  
|  __ \   /\   | \ | |/ ____| | \ | | |  | |   /\   |  __ \ 
| |  | | /  \  |  \| | |  __  |  \| | |__| |  /  \  | |__) |
| |  | |/ /\ \ | . ` | | |_ | | . ` |  __  | / /\ \ |  ___/ 
| |__| / ____ \| |\  | |__| | | |\  | |  | |/ ____ \| |     
|_____/_/    \_\_| \_|\_____| |_| \_|_|  |_/_/    \_\_|     

                                        - GVHD: TRẦN QUỐC TRƯỜNG
                                        - SVTH: NGUYỄN BẢO LAM
                                        - ĐỀ TÀI: XÂY DỰNG CHƯƠNG TRÌNH QUẢN LÝ SINH VIÊN 
        ";  

        public static string BannerChonMau = @"  _____ _    _  ____  _   _   __  __         _    _ 
 / ____| |  | |/ __ \| \ | | |  \/  |   /\  | |  | |
| |    | |__| | |  | |  \| | | \  / |  /  \ | |  | |
| |    |  __  | |  | | . ` | | |\/| | / /\ \| |  | |
| |____| |  | | |__| | |\  | | |  | |/ ____ \ |__| |
 \_____|_|  |_|\____/|_| \_| |_|  |_/_/    \_\____/ 
 
                                        - GVHD: TRẦN QUỐC TRƯỜNG
                                        - SVTH: NGUYỄN BẢO LAM
                                        - ĐỀ TÀI: XÂY DỰNG CHƯƠNG TRÌNH QUẢN LÝ SINH VIÊN
        ";

        public static string BannerTamBiet = @" _______       __  __   ____ _____ ______ _______ 
|__   __|/\   |  \/  | |  _ \_   _|  ____|__   __|
   | |  /  \  | \  / | | |_) || | | |__     | |   
   | | / /\ \ | |\/| | |  _ < | | |  __|    | |   
   | |/ ____ \| |  | | | |_) || |_| |____   | |   
   |_/_/    \_\_|  |_| |____/_____|______|  |_|   
                                                   
                                        - GVHD: TRẦN QUỐC TRƯỜNG
                                        - SVTH: NGUYỄN BẢO LAM
                                        - ĐỀ TÀI: XÂY DỰNG CHƯƠNG TRÌNH QUẢN LÝ SINH VIÊN
        ";

        public static string BannerChinh = @"┌──────────────────────────────┐
│      ĐỒ ÁN TIN HỌC HK1       │
│ GVHD: Trần Quốc Trường       │
│ SVTH: Nguyễn Bảo Lam         │
│ Đề tài: Quản Lý Sinh Viên C# │
└──────────────────────────────┘
        ";

        public static void Inbanner(string banner){
            Console.WriteLine(banner);
        }
    }
}