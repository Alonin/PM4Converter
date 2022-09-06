// See https://aka.ms/new-console-template for more information
using System.Drawing;

Console.WriteLine("Please enter the path to your PM4 & ADT Files.");
var folderpath = Console.ReadLine();
string[] PM4Files = Directory.GetFiles(folderpath, "*.pm4");
foreach (var pm4file in PM4Files)
{
    Console.WriteLine(pm4file);
    using (Stream PM4Stream = File.Open(pm4file, FileMode.Open, FileAccess.ReadWrite))
    using (BinaryReader PM4BinaryReader = new BinaryReader(PM4Stream))
    using (BinaryWriter PM4BinaryWriter = new BinaryWriter(PM4Stream))
    {
        while (PM4BinaryReader.BaseStream.Position != PM4BinaryReader.BaseStream.Length)
        {


            var token = PM4BinaryReader.ReadUInt32();
            var size = PM4BinaryReader.ReadUInt32();
            var pos = PM4BinaryReader.BaseStream.Position;
            var i = 0;
            // Console.WriteLine("in MSVT.");
            while (token == 1297307220) // MSVT
            {
                Console.WriteLine("MSVT Found.");
                while (PM4BinaryReader.BaseStream.Position < pos + size)
                { 

                            
                            
                            var posx = PM4BinaryReader.ReadSingle();
                            var posy = PM4BinaryReader.ReadSingle();
                            var height = PM4BinaryReader.ReadSingle();
                            Console.WriteLine(posx + " " + posy + " " + height + " " + i );
                    i++;
                    
                  
                   
                    }

                break;
            }

          
                Console.WriteLine("OUT OF MSVT!!");
            //    PM4BinaryReader.BaseStream.Position = 0;
            PM4BinaryReader.BaseStream.Position = pos + size;
        }
    
    }
       
    }
    
