Imports System.Net
Imports System.Net.Sockets
Imports System.Text

Module ModUdpCli

    Sub Main()
        Dim port As Integer = 12345
        Dim udpClient As New UdpClient()
        Try
            udpClient.Connect("localhost", port)

            Console.Write("請輸入你的名字: ")
            Dim inputString As String = Console.ReadLine()
            Dim sendBytes As [Byte]() = Encoding.UTF8.GetBytes(inputString)
            udpClient.Send(sendBytes, sendBytes.Length)

            Dim receiveBytes As [Byte]() = udpClient.Receive(udpClient.Client.LocalEndPoint)
            Dim returnData As String = Encoding.UTF8.GetString(receiveBytes)
            Console.WriteLine(returnData.ToString())
            udpClient.Close()
        Catch e As Exception
            Console.WriteLine(e.ToString())
        End Try
        Console.ReadKey()
    End Sub

End Module

