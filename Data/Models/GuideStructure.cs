using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiGuideService.Data.Models
{
    public class GuideStructure //Структура справочника
    {
        /*Идентификатор справочника*/
        public int Id { get; set; }
        /*Наименование справочника*/
        public string Name { get; set; }
    }
}
