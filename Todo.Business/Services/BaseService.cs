namespace Todo.Business.Services
{
    public abstract class BaseService
    {
       // private readonly INotify _notify;

    //    protected BaseService(INotify notify)
    //    {
    //        _notify = notify;
    //    }

    //    protected void Notify(ValidationResult validationResult)
    //    {
    //        foreach (var error in validationResult.Errors)
    //        {
    //            Notify(error.ErrorMessage);
    //        }
    //    }

    //    protected void Notify(string mesage)
    //    {
    //        _notify.Handle(new Notify(mesage));
    //    }

    //    protected bool ExecuteValidation<TV, TE>(TV vality, TE entity) where TV : AbstractValidator<TE> where TE : Entity
    //    {
    //        var validate = vality.Validate(entity);

    //        if (validate.IsValid) return true;

    //        Notify(validate);

    //        return false;
    //    }

    }
}