using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCTSV.DTO.AdminDTO
{
    public class XemDSachDiemDTO
    {
        public string MaSV { get; set; }
        public string HocKy { get; set; }
        public string NamHoc { get; set; }

        public double GPA { get; set; } // Hệ 4.0
        public int DiemRenLuyen { get; set; }

        public string XepLoaiHocLuc { get; set; }
    }
}
