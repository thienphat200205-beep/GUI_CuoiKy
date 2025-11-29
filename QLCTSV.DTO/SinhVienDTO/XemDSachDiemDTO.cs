using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCTSV.DTO.SinhVienDTO
{
    public class XemDSachDiemDTO
    {
        public double? GPA { get; set; }
        public int? DiemRenLuyen { get; set; }
        public string XepLoai { get; set; }

        // Thêm trường này để hiển thị lên bảng cho đẹp (client tự điền)
        public string HocKy { get; set; }
        public string NamHoc { get; set; }

        // Trường này để hứng tin nhắn lỗi từ backend (nếu có)
        public string message { get; set; }
    }
}
