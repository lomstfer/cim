using System.Collections;
using System.Runtime.InteropServices;

if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) {
    Console.WriteLine("only windows is supported lmao");
    return;
}
Random random = new();

if (args == null || args.Length < 2) {
    Console.WriteLine("provide input file and output file. example: cim in.jpg out.jpg");
    return;
}

string filename = args[0];
if (!File.Exists(filename)) {
    Console.WriteLine("input file not found");
    return;
}

ImageByter imgb = new(filename);

BitArray bits = imgb.Bits;

int levels = 7;
if (args != null && args.Length >= 3) 
    int.TryParse(args[2], out levels);

for (int level = 0; level < levels; level++) {
    for (int i = 0; i < imgb.Bits.Length; i += 8) {
        bool r = random.Next(2) == 1;
        bits.Set(i + level, r);
    }
}


imgb.Bits = bits;

imgb.SaveFile(args[1]);