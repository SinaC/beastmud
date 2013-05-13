﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Beast.IO;

namespace Beast.Net
{
    public class SocketConnection : ConnectionBase
    {
        public const int ReceiveBufferSize = 1024;
        public static readonly byte[] CommandTerminator = Encoding.ASCII.GetBytes(Environment.NewLine);

        protected byte[] Buffer = new byte[ReceiveBufferSize];
        protected List<byte> PacketData = new List<byte>();
        protected Socket Socket { get; set; }

        protected Application App { get; private set; }

        public SocketConnection(Application app, Socket socket)
        {
            Socket = socket;
            Socket.Blocking = false;

            App = app;

            BeginReceive();
        }

        public override void Write(IOutput output)
        {
            try
            {
                var data = OutputResolver.Resolve<byte[]>(output);
                Socket.BeginSend(data, 0, data.Length, SocketFlags.None, OnBeginSendComplete, Socket);
            }
            catch (SocketException)
            {
                // Disconnect the current Socket.
                if (Socket != null)
                    Socket.Close();
            }
            catch (ObjectDisposedException) { return; }
        }

        public override void Close()
        {
            Socket.Close();
        }

        private void BeginReceive()
        {
            try
            {
                Socket.BeginReceive(Buffer, 0, Buffer.Length, SocketFlags.None, OnBeginReceiveComplete, this);
            }
            catch (ObjectDisposedException) { }
        }
        private static void OnBeginReceiveComplete(IAsyncResult ar)
        {
            var connection = (SocketConnection)ar.AsyncState;

            int bytesReceived;
            try
            {
                // Complete the call.
                bytesReceived = connection.Socket.EndReceive(ar);
                if (bytesReceived > ReceiveBufferSize || bytesReceived == 0)
                {
                    connection.Socket.Close();
                    return;
                }
            }
            catch (SocketException)
            {
                // Disconnect the current client.
                connection.Socket.Close();
                return;
            }
            catch (ObjectDisposedException)
            {
                return;
            }

            try
            {
                if (bytesReceived > 0)
                {
                    var buffer = connection.Buffer.Take(bytesReceived).ToArray();
                    if (buffer.EndsWith(CommandTerminator))
                    {
                        if (buffer.Length > CommandTerminator.Length)
                            connection.PacketData.AddRange(buffer.Take(buffer.Length - CommandTerminator.Length));

                        var input = InputResolver.Resolve(connection.PacketData.ToArray());
                        connection.App.ProcessInput(connection, input);
                        connection.PacketData.Clear();
                    }
                    else
                    {
                        connection.PacketData.AddRange(buffer);
                    }
                }

                connection.BeginReceive();
            }
            catch (SocketException)
            {
                connection.Socket.Close();
            }
        }
        private void OnBeginSendComplete(IAsyncResult ar)
        {
            try
            {
                var handler = (Socket)ar.AsyncState;
                // Complete the sending of data.
                var bytesSent = handler.EndSend(ar);
            }
            catch (SocketException)
            {
                // Raise the disconnect event and close the current Socket.
                if (Socket != null)
                    Socket.Close();
            }
            catch (ObjectDisposedException) { }
        }
    }
}