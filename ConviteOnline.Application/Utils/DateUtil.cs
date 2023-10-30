using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConviteOnline.Application.Utils
{
    public class DateUtil
    {
        public static string ObterDiaSemana(DayOfWeek week)
        {
            switch (week)
            {
                case DayOfWeek.Sunday:
                    return "Domingo";
                case DayOfWeek.Monday:
                    return "Segunda";
                case DayOfWeek.Tuesday:
                    return "Terça";
                case DayOfWeek.Wednesday:
                    return "Quarta";
                case DayOfWeek.Thursday:
                    return "Quinta";
                case DayOfWeek.Friday:
                    return "Sexta";
                case DayOfWeek.Saturday:
                    return "Sábado";
            }

            return "";
        }
    }
}
