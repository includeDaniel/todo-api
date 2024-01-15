using Todo.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace Todo.Business.Notifications
{
    public class Notifier : INotify
    {
        private List<Notify> _notifications;

        public Notifier()
        {
            _notifications = new List<Notify>();
        }

        public bool HaveNotifications()
        {
            return _notifications.Any();
        }

        public List<Notify> GetAllNotifications()
        {
            return _notifications;
        }

        public void Handle(Notify notify)
        {
            _notifications.Add(notify);
        }

    }
}
