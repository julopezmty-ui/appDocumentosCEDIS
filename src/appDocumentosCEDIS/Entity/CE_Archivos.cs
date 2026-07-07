// Decompiled with JetBrains decompiler
// Type: appDocumentosCEDIS.appDocumentosCEDIS.Entity.CE_Archivos
// Assembly: appDocumentosCEDIS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9D682BDA-0A32-4F25-B153-EB5FE4DE73D8
// Assembly location: C:\Users\Luis_\Downloads\appDocumentos Amazon - ALTERNO\appDocumentosCEDIS.exe
// XML documentation location: C:\Users\Luis_\Downloads\appDocumentos Amazon - ALTERNO\appDocumentosCEDIS.xml

using System.Diagnostics;

#nullable disable
namespace appDocumentosCEDIS.appDocumentosCEDIS.Entity;

public class CE_Archivos
{
  private string _id_num_doc;
  private bool _Estatus;
  private string _carpeta;
  private string _Descripcion;
  private string _Ruta;

  public string carpeta
  {
    get => this._carpeta;
    set => this._carpeta = value;
  }

  public string descripcion
  {
    get => this._Descripcion;
    set => this._Descripcion = value;
  }

  public bool estatus
  {
    get => this._Estatus;
    set => this._Estatus = value;
  }

  public string id_num_doc
  {
    get => this._id_num_doc;
    set => this._id_num_doc = value;
  }

  public string ruta
  {
    get => this._Ruta;
    set => this._Ruta = value;
  }

  [DebuggerNonUserCode]
  public CE_Archivos()
  {
  }
}
