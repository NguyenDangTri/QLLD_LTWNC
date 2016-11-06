using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Text.RegularExpressions;

namespace Server
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service : IService
    {
        CSDLDataContext db = new CSDLDataContext();


        public List<eCongTrinh> GetAllDataFromCongTrinh()
        {
            List<eCongTrinh> ct = new List<eCongTrinh>();
            var rct = (from c in db.CongTrinhs
                       select new eCongTrinh
                       {
                           MACT = c.MACT,
                           TENCT = c.TENCT,
                           DIADIEM = c.DIADIEM,
                           NGAYCAPGP = (DateTime)c.NGAYCAPGP,
                           NGAYKC = (DateTime)c.NGAYKC,
                           NGAYHT = (DateTime)c.NGAYKC,
                       });
            ct = rct.ToList();
            return ct;
        }

        public List<eNhanVien> GetAllDataFromNhanVien()
        {
            List<eNhanVien> nv = new List<eNhanVien>();
            var rnv = (from n in db.NhanViens
                       select new eNhanVien
                       {
                           MANV = n.MANV,
                           HOTEN = n.HOTEN,
                           NGAYSINH = (DateTime)n.NGAYSINH,
                           PHAI = n.PHAI,
                           DIACHI = n.DIACHI,
                           MAPB = n.MAPB,

                       });
            nv = rnv.ToList();

            return nv;
        }
        public List<ePhongBan> GetAllDataFromPhongBan()
        {
            List<ePhongBan> pb = new List<ePhongBan>();
            var rpb = (from p in db.PhongBans
                       select new ePhongBan
                       {
                           MAPB = p.MAPB,
                           TENPB = p.TENPB,
                       });
            pb = rpb.ToList();
            return pb;
        }
        public List<ePhanCong> GetAllDataFromPhanCong()
        {
            List<ePhanCong> pc = new List<ePhanCong>();
            var rpc = (from a in db.PhanCongs
                       select new ePhanCong
                       {
                           MAPB = a.MAPB,
                           MACT = a.MACT,
                           MANV = a.MANV,
                           SLNGAYCONG = a.SLNGAYCONG,
                       });
            pc = rpc.ToList();
            return pc;
        }




        public int remove1datafromCongTrinh(CongTrinh ct)
        {
            var tmp = db.CongTrinhs.Where(x => x.MACT == ct.MACT).FirstOrDefault();
            if (tmp == null)
                return 0;
            db.CongTrinhs.DeleteOnSubmit(tmp);
            db.SubmitChanges();
            return 1;
        }

        public int remove1datafromNhanVien(NhanVien nv)
        {
            var tmp = db.NhanViens.Where(x => x.MANV == nv.MANV).FirstOrDefault();
            if (tmp == null)
                return 0;
            db.NhanViens.DeleteOnSubmit(tmp);
            db.SubmitChanges();
            return 1;
        }

        public int remove1datafromPhongBan(PhongBan pb)
        {
            var tmp = db.PhongBans.Where(x => x.MAPB == pb.MAPB).FirstOrDefault();
            if (tmp == null)
                return 0;
            db.PhongBans.DeleteOnSubmit(tmp);
            db.SubmitChanges();
            return 1;
        }

        public int remove1datafromPhanCong(ePhanCong pc)
        {
            var tmp = db.PhanCongs.Where(x => (x.MANV == pc.MANV && x.MAPB == pc.MAPB && x.MACT == pc.MACT)).FirstOrDefault();
            if (tmp == null)
                return 0;
            db.PhanCongs.DeleteOnSubmit(tmp);
            db.SubmitChanges();
            return 1;
            
        }




        public int insertCt(CongTrinh ct)
        {
            var tmp = db.CongTrinhs.Where(x => x.MACT == ct.MACT).FirstOrDefault();
            if (tmp != null)
                return 0;
            db.CongTrinhs.InsertOnSubmit(ct);
            db.SubmitChanges();
            return 1; ;
        }

        public int insertNv(NhanVien nv)
        {
            var tmp = db.NhanViens.Where(x => x.MANV == nv.MANV).FirstOrDefault();
            if (tmp != null)
                return 0;
            db.NhanViens.InsertOnSubmit(nv);
            db.SubmitChanges();
            return 1; ;
        }

        public int insertPhongBan(PhongBan pb)
        {
            var tmp = db.PhongBans.Where(x => x.MAPB == pb.MAPB).FirstOrDefault();
            if (tmp != null)
                return 0;
            db.PhongBans.InsertOnSubmit(pb);
            db.SubmitChanges();
            return 1; 
        }

        public int insertPc(ePhanCong pc)
        {
            List<ePhanCong> p = new List<ePhanCong>();
            var rpc = (from a in db.PhanCongs
                       select new ePhanCong
                       {
                           MAPB = a.MAPB,
                           MACT = a.MACT,
                           MANV = a.MANV,
                           SLNGAYCONG = a.SLNGAYCONG,
                       });
            p = rpc.ToList();
            foreach(ePhanCong e in p)
            {
                if (e.MANV == pc.MANV && e.MAPB == pc.MAPB && e.MACT == pc.MACT)
                    return 0;
            }
            PhanCong b = new PhanCong();
            b.MACT = pc.MACT;
            b.MANV = pc.MANV;
            b.MAPB = pc.MAPB;
            b.SLNGAYCONG = pc.SLNGAYCONG;
            db.PhanCongs.InsertOnSubmit(b);
            db.SubmitChanges();
            return 1;
        }


        public List<eCongTrinh> seach1CongtrinhbymaCT(string mact)
        {
            int i = mact.Length;
            List<eCongTrinh> ct = new List<eCongTrinh>();
            var rct = (from c in db.CongTrinhs
                       where c.MACT.Substring(0, i) == mact
                       select new eCongTrinh
                       {
                           MACT = c.MACT,
                           TENCT = c.TENCT,
                           DIADIEM = c.DIADIEM,
                           NGAYCAPGP = (DateTime)c.NGAYCAPGP,
                           NGAYKC = (DateTime)c.NGAYKC,
                           NGAYHT = (DateTime)c.NGAYKC,
                       });
            ct = rct.ToList();

            return ct;
        }

        public List<eNhanVien> seach1Nhanvienbymanv(string manv)
        {
            int i = manv.Length;
            List<eNhanVien> nv = new List<eNhanVien>();
            var rnv = (from n in db.NhanViens
                       where n.MANV.Substring(0, i) == manv
                       select new eNhanVien
                       {
                           MANV = n.MANV,
                           HOTEN = n.HOTEN,
                           NGAYSINH = (DateTime)n.NGAYSINH,
                           PHAI = n.PHAI,
                           DIACHI = n.DIACHI,
                           MAPB = n.MAPB,

                       });
            nv = rnv.ToList();

            return nv;
        }





        public int change1Nhanvien(NhanVien nv)
        {
            var tmp = db.NhanViens.Where(x => x.MANV == nv.MANV).FirstOrDefault();
            if (tmp == null)
                return 0;
            db.NhanViens.DeleteOnSubmit(tmp);
            db.NhanViens.InsertOnSubmit(nv);
            db.SubmitChanges();
            return 1;
        }

        public int change1CongTrinh(CongTrinh ct)
        {
            var tmp = db.CongTrinhs.Where(x => x.MACT == ct.MACT).FirstOrDefault();
            if (tmp == null)
                return 0;
            db.CongTrinhs.DeleteOnSubmit(tmp);
            db.CongTrinhs.InsertOnSubmit(ct);
            db.SubmitChanges();
            return 1;
        }

        public int change1PhongBan(PhongBan pb)
        {
            var tmp = db.PhongBans.Where(x => x.MAPB == pb.MAPB).FirstOrDefault();
            if (tmp == null)
                return 0;
            db.PhongBans.DeleteOnSubmit(tmp);
            db.PhongBans.InsertOnSubmit(pb);
            db.SubmitChanges();
            return 1; 
        }

        public int change1PhanCong(ePhanCong pc)
        {
            var tmp = db.PhanCongs.Where(x => (x.MANV == pc.MANV && x.MAPB == pc.MAPB && x.MACT == pc.MACT)).FirstOrDefault();
            if (tmp == null)
                return 0;
            db.PhanCongs.DeleteOnSubmit(tmp);                  
            PhanCong b = new PhanCong();
            b.MACT = pc.MACT;
            b.MANV = pc.MANV;
            b.MAPB = pc.MAPB;
            b.SLNGAYCONG = pc.SLNGAYCONG;
            db.PhanCongs.InsertOnSubmit(b);
            db.SubmitChanges();
            return 1;
        }


        public string GetMaPBfromMaNV(string manv)
        {
            string s="";
            var tmp = db.NhanViens.Where(x => x.MANV == manv).FirstOrDefault();
            if(tmp==null)
                return null;
            s = tmp.MAPB;
           
            return s;
        }

        public List<eNhanVien> getMaNVfromMAPB(string mapb)
        {
            List<eNhanVien> nv = new List<eNhanVien>();
            var rnv = (from n in db.NhanViens where n.MAPB==mapb
                       select new eNhanVien
                       {
                           MANV = n.MANV,
                           HOTEN = n.HOTEN,
                           NGAYSINH = (DateTime)n.NGAYSINH,
                           PHAI = n.PHAI,
                           DIACHI = n.DIACHI,
                           MAPB = n.MAPB,

                       });
            nv = rnv.ToList();
            if (nv.Count == 0)
                return null; 
            return nv;
        }
    }
}
