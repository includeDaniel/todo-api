using System.Collections.Generic;
using Todo.Business.Notifications;

namespace Todo.Business.Interfaces
{
    public interface INotify
    {
        bool HaveNotifications();
        List<Notify> GetAllNotifications();
        void Handle(Notify notify);

    }
}