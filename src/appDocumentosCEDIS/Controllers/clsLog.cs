// Decompiled with JetBrains decompiler
// Type: appDocumentosCEDIS.appDocumentosCEDIS.Controllers.clsLog
// Assembly: appDocumentosCEDIS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9D682BDA-0A32-4F25-B153-EB5FE4DE73D8
// Assembly location: C:\Users\Luis_\Downloads\appDocumentos Amazon - ALTERNO\appDocumentosCEDIS.exe
// XML documentation location: C:\Users\Luis_\Downloads\appDocumentos Amazon - ALTERNO\appDocumentosCEDIS.xml

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

#nullable disable
namespace appDocumentosCEDIS.appDocumentosCEDIS.Controllers;

public class clsLog
{
  private static string _dir = Application.StartupPath;
  private static string _fileLog = "Log.txt";

  [DebuggerNonUserCode]
  public clsLog()
  {
  }

  public static void SetLog(string mensaje)
  {
    try
    {
      StreamWriter streamWriter = new StreamWriter(clsLog._dir + clsLog._fileLog, true);
      DateTime now = DateAndTime.Now;
      streamWriter.WriteLine($"{now.ToString("yyyy/MM/dd hh:mm:ss")} -> {mensaje}");
      streamWriter.Flush();
      streamWriter.Close();
    }
    catch (Exception ex)
    {
      ProjectData.SetProjectError(ex);
      ProjectData.ClearProjectError();
    }
  }

  public static string Validar()
  {
    string str;
    try
    {
      if (Directory.Exists(clsLog._dir))
        Directory.CreateDirectory(clsLog._dir);
      new StreamWriter(clsLog._dir + clsLog._fileLog, true).Close();
    }
    catch (Exception ex)
    {
      ProjectData.SetProjectError(ex);
      str = global::appDocumentosCEDIS.Conversions.ToString((object) false);
      ProjectData.ClearProjectError();
      goto label_6;
    }
    str = global::appDocumentosCEDIS.Conversions.ToString((object) false);
label_6:
    return str;
  }
}
