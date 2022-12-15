#region Namespaces
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Diagnostics;


#endregion

namespace Redline
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(
          ExternalCommandData commandData,
          ref string message,
          ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Application app = uiapp.Application;
            Document doc = uidoc.Document;

            // Set the line style to use
            LineStyle lineStyle = new LineStyle("MyLineStyle", Color.Red, 2);

            // Set the current line style
            revitDoc.SetCurrentLineStyle(lineStyle);

            // Issue the annotation line command
            revitDoc.InvokeAnnotationLineCommand(
              new XYZ(0, 0, 0),  // Start point
              new XYZ(100, 100, 0) // End point
            );

            return Result.Succeeded;
        }
    }

  
}
