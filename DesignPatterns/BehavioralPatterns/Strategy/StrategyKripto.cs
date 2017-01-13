using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.BehavioralPatterns.Strategy
{
    class StrategyKripto
    {
        public static void Main(string[] args)
        {
            string str = "<app><config><sqlConnection>data....</sqlConnection></config></app>";

            Encrypter enc1 = new Encrypter(new TripleDesEncrypter());
            string encryptedStr = enc1.Encrypt(str);
            string decryptedStr = enc1.Decrypt(str);

            enc1 = new Encrypter(new RijndaelEncrypter());
            encryptedStr = enc1.Encrypt(str);
            decryptedStr = enc1.Decrypt(str);



            Console.ReadKey();
        }
    }

    interface IEncrypter
    {
        string Encrypt(string obj);
        string Decyrpt(string obj);
    }

    // ConcreteStrategy type 1
    class RijndaelEncrypter : IEncrypter
    {
        public string Decyrpt(string obj)
        {
            Console.WriteLine("obj için Rijndael ters şifreleme");
            return obj;
        }

        public string Encrypt(string obj)
        {
            Console.WriteLine("obj için Rijndael şifreleme");
            return obj;
        }
    }

    // ConcreteStrategy type 1
    class TripleDesEncrypter : IEncrypter
    {
        public string Decyrpt(string obj)
        {
            Console.WriteLine("obj için TripleDES ters şifreleme");
            return obj;
        }

        public string Encrypt(string obj)
        {
            Console.WriteLine("obj için TripleDES şifreleme");
            return obj;
        }
    }

    // Context Type
    class Encrypter
    {
        IEncrypter _enc = null;

        public Encrypter(IEncrypter enc)
        {
            this._enc = enc;
        }

        public string Encrypt(string obj)
        {
            return _enc.Encrypt(obj);
        }

        public string Decrypt(string obj)
        {
            return _enc.Decyrpt(obj);
        }
    }












}
