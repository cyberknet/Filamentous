using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JumpStart.Data.Primitives;
public class SequentialGuid
{
    private static int[] _byteOrder = { 15, 14, 13, 12, 11, 10, 9, 8, 6, 7, 4, 5, 0, 1, 2, 3 };
    public Guid CurrentGuid { get; private set; }
    private byte[] currentBytes;

    public SequentialGuid(Guid previousGuid)
    {
        CurrentGuid = previousGuid;
        currentBytes = CurrentGuid.ToByteArray();
    }

    public SequentialGuid(string previousGuid)
    {
        CurrentGuid = Guid.Parse(previousGuid);
        currentBytes = CurrentGuid.ToByteArray();
    }

    public Guid Next()
    {
        var canIncrement = _byteOrder.Any(i => ++currentBytes[i] != 0);
        CurrentGuid = new Guid(canIncrement ? currentBytes : new byte[16]);
        return CurrentGuid;
    }
}
