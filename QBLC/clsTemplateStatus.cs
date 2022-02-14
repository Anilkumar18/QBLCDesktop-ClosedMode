using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabelConnector
{
    public class clsTemplateStatus
    {
        //System Save path
        public string TemplatePath { get; set; }

        //Application Save path
        public string TempTemplatePath { get; set; }

        //Template Save status 1(Not saved) Or 0(Saved Template)
        public string TemplateSave { get; set; }

        //Template Mode New Or Edit or Print
        public string TemplateMode { get; set; }

        //Template Status 1(Open) Or 0(Closed)
        public string TemplateStatus { get; set; }

    }
}
