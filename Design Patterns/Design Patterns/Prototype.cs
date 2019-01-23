using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;


namespace Design_Patterns
{
    public static class ExtensionMethods
    {
        public static T DeepCopy<T>(this T self)
        {
            var stream = new MemoryStream();
            var formatter = new BinaryFormatter();
            formatter.Serialize(stream, self);
            stream.Seek(0, SeekOrigin.Begin);
            object copy = formatter.Deserialize(stream);
            stream.Close();
            return (T) copy;
        }

        public static T DeepCopyxml<T>(this T self)
        {
            using (var ms = new MemoryStream())
            {
                var s = new XmlSerializer(typeof(T));
                s.Serialize(ms, self);
                ms.Position = 0;
                return (T) s.Deserialize(ms);
            }

        }

    }
    
 //   [Serializable]
    public class Person
    {
        public Person()
        {
            
        }
        public string[] Names;
        public Address Address;
        
        public Person(string[] names, Address address)
        {
            Names = names ?? throw new ArgumentNullException(nameof(names));
            Address = address ?? throw new ArgumentNullException(nameof(address));
        }

  //      public Person(Person other)
   //     {      
   //
   //         Names = other.Names;
  //          Address = new Address(other.Address);
 //       }

  //      public Person DeepCopy()
  //      {
 //           return new Person(Names, Address.DeepCopy());
 //       }

        public override string ToString()
        {
            return $"{nameof(Names)}: {string.Join(" ", Names)}, {nameof(Address)}: {Address}";
        }
    }
 //   [Serializable]
    public class Address
    {
        public Address()
        {
            
        }
        public string StreetName;
        public int HouseNumber;

        public Address(string streetName, int houseNumber)
        {
            if (houseNumber == 0)
            {
                throw new ArgumentNullException(nameof(houseNumber));
            }
            StreetName = streetName ?? throw new ArgumentNullException(nameof(streetName));
            HouseNumber = houseNumber;
        }

 //       public Address(Address other)
 //       {
 //           StreetName = other.StreetName;
 //           HouseNumber = other.HouseNumber;
 //       }

        public override string ToString()
        {
            return $"{nameof(StreetName)}: {StreetName}, {nameof(HouseNumber)}: {HouseNumber}";
        }

  //      public Address DeepCopy()
  //      {
  //          return new Address(StreetName, HouseNumber);
   //     }
    }
    static class Prototype
    {

    /// <summary>
    /// 
    /// </summary>
    /// <param name="args"></param>
 //   static void Main(string[] args)
//    {
//        var Riz = new Person(new []{"Riz","Kler"},
//            new Address("Greenacre", 5));

//        var Cindy = Riz.DeepCopyxml();
//        Cindy.Address.StreetName = "Malibu" ;
//        Cindy.Names = new[] {"Cindy Crawford"};
 
//        Console.WriteLine(Riz);
//        Console.WriteLine(Cindy);
//        }
  }

}
