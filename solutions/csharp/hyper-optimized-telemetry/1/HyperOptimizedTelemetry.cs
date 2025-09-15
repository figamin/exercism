public static class TelemetryBuffer
{
    private static List<byte> ListPadder(List<byte> givenList)
    {
        while (givenList.Count < 9)
        {
            givenList.Add(0);
        }
        return givenList;
    }
    public static byte[] ToBuffer(long reading)
    {
        // long
        if (reading >= 4_294_967_296)
        {
            Byte[] bufferBytes = BitConverter.GetBytes(reading);
            List<byte> tempBytes = new List<byte>(bufferBytes);
            tempBytes.Insert(0, 248);
            return ListPadder(tempBytes).ToArray();
        }
        // uint
        else if (reading >= 2_147_483_648)
        {
            uint tempReading = (uint)reading;
            Byte[] bufferBytes = BitConverter.GetBytes(tempReading);
            List<byte> tempBytes = new List<byte>(bufferBytes);
            tempBytes.Insert(0, 4);
            return ListPadder(tempBytes).ToArray();
        }
        // int
        else if (reading >= 65_536)
        {
            int tempReading = (int)reading;
            Byte[] bufferBytes = BitConverter.GetBytes(tempReading);
            List<byte> tempBytes = new List<byte>(bufferBytes);
            tempBytes.Insert(0, 252);
            return ListPadder(tempBytes).ToArray();
        }

        // ushort
        else if (reading >= 0)
        {
            ushort tempReading = (ushort)reading;
            Byte[] bufferBytes = BitConverter.GetBytes(tempReading);
            List<byte> tempBytes = new List<byte>(bufferBytes);
            tempBytes.Insert(0, 2);
            return ListPadder(tempBytes).ToArray();
        }

        // short
        else if (reading >= -32_768)
        {
            short tempReading = (short)reading;
            Byte[] bufferBytes = BitConverter.GetBytes(tempReading);
            List<byte> tempBytes = new List<byte>(bufferBytes);
            tempBytes.Insert(0, 254);
            return ListPadder(tempBytes).ToArray();
        }
        // int
        else if (reading >= -2_147_483_648)
        {
            int tempReading = (int)reading;
            Byte[] bufferBytes = BitConverter.GetBytes(tempReading);
            List<byte> tempBytes = new List<byte>(bufferBytes);
            tempBytes.Insert(0, 252);
            return ListPadder(tempBytes).ToArray();
        }
        // long
        else
        {
            Byte[] bufferBytes = BitConverter.GetBytes(reading);
            List<byte> tempBytes = new List<byte>(bufferBytes);
            tempBytes.Insert(0, 248);
            return ListPadder(tempBytes).ToArray();
        }
    }

    public static long FromBuffer(byte[] buffer)
    {
        byte[] actualBuffer = buffer.Skip(1).ToArray();
        // long
        if (buffer[0] == 248)
        {
            return BitConverter.ToInt64(actualBuffer);
        }
        // int
        else if (buffer[0] == 252)
        {
            return BitConverter.ToInt32(actualBuffer);
        }
        // short
        else if (buffer[0] == 254)
        {
            return BitConverter.ToInt16(actualBuffer);
        }
        // ushort
        else if (buffer[0] == 2)
        {
            return BitConverter.ToUInt16(actualBuffer);
        }
        // uint
        else if (buffer[0] == 4)
        {
            return BitConverter.ToUInt32(actualBuffer);
        }
        // invalid
        else
        {
            return 0;
        }
    }
}
