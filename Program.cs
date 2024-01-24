using System;
using System.Net;
using System.Xml;
using System.Linq;

class AnaMenu
{
    static void Main()
    {
        
        while (true)
        {
            Console.WriteLine("*************************************");
            Console.WriteLine($"AFK HALK KÜTÜPHANESİ ARAYÜZÜ'NE HOŞ GELDİNİZ.");
            Console.WriteLine("******************");              //ANA MENÜDE KULLANICIDAN YAPMAK İSTEDİĞİ İŞLEMİ SEÇMESİNİ İSTİYOR
            Console.WriteLine("0)Çıkış Yap");
            Console.WriteLine("1)Kitap Ekle");
            Console.WriteLine("2)Kitap Listesini Görüntüle/Ödünç Al/İade Et");
            Console.WriteLine("3)Arama Çubuğunu Kullan");
            Console.WriteLine("\nYapmak istediğiniz işlemi seçiniz:");
            int secim = Convert.ToInt32(Console.ReadLine());

            if (secim == 0)
            {
                break;
            }
            
            if (secim == 1)
            {
                KitapBilgiAlma.KitapEkle();
            }
            else if (secim == 2)
            {
                KitapBilgiAlma.KitaplarıGör();
            }
            
            else if (secim == 3)
            {
                KitapBilgiAlma.AramaMotoru();
            }

            else
            {
                Console.WriteLine("\nMevcut işlemlerden birini seçiniz!");
                continue;
            }
        }
    }
}
class KitapBilgileri 
{
    public string Ad { get; set; }
    public string Yil { get; set; }                 //KİTAP BİLGİLERİNİN AYARLANMASI VE SONRA ÇAĞRILMASI AŞAMASI
    public string yazar { get; set; }
    public string barkod { get; set; }
    public string kategori { get; set; }
    public int kopyaSayisi { get; set; }
    public int oduncalinan { get; set; }
}
class KitapBilgiAlma
{
    static List<KitapBilgileri> Kitaplar = new List<KitapBilgileri>();
    public static void KitapEkle()
    {
        
        Console.WriteLine("\nBilgileri giriniz");

        Console.WriteLine("Kitap adı:");
        string ad = Console.ReadLine();                     //LİSTEYE EKLENECEK KİTABIN BİLGİLERİ ALINIYOR VE EKRANA YAZDIRILIYOR

        Console.WriteLine("Basım yılı:");
        string Yil = Console.ReadLine();

        Console.WriteLine("Yazarı:");
        string yazar = Console.ReadLine();

        Console.WriteLine("Kategori/ler:");
        string kategori = Console.ReadLine();

        Console.WriteLine("Barkod:");
        string barkod = Console.ReadLine();
        
        Console.WriteLine("Eldeki Kopya Sayısı:");
        int kopya = Convert.ToInt32(Console.ReadLine());
        
        Console.WriteLine("Ödünç alınan kopya sayısı:");
        int odunc = Convert.ToInt32(Console.ReadLine());

        KitapBilgileri yeniKitap = new KitapBilgileri { Ad = ad, Yil = Yil, yazar = yazar, kategori = kategori, barkod = barkod , kopyaSayisi = kopya, oduncalinan = odunc};
        Kitaplar.Add(yeniKitap);
        
        Console.WriteLine("\n*****************");
        Console.WriteLine("\nKitap başarıyla eklendi.");
        Console.WriteLine("\nKitap Bilgileri:");
       
        
        Console.WriteLine($"Ad: {ad}, Basım yılı: {Yil}, Yazar: {yazar}, Kategori/ler: {kategori}, Barkod: {barkod}, Kopya sayısı: {kopya}, Ödünç alınan: {odunc}");
        
        
        Console.WriteLine("***************");

       
    }

    
    public static void KitaplarıGör()
    {
        int booknumber = 1;
        Console.WriteLine("**********************");
        Console.WriteLine($"Kayıtlı {Kitaplar.Count} kitap var.");          //TOPLAM KİTAP SAYISI YAZILIYOR VE KİTAPLAR LİSTELENİYOR
        Console.WriteLine("Kütüphaneye kayıtlı kitaplar:");
        foreach (KitapBilgileri bilgi in Kitaplar)
        {
            Console.WriteLine($"{booknumber})\nAd: {bilgi.Ad}\nBasım Yılı: {bilgi.Yil}\nYazar: {bilgi.yazar}\nKategori/ler: {bilgi.kategori}\nBarkod: {bilgi.barkod}\nEldeki kopya sayısı: {bilgi.kopyaSayisi}\nÖdünç alınan: {bilgi.oduncalinan}");
            booknumber++;
        }
        Console.WriteLine("**********************");
        Console.WriteLine("0)Ana menüye dön");
        Console.WriteLine("\nSeciminiz:");                          //İŞLEM YAPILACAK KİTAP SEÇİLİYOR
        int sayfasecim = Convert.ToInt32(Console.ReadLine());

        if (sayfasecim == 0)
        {
            return;
        }
        else
        {
            if (sayfasecim < Kitaplar.Count+1)
            {
                KitapBilgileri secilenKitap = Kitaplar[sayfasecim-1];
                Console.WriteLine("***************************");
                Console.WriteLine($"Seçilen kitabın adı: {secilenKitap.Ad}");
                Console.WriteLine($"Seçilen kitabın basım yılı: {secilenKitap.Yil}");
                Console.WriteLine($"Seçilen kitabın yazarı: {secilenKitap.yazar}");
                Console.WriteLine($"Seçilen kitabın kategori/leri: {secilenKitap.kategori}");
                Console.WriteLine($"Seçilen kitabın barkodu: {secilenKitap.barkod}");
                Console.WriteLine($"Seçilen kitabın eldeki kopya sayısı: {secilenKitap.kopyaSayisi}");
                Console.WriteLine($"Seçilen kitabın ödünç alınan kopya sayısı: {secilenKitap.oduncalinan}");
                Console.WriteLine("*******************************************");                               //KİTABIN BİLGİLERİ YAZDIRILIYOR VE YAPILACAK İŞLEM SORULUYOR
                Console.WriteLine("0) Ana menüye dön");
                Console.WriteLine("1) Kitap listesini gör");
                Console.WriteLine("2) Seçilen kitaptan 1 adet ödünç al");
                Console.WriteLine("3) Seçilen kitabı iade et");
                Console.WriteLine("4) Seçilen kitabın 1 kopyasını sisteme kaydet");
                Console.WriteLine("5) Seçilen kitabın 1 kopyasını sistemden sil");
                Console.WriteLine("6) Seçilen kitabı sistemden sil");
                Console.WriteLine("Yapmak istediğiniz işlem:");
                int karar = Convert.ToInt32(Console.ReadLine());

                if (karar == 0)
                {
                    return;
                }
                else if (karar == 1)
                {
                    KitaplarıGör();
                }
                
                else if (karar == 2)
                {
                    if (secilenKitap.kopyaSayisi > 0)
                    {
                        secilenKitap.kopyaSayisi--;
                        secilenKitap.oduncalinan++;
                        Console.WriteLine("*****************************************************************************");
                        Console.WriteLine($"Seçilen kitaptan 1 adet ödünç alındı. Elde {secilenKitap.kopyaSayisi} kopya kaldı.");
                        KitaplarıGör();
                    }
                    else
                    {
                        Console.WriteLine("*********************************************************");
                        Console.WriteLine($"Seçilen kitabın elimizde kopyası mevcut değil. Ödünç alma başarısız oldu.");
                        KitaplarıGör();
                    }
                }
                
                else if (karar == 3)
                {
                    if (secilenKitap.oduncalinan > 0)
                    {
                        secilenKitap.kopyaSayisi++;
                        secilenKitap.oduncalinan--;
                        Console.WriteLine("***************************************************************");
                        Console.WriteLine($"Seçilen kitabın bir kopyası iade edildi. Elde {secilenKitap.kopyaSayisi} kopya kaldı.");
                        KitaplarıGör();
                    }
                    else
                    {
                        Console.WriteLine("******************************************************************");
                        Console.WriteLine("Seçilen kitabın hiçbir kopyası ödünç verilmemiş. İade etme başarısız oldu.");
                        KitaplarıGör();
                    }
                }
                
                else if (karar == 4)
                {
                    secilenKitap.kopyaSayisi++;
                    Console.WriteLine("******************************************************************************");
                    Console.WriteLine($"Seçilen kitaba yeni bir kopya eklendi. Elde {secilenKitap.kopyaSayisi} kopya kaldı.");
                    KitaplarıGör();
                }
                
                else if (karar == 5)
                {
                    secilenKitap.kopyaSayisi--;
                    if (secilenKitap.kopyaSayisi > 0)
                    {
                        Console.WriteLine("*************************************************************************");
                        Console.WriteLine($"Kitabın bir kopyası sistemden silindi. Elde {secilenKitap.kopyaSayisi} kopya kaldı.");
                        KitaplarıGör();
                    }
                    else if (secilenKitap.kopyaSayisi == 0)
                    {
                        Kitaplar.Remove(secilenKitap);
                        Console.WriteLine("*************************************************************************");
                        Console.WriteLine("Kitabın son kopyası silindi. Kitap sistemden başarıyla silindi.");
                        KitaplarıGör();
                    }
                }
                
                else if (karar == 6)
                {
                    Kitaplar.Remove(secilenKitap);
                    Console.WriteLine("*************************************************************************");
                    Console.WriteLine("Kitap sistemden başarıyla silindi.");
                    KitaplarıGör();
                    
                }

                else
                {
                    Console.WriteLine("*************************************************************************");
                    Console.WriteLine("Yanlış değer girdiniz. Ana menüye dönülüyor.");                                  //YANLIŞ DEĞER GİRİLİNCE HATA İŞLENİYOR
                }

            }

        }
        
    }

