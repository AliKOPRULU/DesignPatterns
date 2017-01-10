using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.BehavioralPatterns.ChainofResponsibility
{
    class ChainofResponsibilityService
    {
        public static void Main(string[] args)
        {
            // Önce zincire dahil olacak nesne örnekleri oluşturulur
            ServiceHandler handlerLocal = new LocalMachineHandler();
            ServiceHandler handlerIntranet = new IntranetHandler();
            ServiceHandler handlerInternet = new InternetHandler();

            // Zincirde yer alan her bir nesne kendisinden sonra gelecek olan nesneyi belirler.
            // Bu belirleme işlemi için Successor özelliği kullanılır.
            handlerLocal.Successor = handlerIntranet;
            handlerIntranet.Successor = handlerInternet;

            // Zincir halkasındaki nesneler tarafından kullanılacak olan nesne örneği oluşturulur.
            ServiceInfo info = new ServiceInfo { Name = "Order Process Service", Location = ServiceLocation.Intranet }; ;

            // Zincirin ilk halkasındaki nesneye, talep gönderilir.
            handlerLocal.ProcessRequest(info);

            // Servisi kırdığımız nokta. Minik bir bomba ve antrenman sorusu.
            // handlerInternet.ProcessRequest(info);
            //ilkten değil de sondan başlatınca patlıyor o yüzden her zaman ilkten başlatmamız gerekiyor

            Console.ReadKey();
        }
    }

    enum ServiceLocation
    {
        LocalMachine,
        Intranet,
        Internet,
        SecureZone
    }

    // Zincir içerisindeki nesnelerde dolaşabilecek olan tip
    class ServiceInfo
    {
        public string Name { get; set; }
        public ServiceLocation Location { get; set; }
    }

    //Handler
    abstract class ServiceHandler
    {
        protected ServiceHandler _successor;

        public ServiceHandler Successor
        {
            set { _successor = value; }
        }

        public abstract void ProcessRequest(ServiceInfo sInfo);
    }

    // ConcreteHandler
    // Servisin Internet üzerinde olduğu durumu ele alır.
    // Sorumluluk zincirinin son sırasındaki tip
    class InternetHandler : ServiceHandler
    {
        public override void ProcessRequest(ServiceInfo sInfo)
        {
            // Eğer lokasyon Internet ise bu tipe ait nesnenin sorumluluğundadır Eğer Internet' de değilse artık sernin son halkası olduğundan gidecek başka bir yer kalmamıştır. Buna uygun şekilde bir hareket yapılmalıdır.
            if (sInfo.Location == ServiceLocation.Internet) { 
                Console.WriteLine("Web ortamı üzerinde yer alan bir servis.\n\t{0} için gerekli başlatma işlemleri yapılıyor.", sInfo.Name);
            }
            else { 
                Console.WriteLine("Uzaydan gelen bir servis mi bu yauv?");
            }

        }
    }

    // ConcreteHandler
    // Servisin Intranet üzerinde olduğu durumu ele alır.
    class IntranetHandler : ServiceHandler
    {
        public override void ProcessRequest(ServiceInfo sInfo)
        {
            // Eğer servis yerel makinede değilse zincirin bir sonraki tipi olan IntranetHandler' a gelir. Burada servis lokasyonunun Intranet olup olmadığına bakılır. Eğer öyleyse sorumluluk buradadır ve yerine getirilir.Ama değilse, zincirde bir sonraki tip olan InternetHandler nesne örneğine ait ProcessRequest metodu çağırılır.
            if (sInfo.Location == ServiceLocation.Intranet)
                Console.WriteLine("Şirket Network' ü üzerinde yer alan bir servis.\n\t{0} için gerekli başlatma işlemleri yapılıyor.", sInfo.Name);
            else if (_successor != null)
                _successor.ProcessRequest(sInfo);
        }
    }

    // ConcreteHandler
    // Servisin yerel makineye ait olma durumunu ele alır.
    class LocalMachineHandler : ServiceHandler
    {
        public override void ProcessRequest(ServiceInfo sInfo)
        {
            // Eğer servis yerel makinede ise sorumluluk LocalMachineHandler nesne örneğine aittir. Ancak değilse, zincirde bir sonraki tip olan IntranetHandler' a ait ProcessRequest metodu çağırılır.
            if (sInfo.Location == ServiceLocation.LocalMachine)
                Console.WriteLine("Yerel makinede yer alan bir servis.\n\t{0} için gerekli başlatma işlemleri yapılıyor.", sInfo.Name);
            else if (_successor != null)
                _successor.ProcessRequest(sInfo);
        }
    }





}
