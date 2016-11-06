using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Server
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        List<eCongTrinh> GetAllDataFromCongTrinh();

        [OperationContract]
        List<eNhanVien> GetAllDataFromNhanVien();

        [OperationContract]
        List<ePhongBan>GetAllDataFromPhongBan();

        [OperationContract]
        List<ePhanCong> GetAllDataFromPhanCong();

        [OperationContract]
        int insertCt(CongTrinh ct);

        [OperationContract]
        int insertNv(NhanVien nv);

        [OperationContract]
        int insertPhongBan(PhongBan pb);

        [OperationContract]
        int insertPc(ePhanCong pc);

        [OperationContract]
        int remove1datafromCongTrinh(CongTrinh ct);

        [OperationContract]
        int remove1datafromNhanVien(NhanVien nv);

        [OperationContract]
        int remove1datafromPhongBan(PhongBan pb);

        [OperationContract]
        int remove1datafromPhanCong(ePhanCong pc);

        [OperationContract]
        List<eCongTrinh> seach1CongtrinhbymaCT(string mact);

        [OperationContract]
        List<eNhanVien> seach1Nhanvienbymanv(string manv);

        [OperationContract]
        int change1Nhanvien(NhanVien nv);

        [OperationContract]
        int change1CongTrinh(CongTrinh ct);

        [OperationContract]
        int change1PhongBan(PhongBan pb);

        [OperationContract]
        int change1PhanCong(ePhanCong pc);

        [OperationContract]
        string GetMaPBfromMaNV(string manv);

        [OperationContract]
        List<eNhanVien> getMaNVfromMAPB(string mapb);
        

        // TODO: Add your service operations here
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "Server.ContractType".
        [DataContract]
        public class eNhanVien
        {
            [DataMember]
            public string MANV { get; set; }
            [DataMember]
            public string HOTEN { get; set; }
            [DataMember]
            public DateTime NGAYSINH { get; set; }
            [DataMember]
            public string PHAI { get; set; }
            [DataMember]
            public string DIACHI { get; set; }
            [DataMember]
            public string MAPB { get; set; }
        }
        public class ePhanCong
        {
            [DataMember]
            public string MAPB { get; set; }
            [DataMember]
            public string MACT { get; set; }
            [DataMember]
            public string MANV { get; set; }
            [DataMember]
            public string SLNGAYCONG { get; set; }
        }
        public class ePhongBan
        {
            [DataMember]
            public string MAPB { get; set; }
            [DataMember]
            public string TENPB { get; set; }

        }
        public class eCongTrinh
        {
            [DataMember]
            public string MACT { get; set; }
            [DataMember]
            public string TENCT { get; set; }
            [DataMember]
            public string DIADIEM { get; set; }
            [DataMember]
            public DateTime NGAYCAPGP { get; set; }
            [DataMember]
            public DateTime NGAYKC { get; set; }
            [DataMember]
            public DateTime NGAYHT { get; set; }
 
        }
}
