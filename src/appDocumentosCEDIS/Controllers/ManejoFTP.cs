// Decompiled with JetBrains decompiler
// Type: appDocumentosCEDIS.appDocumentosCEDIS.Controllers.ManejoFTP
// Assembly: appDocumentosCEDIS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9D682BDA-0A32-4F25-B153-EB5FE4DE73D8
// Assembly location: C:\Users\Luis_\Downloads\appDocumentos Amazon - ALTERNO\appDocumentosCEDIS.exe
// XML documentation location: C:\Users\Luis_\Downloads\appDocumentos Amazon - ALTERNO\appDocumentosCEDIS.xml

using Atp.IO;
using Atp.Net;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Data;
using System.Runtime.CompilerServices;

#nullable disable
namespace appDocumentosCEDIS.appDocumentosCEDIS.Controllers;

public class ManejoFTP
{
  private string _Server;
  private string _User;
  private string _Pass;

  public ManejoFTP(string user, string pass, string server)
  {
    this._User = user;
    this._Pass = pass;
    this._Server = server;
  }

  public bool eliminarFtp(string ruta_ftp, string nombre)
  {
    int num = 0;
    bool flag1 = false;
    bool flag2;
    do
    {
      Ftp ftp = new Ftp();
      flag2 = false;
      try
      {
        ftp.Connect(this._Server);
        ftp.Authenticate(this._User, this._Pass);
        ftp.Timeout = 100000;
        ftp.Passive = false;
        if (ftp.State == RemoteFileSystemState.Disconnected)
          ftp.Connect(this._Server);
        ftp.DeleteFile(ruta_ftp + nombre);
        flag1 = true;
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Exception exception = ex;
        flag2 = true;
        flag1 = false;
        clsLog.SetLog(exception.Message);
        ProjectData.ClearProjectError();
      }
      finally
      {
        ftp.Disconnect();
      }
    }
    while (flag2 && num <= 4);
    return flag1;
  }

  public bool eliminarFtpMasivo(DataTable tablaArchivos)
  {
    IEnumerator enumerator = (IEnumerator) null;
    int num = 0;
    bool flag1 = false;
    bool flag2;
    do
    {
      Ftp Instance = new Ftp();
      flag2 = false;
      try
      {
        Instance.Connect(this._Server);
        Instance.Authenticate(this._User, this._Pass);
        Instance.Timeout = 100000;
        Instance.Passive = false;
        if (Instance.State == RemoteFileSystemState.Disconnected)
          Instance.Connect(this._Server);
        try
        {
          foreach (object row in tablaArchivos.Rows)
          {
            object objectValue1 = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(row));
            object[] Arguments1 = new object[1]
            {
              (object) "RutaRemota"
            };
            object objectValue2 = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(RuntimeHelpers.GetObjectValue(objectValue1), (Type) null, "item", Arguments1, (string[]) null, (Type[]) null, (bool[]) null));
            object[] Arguments2 = new object[2]
            {
              (object) "/",
              (object) "\\"
            };
            object[] Arguments3 = new object[1]
            {
              RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(RuntimeHelpers.GetObjectValue(objectValue2), (Type) null, "replace", Arguments2, (string[]) null, (Type[]) null, (bool[]) null))))
            };
            bool[] CopyBack = new bool[1]{ true };
            NewLateBinding.LateCall((object) Instance, (Type) null, "DeleteFile", Arguments3, (string[]) null, (Type[]) null, CopyBack, true);
            if (CopyBack[0])
              RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(Arguments3[0]));
          }
        }
        finally
        {
          if (enumerator is IDisposable)
            (enumerator as IDisposable).Dispose();
        }
        flag1 = true;
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Exception exception = ex;
        flag2 = true;
        flag1 = false;
        clsLog.SetLog(exception.Message);
        ProjectData.ClearProjectError();
      }
      finally
      {
        Instance.Disconnect();
      }
    }
    while (flag2 && num <= 4);
    return flag1;
  }

  public bool enviarFtp(string ruta_origen, string ruta_ftp, string nombre)
  {
    int num = 0;
    bool flag1 = false;
    while (true)
    {
      Ftp ftp = new Ftp();
      bool flag2 = false;
      try
      {
        ftp.Connect(this._Server);
        ftp.Authenticate(this._User, this._Pass);
        ftp.Timeout = 100000;
        ftp.Passive = false;
        if (ftp.State == RemoteFileSystemState.Disconnected)
          ftp.Connect(this._Server);
        if (!ftp.DirectoryExists(ruta_ftp))
          ftp.CreateDirectory(ruta_ftp);
        ftp.UploadFile(ruta_origen, ruta_ftp + nombre);
        if (!ftp.FileExists(ruta_ftp + nombre))
        {
          flag1 = false;
          flag2 = true;
          clsLog.SetLog($"Fallo FTP Archivo: {ruta_ftp}{nombre}");
        }
        else
          flag1 = true;
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Exception exception = ex;
        flag2 = true;
        flag1 = false;
        clsLog.SetLog(exception.Message);
        ProjectData.ClearProjectError();
      }
      finally
      {
        ftp.Disconnect();
      }
      if (flag2 && num <= 4)
        checked { ++num; }
      else
        break;
    }
    return flag1;
  }
}
