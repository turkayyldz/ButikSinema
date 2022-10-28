using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ButikSinema
{
    class Sinema
    {
        public string FilmAdi { get; set; }
        public int Kapasite { get; }
        public float TamBiletFiyati { get; }
        public float YarimBiletFiyati { get; }
        public int ToplamTamBiletAdedi { get; private set; }
        public int ToplamYarimBiletAdedi { get; private set; }
        public float Ciro
        {
            get
            {
                return this.ToplamTamBiletAdedi * this.TamBiletFiyati + this.ToplamYarimBiletAdedi * this.YarimBiletFiyati;
            }
        }
        public Sinema(string filmAdi, int kapasite, float tamBiletFiyati, float yarimBiletFiyati)
        {
            this.FilmAdi = filmAdi;
            this.Kapasite = kapasite;
            this.YarimBiletFiyati = yarimBiletFiyati;
            this.TamBiletFiyati = tamBiletFiyati;
        }
        public void BiletSatis(int tamBiletAdedi, int yarimBiletAdedi)
        {
            if (BosKoltukAdediGetir() >= tamBiletAdedi + yarimBiletAdedi)
            {
                this.ToplamTamBiletAdedi += tamBiletAdedi;
                this.ToplamYarimBiletAdedi += yarimBiletAdedi;
                CiroHesapla();
                Console.WriteLine("İşlem gerçekleştirildi.");
            }
            else
            {
                Console.WriteLine("Yeterli boş koltuk yok. Satılabilecek bilet adedi " + BosKoltukAdediGetir());
            }
        }
        public void BiletIadesi(int tamBiletAdedi, int yarimBiletAdedi) 
        {
            if (tamBiletAdedi <= this.ToplamTamBiletAdedi && yarimBiletAdedi <= this.ToplamYarimBiletAdedi)
            {
                this.ToplamTamBiletAdedi -= tamBiletAdedi;
                this.ToplamYarimBiletAdedi -= yarimBiletAdedi;
                CiroHesapla();
                Console.WriteLine("İşlem gerçekleştirildi.");
            }
            else
            {
                Console.WriteLine("İade edilebilecek bilet miktarını aştınız.");
            }
        }
        private void CiroHesapla()
        {
            // this.Ciro = this.ToplamTamBiletAdedi * this.TamBiletFiyati + this.ToplamYarimBiletAdedi * this.YarimBiletFiyati;
        }
        public int BosKoltukAdediGetir()
        {
            int adet = this.Kapasite - this.ToplamTamBiletAdedi - this.ToplamYarimBiletAdedi;
            return adet;
        }
    }
}
