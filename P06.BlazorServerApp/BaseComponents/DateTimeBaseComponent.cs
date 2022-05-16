using Microsoft.AspNetCore.Components;
using System;

namespace P06.BlazorServerApp.BaseComponents
{
    public class DateTimeBaseComponent:ComponentBase
    {
        public DateTime dateTime { get; set; } = DateTime.Now.ToLocalTime();

    }

}
