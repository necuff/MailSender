using MailSenderLib.Data;
using MailSenderLib.Entities;
using MailSenderLib.Services.Interfaces;

namespace MailSenderLib.Services
{
    public class ServersStoreInMemory : DataStoreInMemory<Server>, IServersStore
    {
        public ServersStoreInMemory() : base(TestData.Servers)
        {

        }

        public override void Edit(int id, Server server)
        {
            //Делаем вид, что работаем с БД, а не с объектами в памяти            
            //server.id <> id, т.к. это разные объекты
            var db_server = GetByID(id);
            if (db_server is null) return;

            db_server.Name = server.Name;
            db_server.Address = server.Address;
            db_server.Port = server.Port;
            db_server.UseSSL = server.UseSSL;
            db_server.Login = server.Login;
            db_server.Password = server.Password;
        }
    }
}
