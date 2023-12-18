using System.Linq;

public class CodeWars 
{
  public static string Scanner(int[][] qrcode) 
  {
    var a = new int[9];
    
    for (int r = 18, c = 20, i = 0, dir = -1; i < 72; i++, r+=dir )
    { 
        if (r < 9 || r > 20)
        {
          dir*=-1;
          r+=dir; 
          c-=2;
        }      
        a[i/8]+=  (qrcode[r][c]   ^ (r&1^1)) << (7 - i%8);
        a[i/8]+=  (qrcode[r][c-1] ^ (r&1)) << (7 - ++i%8);
    }
    return string.Concat(a.Skip(1).Take(a[0]).Select(c => (char)c));
  }
}