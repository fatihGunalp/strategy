using Project.DAL.Context;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.COMMON.Tools;

namespace Project.DAL.Strategy
{
    public class MyInit : CreateDatabaseIfNotExists<MyContext>
    {
        protected override void Seed(MyContext context)
        {
            Corporate c = new Corporate
            {
                CorporateName = "İSKİ",
                IconPath = "/Content/Icons/yok.png",
                SenderEmailAddress = "sbmonitor@softbreak.net",
                SenderEmailPassword = "R&tjs624",
                SenderEmailHost = "mail.softbreak.net",
                EmailSSL = false,
                SenderEmailPort = 587,
                Companies = new List<Company>
                {
                    new Company{ CompanyName="Trakya"},
                    new Company{CompanyName = "Anadolu"}
                }
            };
            



            context.Corporates.Add(c);
            context.SaveChanges();
            List<PanelDisplayCode> pa = new List<PanelDisplayCode>
            {
                new PanelDisplayCode
                {
                    Description="Giriş Voltajı",
                    PanelCode="GV"

                },
                new PanelDisplayCode
                {
                    Description="ÇıkışVoltajı",
                    PanelCode="CV"

                },
                new PanelDisplayCode
                {
                    Description="ByPasVoltajı",
                    PanelCode="BV"

                },
                new PanelDisplayCode
                {
                    Description="Giriş Güç",
                    PanelCode="GG"

                },
                new PanelDisplayCode
                {
                    Description="Çıkış Güc",
                    PanelCode="CG"

                },
                new PanelDisplayCode
                {
                    Description="ByPass Güç",
                    PanelCode="BG"

                },
                new PanelDisplayCode
                {
                    Description="Giriş Frekansı",
                    PanelCode="GF"

                },
                new PanelDisplayCode
                {
                    Description="Çıkış Frekansı",
                    PanelCode="CF"

                },
                new PanelDisplayCode
                {
                    Description="ByPass Frekansı",
                    PanelCode="BF"

                },

                new PanelDisplayCode
                {
                    Description="Giriş Yük",
                    PanelCode="GY"

                },
                new PanelDisplayCode
                {
                    Description="Çıkış Yük",
                    PanelCode="CY"

                },
                new PanelDisplayCode
                {
                    Description="ByPass Yük",
                    PanelCode="BY"

                },

                new PanelDisplayCode
                {
                    Description="Kalan Süre",
                    PanelCode="KS"

                },
                new PanelDisplayCode
                {
                    Description="Akü Durumu",
                    PanelCode="AD"

                },
                new PanelDisplayCode
                {
                    Description="Sıcaklık",
                    PanelCode="SI"

                },
                new PanelDisplayCode
                {
                    Description="Akü doluluk %",
                    PanelCode="AO"

                },
                new PanelDisplayCode
                {
                    Description="Faz sayısı",
                    PanelCode="FS"

                },
                new PanelDisplayCode
                {
                    Description="Akü gurubu",
                    PanelCode="AG"

                },
                new PanelDisplayCode
                {
                    Description="Akü voltajı",
                    PanelCode="AV"

                },
                new PanelDisplayCode
                {
                    Description="Akü akımı",
                    PanelCode="AA"

                },
                new PanelDisplayCode
                {
                    Description="Giriş akımı",
                    PanelCode="GA"

                },
                new PanelDisplayCode
                {
                    Description="Çıkış kaynağı",
                    PanelCode="CK"

                },
                new PanelDisplayCode
                {
                    Description="Çıkış faz sayısı",
                    PanelCode="CK"

                },
                new PanelDisplayCode
                {
                    Description="Çıkış akımı",
                    PanelCode="CA"

                },
                new PanelDisplayCode
                {
                    Description="BayPass faz sayısı",
                    PanelCode="BZ"

                }








            };
            context.PanelDisplayCodes.AddRange(pa);
            context.SaveChanges();


            Parameter p = new Parameter();
            p.SNMPInport = 162;
            p.SNMPOutPort = 161;
            p.TrapDisplayLastDays = 2;
            p.SbMonitorServerIP = "192.168.102.231";// Bu kurulacak makinanya dışardan ulaşım IP si
            p.SbCollectorRepeatPeriod = 1;  //Collector tekrar ssüresi dakika
            p.ScreenRefreshTime = 15; // ekran yenileme periyodu 15 saniye
            var password = "p@SSword";

            p.SNMPV3Encryption = "050"; // Paketin açılış Cihaz sayısı fielf ismi kafa karıştırmak için :)   !!!
            p.SNMPV3Encryption = Security.Cipher.Encrypt(p.SNMPV3Encryption.ToString(), password);
            context.Parameters.Add(p);
            context.SaveChanges();
            TrapReceiverControl tt = new TrapReceiverControl();
            tt.Information = "Durmus";
            context.TrapReceiverControls.Add(tt);




            TrapReceiverControl trapcon = new TrapReceiverControl();
            trapcon.Information = "Durmus";
            context.TrapReceiverControls.Add(trapcon);
            context.SaveChanges();

            //context.Companies.Add(com);

          
            // Cihazın Üretici,Satın alınan ve Bakım yaptırılan firma bilgileri dosyası Devide firm e 3 firma girişi


            List<DeviceFirm> dtrs = new List<DeviceFirm>
            {
                new DeviceFirm
                {
                    FirmName="Üretici Firma Emmerson"

                },
                new DeviceFirm
                {
                    FirmName="Satın Alınan Firma ÖzUPS"

                },
                new DeviceFirm
                {
                    FirmName="BAkımı yapan Firma Bakarlaroğlu"

                }
            };

            context.DeviceFirms.AddRange(dtrs);
            context.SaveChanges();
            // Firma kayıt sonu

           

            // ***********DependentDeviceType dosyası doldurma
            List<DependentObjectType> dtrs2 = new List<DependentObjectType>
            {
                new DependentObjectType
                {
                    Description="Server"

                },
                new DependentObjectType
                {
                    Description="Laaptop/PC"

                },
                new DependentObjectType
                {
                     Description="Telefon Santrali"

                },
                                new DependentObjectType
                {
                    Description="Router"

                },
                new DependentObjectType
                {
                    Description="Switch"

                },
                new DependentObjectType
                {
                     Description="Kamera"

                }
            };
            context.DependentObjectTypes.AddRange(dtrs2);
            context.SaveChanges();
            // ***********DependentDeviceType dosyası doldurma   SONU************

            // Bir kullanıcı Üretici,Satan ve Bakım firma alma
            
            DeviceFirm Uretici = context.DeviceFirms.Find(1);
            DeviceFirm Satici = context.DeviceFirms.Find(2);
            DeviceFirm Bakim = context.DeviceFirms.Find(3);
            //


            //**********  Location / Brand/Model  Tabloları doldurma***************************************************************

            //LocationData.csv dosyası oluşturulmalıdır. Dosya formatı aşağıdadır.
            /*
             Dosya casv formatında ve ,  ile alanları ayrılmıştır
            0	Lokasyon adı
            1	Brand
            2	Cihaz Tipi
            3	Güç (kVA) 
            4	Model
            5	Akü Grubu
            6	Kurulum Tarihi
            7	Seri No
            8	Lat
            9	Lng
            10	Telefon
            11	Url
            12	Adres
            13  Company(Region)
            Sırasıyla

            Lokasyon adı [0] Lokasyon tablosunda varmı ? yaratılmadıysa Lokasyon ve Room Yaratılır

            Bu dosya kullanılarak Lokasyonlar Location tablosuna ve her Location için 1 adet Room yaratılır.
            Hersatırdaki Brand bilgisi[1} den  okunup eğer önceden aynı isimde [1] Brand yaratılmadıysa yaratılır.Yaratıldıysa bu brand alınır
            Bu branda ait  Modelİsmi [4] ten adı alınır eğer önceden aynı isimde [4] Model yaratılmadıysa yaratılır.Yaratıldıysa bu model alınır

             */

            //TODO:UIWebListener calısacak...
            string path2 = AppDomain.CurrentDomain.BaseDirectory.Replace("Project.WEBListener", "Project.DAL");
            //string path2 = AppDomain.CurrentDomain.BaseDirectory.Replace("Project.WEBListener", "Project.DAL");
            //string path = AppDomain.CurrentDomain.;
            string filename = path2 + @"Strategy\LocationsData.csv";
            int counter = 0;
            using (StreamReader reader = new StreamReader(filename)) // TODO:Bu dosya pathinin çalışıp çalışmadığı test edilmeli
            {

                while (!reader.EndOfStream)
                {

                    // Her okunan satır için önce location + Room tanımları yapılır

                    string line = reader.ReadLine();
                    string[] values = line.Split(',');
                    string locationName = values[0];
                    string brandVariable = values[1];
                    string cihazTipi = values[2];
                    string guc = values[3];
                    string model = values[4];
                    string akuGrubu = values[5];
                    string kurulumTarihi = values[6];
                    string seriNo = values[7];
                    string lat = values[8];
                    string lng = values[9];
                    string telefon = values[10];
                    string url = values[11];
                    string adres = values[12];
                    string region= values[13];

                    // Her okunan satır için önce location + Room tanımları yapılır
                    // Eğer Location ismiyle kontrol edilip eğer varsa Lokasyon ve ilk bulunan Room getirilir

                    Room ro = new Room();
                    Location lo;
                    lo = context.Locations.FirstOrDefault(x => x.LocationName == locationName);
                    if (lo == null)
                    {
                        Company ccc = c.Companies.Where(x => x.CompanyName == values[13]).FirstOrDefault();
                        lo = new Location();
                        lo.CompanyID = ccc.ID;
                        lo.LocationName = values[0].ToString();

                        lo.Lat = values[8];
                        lo.Lng = values[9];
                        lo.Phone = values[10].ToString();
                        lo.Url = values[11].ToString();
                        lo.Address = values[12].ToString();
                        context.Locations.Add(lo);
                        context.SaveChanges();

                        ro.LocationID = lo.ID;
                        ro.RoomName = " KGK Odası";
                        ro.LocationID = lo.ID;
                        ro.Lat = lo.Lat;
                        ro.Lng = lo.Lng;
                        ro.RoomPhone = lo.Phone;
                        context.Rooms.Add(ro);
                        context.SaveChanges();
                    }
                    else
                    {
                        ro = context.Rooms.FirstOrDefault(x => x.LocationID == lo.ID);
                    }

                    // Personel kaydı
                    // Staregy aptına Personel CSV aşağıdaki sürun bilgileriyle CSV , delited atılır
                    //0   Adi
                    //1   Soyadi
                    //2   GörevKodu
                    //3   Telefon
                    //4   email
                    //5   password
                    //6   UserName
                    //7  Aktivasyon GUID

                    // Aşağıda ger görev kodu (1-Süper Admin dışında ) kalan görev kodalrında 1 er personel yaratılır

                    string path3 = AppDomain.CurrentDomain.BaseDirectory.Replace("Project.WEBListener", "Project.DAL");

                    //string path = AppDomain.CurrentDomain.;
                    
                    string filename3 = path3 + @"Strategy\Personel.csv";
                   
                    if (counter == 0)
                    {
                        counter++;
                        using (StreamReader reader3 = new StreamReader(filename3))
                        {
                            while (!reader3.EndOfStream)
                            {
                                Personnel per = new Personnel();

                                string line5 = reader3.ReadLine();
                                string[] values3 = line5.Split(',');

                                per.LocationID = lo.ID;
                                per.FirstName = values3[0];
                                per.LastName = values3[1];
                                per.InternalPhone = values3[3];
                                per.DeskPhone = values3[3];
                                per.MobilePhone = values3[3];
                                per.CompanyEmail = values3[4];
                                per.Password = values3[5];
                                per.UserName = values3[6];
                                per.ConfirmationGuid = Guid.NewGuid();

                                switch (values3[2])
                                {
                                    case "2":
                                        per.PersonnelTaskStatus = ENTITIES.Enums.PersonnelTaskStatus.KurumAdmin;
                                        break;
                                    case "3":
                                        per.PersonnelTaskStatus = ENTITIES.Enums.PersonnelTaskStatus.SubeAdmin;
                                        break;
                                    case "4":
                                        per.PersonnelTaskStatus = ENTITIES.Enums.PersonnelTaskStatus.SubeCihazSorumlusu;
                                        break;
                                    case "5":
                                        per.PersonnelTaskStatus = ENTITIES.Enums.PersonnelTaskStatus.SubeUPSSorumlusu;
                                        break;


                                    default:
                                        per.PersonnelTaskStatus = ENTITIES.Enums.PersonnelTaskStatus.SubeCihazSorumlusu;
                                        break;
                                }
                                context.Personnels.Add(per);
                                context.SaveChanges();
                            }

                        }
                        // Personel yaratma sonu.
                     
                    }

                    Personnel admin = context.Personnels.FirstOrDefault();



                    // Burada satırdaki Brand ismiyle[1] önceden açılmadıysa Device branda eklenir
                    // Açıldıysa brand olarak kayıda set edilir.

                    DeviceBrand brand;
                    brand = context.DeviceBrands.FirstOrDefault(x => x.BrandName == brandVariable);

                    if (brand == null)
                    {
                        brand = new DeviceBrand();
                        brand.BrandName = values[1];
                        context.DeviceBrands.Add(brand);
                        context.SaveChanges();
                    }

                    // Burada Branda ait Model kaydının yapılıp yapılmadığı Model ismiyle[4]  kontrol edilir.
                    // Açıldıysa set edilmiş olur
                    // açılmadıysa Brand ile ID bazında ilişki eklenir 
                    DeviceModel devmodel;
                    devmodel = context.DeviceModels.FirstOrDefault(x => x.ModelName == model);
                    if (devmodel == null)
                    {
                        devmodel = new DeviceModel();
                        devmodel.BrandID = brand.ID;
                        devmodel.ModelName = values[4];
                        context.DeviceModels.Add(devmodel);
                        context.SaveChanges();
                        //  Emerson UPS ler V2 de mesaj gönderiyor ( büyük ihtimal bilgi mesajlarını)
                        //  V2 SnmpSharpNet kütüphanesinde vblist ( list) gelen bilgisininin yanında gelen Hata kodu oluyor
                        // vblistteki hangi OID den hata kodu geldiğini araştırıp MIB den 1.3.6.1.4.1.21111.1.1.12.999
                        // altında olduğunu gördük o yüzden bu alana Emerson hata gönderme OID si giriliyor
                        if (brand.BrandName == "Emerson")
                        {
                            devmodel.V2TrapOID = "1.3.6.1.4.1.21111.1.1.12.999.0";
                        }
                    }
                    // Burada Device kaydı yapılır






                    Device dev = new Device();
                    dev.MaintenanceFirmID = Bakim.ID;
                    dev.ProductFirmID = Uretici.ID;
                    dev.PurchaseFirmID = Satici.ID;
                    dev.PersonnelID = admin.ID;
                    dev.RoomID = ro.ID;
                    dev.SerialNumber = values[7];
                    dev.ModelID = devmodel.ID;

                    dev.IPNo = "0";
                    dev.CommunityName = "public";
                    dev.DeviceStatus = ENTITIES.Enums.DeviceStatus.CalisiyorNormal;
                    dev.ConnectionStatus = ENTITIES.Enums.ConnectionStatus.Ok;
                    dev.TransmissionProtocol = ENTITIES.Enums.TransmissionProtocol.SNMP;
                    context.Devices.Add(dev);






                    //Burada emerson Brandındaki tüm modellere Trap kodları ModelTrapCode dosyasına ve Model OID kodları ModelSpecdosyasına ekleniyor

                    // TODO ModelTrapCode dosyasının DeviceModel ile ilişkilendirdekten sonra aşağıdaki remarkalr açılıp dene

                    if (brand.BrandName == "Emerson")
                    {
                        // Emerson a ait Trap kodları ekleniyor
                        string filename2 = path2 + @"Strategy\EmersonTrapKodlariV2.csv";

                        using (StreamReader reader2 = new StreamReader(filename2))
                        {

                            while (!reader2.EndOfStream)
                            {
                                string line2 = reader2.ReadLine();
                                string[] values2 = line2.Split(',');

                                string trapCode = values2[2];
                                ModelTrapCode motrco;


                                motrco = context.ModelTrapCodes.FirstOrDefault(x => x.DeviceModelID == devmodel.ID && x.TrapNo == trapCode);
                                if (motrco == null) // Aynı Brand ın Modelinne ait TrapNo girilmemiş 

                                {
                                    motrco = new ModelTrapCode();
                                    motrco.DeviceModelID = devmodel.ID;
                                    motrco.TrapNo = values2[2]; ;
                                    motrco.OriginalExplanation = values2[1];
                                    motrco.TurkishExplanation = values2[0];
                                    switch (values2[3])
                                    {
                                        case "K":
                                            motrco.TrapType = ENTITIES.Enums.TrapType.KritikHata;
                                            break;
                                        case "U":
                                            motrco.TrapType = ENTITIES.Enums.TrapType.Uyari;
                                            break;
                                        case "B":
                                            motrco.TrapType = ENTITIES.Enums.TrapType.Bilgi;
                                            break;

                                        default:
                                            break;
                                    }


                                    string xx = values2[3];
                                    switch (xx)
                                    {
                                        case "K":
                                            motrco.EmailSend = true;
                                            break;

                                    }
                                    switch (values2[4])
                                    {
                                        case "1":
                                            motrco.DeviceStatusUpdate = ENTITIES.Enums.DeviceStatus.CalisiyorNormal;
                                            break;

                                        case "2":
                                            motrco.DeviceStatusUpdate = ENTITIES.Enums.DeviceStatus.KritikDurum;
                                            break;
                                        case "3":
                                            motrco.DeviceStatusUpdate = ENTITIES.Enums.DeviceStatus.UyariVermis;
                                            break;
                                        case "4":
                                            motrco.DeviceStatusUpdate = ENTITIES.Enums.DeviceStatus.ByPass;
                                            break;

                                        default:
                                            motrco.DeviceStatusUpdate = ENTITIES.Enums.DeviceStatus.CalisiyorNormal;
                                            break;
                                    }
                                    context.ModelTrapCodes.Add(motrco);
                                    context.SaveChanges();

                                }


                            }

                        }
                        // Emersona ait OID kodları ekleniyor
                        filename2 = path2 + @"Strategy\EmersonModelOIDV2.csv";
                        using (StreamReader reader2 = new StreamReader(filename2))
                        {

                            string firstline = reader2.ReadLine();//İlk satırda Başlıklar okunup pass geçiliyor.
                            while (!reader2.EndOfStream)
                            {
                                string line2 = reader2.ReadLine();
                                string[] values2 = line2.Split(',');

                                string OIDCode = values2[3];
                                ModelSpec motrco;



                                motrco = context.ModelSpecs.FirstOrDefault(x => x.DeviceModelID == devmodel.ID && x.OID == OIDCode);
                                if (motrco == null) // Aynı Brand ın Modelinne ait OID girilmemiş 

                                {
                                    motrco = new ModelSpec();
                                    motrco.DeviceModelID = devmodel.ID;
                                    motrco.OID = values2[3];
                                    motrco.ValueType = ENTITIES.Enums.ModelSpecValueType.OID;
                                    motrco.TurkishExplanation = values2[1];
                                    motrco.OriginalExplanation = values2[0];
                                    motrco.CollectorUpdate = true;
                                    motrco.Min = 0;
                                    motrco.Min = 0;
                                    motrco.Unit = values2[4];
                                    motrco.Description = values2[2];
                                    if (values2[10] !="0")
                                    {
                                        motrco.PanelDisplayCodeID = Convert.ToInt32(values2[10]);
                                    }
                                    
                                    context.ModelSpecs.Add(motrco);
                                    context.SaveChanges();

                                }


                            }

                        }


                        foreach (ModelSpec item in context.ModelSpecs.Where(x => x.DeviceModelID == devmodel.ID))
                        {
                            DeviceSpec ds = new DeviceSpec();
                            ds.ModelSpecID = item.ID;
                            ds.DeviceID = dev.ID;
                            context.DeviceSpecs.Add(ds);


                        }
                        //context.SaveChanges();

                        // Bu iki satır Emerson UPS in standart test için alınan IP si giriliyor sonra silinmeli
                        // Daha iyisi Excele proje başında bilinen IP noları girilip Device insertte Excel sütunundan okunmalı
                        var entity = context.Devices.Find(dev.ID);

                        entity.IPNo = "192.168.0.29";

                        // Burada UPS ten belsenen Cihazlar DeviceDependenObject dosyasına ekleniyor
                        DependentObject depobj = new DependentObject();
                        List<DependentObjectType> deli = new List<DependentObjectType>();
                        deli = context.DependentObjectTypes.ToList();
                        Personnel pero = context.Personnels.FirstOrDefault(x => x.PersonnelTaskStatus == ENTITIES.Enums.PersonnelTaskStatus.SubeCihazSorumlusu);
                        foreach (var item in deli)
                        {
                            DependentObject dp = new DependentObject();
                            dp.DependentObjectTypeID = item.ID;
                            dp.PersonnelID = pero.ID;
                            dp.DeviceID = dev.ID;
                            context.DependentObjects.Add(dp);
                            context.SaveChanges();

                        }


                    }


                }
            }
            // Dependen device tanımlama
            List<DependentObjectType> depo = new List<DependentObjectType>();


            //**************Sonu

            //************************ Excelden Tabloları doldurma SON **********************************************

            //Location l = new Location
            //{

            //    LocationName = "Kadıköy Şube",
            //    Lat = 40.98918433278175,
            //    Lng = 29.020521868677765,
            //    Phone = "2163450304",
            //    Url = "https://www.iski.istanbul/web/tr-TR/anadolu-yakasi/kadikoy-sube-mudurlugu",
            //    Address = "Caferağa Mahallesi Mühürdar Caddesi, Damga Sk. No: 98, 34734 Kadıköy/İstanbul"
            //};
            //c.Locations.Add(l);

            //Room r = new Room
            //{

            //    RoomName = "Merkez Bina 3 Oda 56",
            //    Lat = 40.98918433278175,
            //    Lng = 29.020521868677765,
            //};
            //l.Rooms.Add(r);

            //DeviceBrand db = new DeviceBrand
            //{
            //    BrandName = "Emerson",

            //};

            //context.DeviceBrands.Add(db);

            //DeviceModel dm = new DeviceModel
            //{

            //    ModelName = "Super x 40KVA"
            //};
            //db.Models.Add(dm);

            //Device d = new Device
            //{

            //    SerialNumber = "Abc123",
            //    IPNo = "192.168.102.230",
            //    CommunityName = "public",
            //    DeviceStatus = ENTITIES.Enums.DeviceStatus.CalisiyorNormal,
            //    ConnectionStatus = ENTITIES.Enums.ConnectionStatus.Ok,
            //    TransmissionProtocol = ENTITIES.Enums.TransmissionProtocol.SNMP,



            //};

            //dm.Devices.Add(d);

            //context.Devices.Add(d);

            //r.Devices.Add(d);

            //ModelTrapCode mtc = new ModelTrapCode
            //{

            //    TrapType = ENTITIES.Enums.TrapType.KritikHata,
            //    TurkishExplanation = "Şebeke akımı kesildi",
            //    OriginalExplanation = "AC Failure",
            //    TrapNo = "1",



            //};

            //ModelTrapCode mtc2 = new ModelTrapCode
            //{

            //    TrapType = ENTITIES.Enums.TrapType.Bilgi,
            //    TrapNo = "100",
            //    TurkishExplanation = "Şebeke akımı normal",
            //    OriginalExplanation = "AC Normal",
            //};

            //ModelTrapCode mtc3 = new ModelTrapCode
            //{

            //    TrapType = ENTITIES.Enums.TrapType.Bilgi,
            //    TrapNo = "114",
            //    TurkishExplanation = "Çıkıs açık",
            //    OriginalExplanation = "Output On"
            //};

            //context.ModelTrapCodes.Add(mtc);
            //context.ModelTrapCodes.Add(mtc2);
            //context.ModelTrapCodes.Add(mtc3);

            //dm.ModelTraps.Add(mtc);
            //dm.ModelTraps.Add(mtc2);
            //dm.ModelTraps.Add(mtc3);

            //context.SaveChanges();

            //List<DeviceTrapRecord> dtrs = new List<DeviceTrapRecord>
            //{
            //    new DeviceTrapRecord
            //    {
            //        ModelTrapCodeID = mtc.ID,
            //        DeviceID = d.ID
            //    },
            //    new DeviceTrapRecord
            //    {
            //         ModelTrapCodeID = mtc2.ID,
            //        DeviceID = d.ID
            //    },
            //    new DeviceTrapRecord
            //    {
            //         ModelTrapCodeID = mtc3.ID,
            //        DeviceID = d.ID
            //    }
            //};

            //context.DeviceTrapRecords.AddRange(dtrs);
            //context.SaveChanges();

        }
    }
}
