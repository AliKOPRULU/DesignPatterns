using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DesignPatterns.StructuralPatterns.Proxy
{//http://harunozer.com/makale/proxy_tasarim_deseni__proxy_design_pattern.htm
    class ProxyImageShos
    {
        public static void Main(string[] args)
        {//Önce önizleme gösteriliyor sonra bekleme süresi dolunca asıl resim gösteriliyor
            ImageGeneratorProxy proxy1 = new ImageGeneratorProxy();
            proxy1.ShowImage();

            Console.ReadKey();
        }
    }

    interface IImageGenerator
    {
        void ShowImage();
    }

    //RealSubject
    class ImageGenerator : IImageGenerator
    {
        public void ShowImage()
        {
            Console.WriteLine("gerçek resmi gösteriliyor.");
        }
    }

    //Proxy
    class ImageGeneratorProxy : IImageGenerator
    {
        //proxy sınıfı Subject i uygular ve içinde subject referansı barındırır.
        private ImageGenerator _imageGenerator;
        private Timer t;
        private bool LoadRealObject = false;

        private void ShowRealImage(object o)
        {
            _imageGenerator = new ImageGenerator();
            _imageGenerator.ShowImage();
            LoadRealObject = true;
        }

        public void ShowImage()
        {
            if (_imageGenerator == null)
            {
                //burada başka bir threadda asıl nesnenin yüklenmesinin başlatıldığını düşünebiliriz.
                t = new Timer(new TimerCallback(ShowRealImage), this, 2000, 0);
            }
            if (!LoadRealObject)//gerçek nesne yüklenmesi tamamlanmamış ise önizleme resmi gösterilsin.
            {
                Console.WriteLine("önizleme resmi gösteriliyor.");
            }
        }

    }









}
