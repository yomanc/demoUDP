Imports System.Net
Imports System.Net.Sockets
Imports System.Text

Module ModUdpSrv

    Sub Main()
        Dim port As Integer = 12345
        Dim udpClient As New UdpClient(port)
        Try
            Dim RemoteIpEndPoint As New IPEndPoint(IPAddress.Any, port)

            While (True)
                Dim receiveBytes As [Byte]() = udpClient.Receive(RemoteIpEndPoint)
                Dim receiveData As String = Encoding.UTF8.GetString(receiveBytes)
                Console.WriteLine("rcv: " & receiveData)
                Console.WriteLine("frm" & RemoteIpEndPoint.Address.ToString() & ":" & RemoteIpEndPoint.Port)

                Dim sendData As String = "Good day, " & receiveData
                Dim sendBytes As [Byte]() = Encoding.UTF8.GetBytes(sendData)
                udpClient.Send(sendBytes, sendBytes.Length, RemoteIpEndPoint)
                Console.WriteLine("return: " & sendData)
                Console.WriteLine()
            End While
            udpClient.Close()
        Catch e As Exception
            Console.WriteLine(e.ToString())
        End Try
    End Sub

End Module