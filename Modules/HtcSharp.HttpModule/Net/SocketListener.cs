using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace HtcSharp.HttpModule.Net {
    public class SocketListener : IDisposable {

        private Socket _socketListener;

        public EndPoint EndPoint { get; private set; }
        public bool IsListening { get; private set; }

        public SocketListener(EndPoint endPoint) {
            EndPoint = endPoint;
        }

        public void Bind(int backlog) {
            IsListening = true;
            var protocolType = EndPoint is UnixDomainSocketEndPoint ? ProtocolType.Unspecified : ProtocolType.Tcp;
            _socketListener = new Socket(EndPoint.AddressFamily, SocketType.Stream, protocolType);
            // ReSharper disable once PossibleUnintendedReferenceComparison
            if (EndPoint is IPEndPoint ip && ip.Address == IPAddress.IPv6Any) _socketListener.DualMode = true;
            _socketListener.Bind(EndPoint);
            EndPoint = _socketListener.LocalEndPoint;
            _socketListener.Listen(backlog);
        }

        public async ValueTask<Socket> AcceptAsync() {
            while (IsListening) {
                try {
                    return await _socketListener.AcceptAsync();
                } catch { 
                    // ignored
                }
            }
            return null;
        }

        public void UnBind() {
            IsListening = false;
            _socketListener?.Dispose();
        }

        public void Dispose() {
            _socketListener?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}