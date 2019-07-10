using RabbitMQ.Client;

namespace delegateTutorial
{
    public interface IRabbitFactory
    {
        ConnectionFactory Create();
    }

    public class RabbitFactory : IRabbitFactory
    {
        readonly string _userName;
        readonly string _pwd;
        readonly string _host;
        readonly int _port;

        public RabbitFactory(string mqUserName, string mqPwd, string mqHost, int mqPort)
        {
            _userName = mqUserName;
            _pwd = mqPwd;
            _host = mqHost;
            _port = mqPort;
        }
        public ConnectionFactory Create() => new ConnectionFactory()
        {
            UserName = _userName,
            Password = _pwd,
            HostName = _host,
            Port = _port
        };
    }
}