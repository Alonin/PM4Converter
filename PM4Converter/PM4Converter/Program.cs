// See https://aka.ms/new-console-template for more information
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
        var token = PM4BinaryReader.ReadUInt32();
        var pos = PM4BinaryReader.BaseStream.Position;
        var size = (9 * 9 + 8 * 8);
        if(token == 1296258644) // mcvt
        {
            while (PM4BinaryReader.BaseStream.Position < pos + size)
            {
                Console.WriteLine(size);
                    }
        }
       
    }
}