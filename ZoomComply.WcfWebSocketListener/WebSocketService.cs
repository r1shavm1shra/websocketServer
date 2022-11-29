using Microsoft.ServiceModel.WebSockets;
using Microsoft.Web.WebSockets;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net.WebSockets;
using System.ServiceProcess;
using System.Threading;
using System.Threading.Tasks;

namespace OsuExam.WcfWebSocketListener
{
    
    public class MyWebSocketService : WebSocketService
    {
        WebSocketCollection _webSocketCollection = new WebSocketCollection();
        static WebSocketCollection<MyWebSocketService> _sessions = new WebSocketCollection<MyWebSocketService>();
        
        
        public override void OnOpen()
        {
            _sessions.Add(this);
            base.OnOpen();
        }
        public override void OnMessage(string message)
        {
            if(_sessions.Remove(this))
            {
                _sessions.Add(this);
                _sessions.Broadcast(String.Format("{0}", message));
            }
        }
        protected override void OnClose()
        {
            _sessions.Remove(this);
            this.Dispose(true);
        }
        
    }
}
