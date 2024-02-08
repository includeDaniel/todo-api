using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Todo.Business.Interfaces;
using Todo.Business.Models;
using Todo.Business.Notifications;

namespace Todo.API.Controllers
{
public class MainController : ControllerBase
    {
        private readonly INotify _notify;

        public MainController(INotify notify)
        {
            _notify = notify;

        }
        protected ActionResult HandleResponse(Object result = null)
        {
            if (HasNoErros())
            { 
                return Ok(new
                {
                    success = true,
                    data = result
                });
            }

            return BadRequest(new
            {
                success = false,
                errors = _notify.GetAllNotifications().Select(n => n.Mesage)
            }); 


        }
        protected ActionResult HandleResponse(ModelStateDictionary modelState)
        {
            if (!modelState.IsValid) NotifyInvalidModelState(modelState);

            return HandleResponse();
        }

        protected void NotifyInvalidModelState(ModelStateDictionary modelState)
        {
            foreach (var error in modelState.Values.SelectMany(e => e.Errors))
            {
                var errorMsg = error.Exception == null ? error.ErrorMessage : error.Exception.Message;
                NotifyError(errorMsg);
            }
        }

        protected bool HasNoErros()
        {
            return !_notify.HaveNotifications();
        }

        protected void NotifyError(string mesage)
        {
            _notify.Handle(new Notify(mesage));
        }

    }
}
