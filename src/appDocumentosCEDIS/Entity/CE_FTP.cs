// Decompiled with JetBrains decompiler
// Type: appDocumentosCEDIS.appDocumentosCEDIS.Entity.CE_FTP
// Assembly: appDocumentosCEDIS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9D682BDA-0A32-4F25-B153-EB5FE4DE73D8
// Assembly location: C:\Users\Luis_\Downloads\appDocumentos Amazon - ALTERNO\appDocumentosCEDIS.exe
// XML documentation location: C:\Users\Luis_\Downloads\appDocumentos Amazon - ALTERNO\appDocumentosCEDIS.xml

using System.Diagnostics;

#nullable disable
namespace appDocumentosCEDIS.appDocumentosCEDIS.Entity;

public class CE_FTP
{
  private string _server;
  private string _user;
  private string _pass;

  public string Pass
  {
    get => this._pass;
    set => this._pass = value;
  }

  public string Server
  {
    get => this._server;
    set => this._server = value;
  }

  public string User
  {
    get => this._user;
    set => this._user = value;
  }

  [DebuggerNonUserCode]
  public CE_FTP()
  {
  }
}
