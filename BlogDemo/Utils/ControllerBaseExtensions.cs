using Microsoft.AspNetCore.Mvc;
using BlogDemo.DTOs;

public static class ControllerBaseExtensions
{
    public static ActionResult ParseException(this ControllerBase controller, Exception exception)
    {
        try
        {
            throw exception;
        }
        catch (KeyNotFoundException ex)
        {
            return controller.NotFound(ReturnMessage.Parse(ex.Message));
        }
        catch (InvalidOperationException ex)
        {
            return controller.BadRequest(ReturnMessage.Parse(ex.Message));
        }
    }
}