    public static void AramaMotoru()
    {
        string arama;
        
        Console.WriteLine("**************************************");
        Console.WriteLine("Hangi arama türünü tercih edersiniz?");
        Console.WriteLine("0)Ana Menüye Dön");
        Console.WriteLine("1) Kitap ismine göre arama");
        Console.WriteLine("2) Kitap yazarına göre arama");                  //ARAMA TERCİHİ SORULUP DURUMA GÖRE KARŞILAŞTIRMALAR YAPILIYOR

        int tercih = Convert.ToInt32(Console.ReadLine());

        if (tercih == 0)
        {
            
        }
        
        else if (tercih == 1)
        {
            string kitapadı;
            Console.WriteLine("**************************************************");
            Console.WriteLine("Aramak istediğiniz kitabın adını yazınız.(Büyük ve küçük harfe duyarlı)");
            kitapadı = Console.ReadLine();
            var FiltrelenmisKitaplar = new List<KitapBilgileri>();
            FiltrelenmisKitaplar = Kitaplar.Where(KitapBilgileri => KitapBilgileri.Ad.Contains(kitapadı)).ToList();
            
            Console.WriteLine($"Yazdığınız isim ile uyuşan {FiltrelenmisKitaplar.Count} kitap var. Uyuşan kitaplar: \n");
            foreach (var book in FiltrelenmisKitaplar)
            {
                int i = 1;
                Console.WriteLine($"\n{i})\n Ad: {book.Ad},\n Basım yılı: {book.Yil},\n Yazar: {book.yazar},\n Kategori/ler: {book.kategori}\n Barkod: {book.barkod}\n Eldeki kopya sayısı: {book.kopyaSayisi}\n Ödünç alınan: {book.oduncalinan} ");
                i++;
            }
            AramaMotoru();

        }
        
        else if (tercih == 2)
        {
            string yazaradı;
            Console.WriteLine("********************************************");
            Console.WriteLine("Aramak istediğiniz kitabın yazarını yazınız.(Büyük ve küçük harfe duyarlı)");
            yazaradı = Console.ReadLine();
            var FiltrelenmisKitaplar = new List<KitapBilgileri>();
            FiltrelenmisKitaplar = Kitaplar.Where(KitapBilgileri => KitapBilgileri.yazar.Contains(yazaradı)).ToList();
            Console.WriteLine($"Yazdığınız isim ile uyuşan {FiltrelenmisKitaplar.Count} kitap var. Uyuşan kitaplar: \n");
            foreach (var book in FiltrelenmisKitaplar)
            {
                int i = 1;
                Console.WriteLine($"\n{i})\n Ad: {book.Ad},\n Basım yılı: {book.Yil},\n Yazar: {book.yazar},\n Kategori/ler: {book.kategori}\n Barkod: {book.barkod}\n Eldeki kopya sayısı: {book.kopyaSayisi}\n Ödünç alınan: {book.oduncalinan} ");
                i++;
            }
            AramaMotoru();
        }

        else
        {
            Console.WriteLine("Hatalı giriş yaptınız. Tekrar deneyin.");
            AramaMotoru();
        }
    }

    
}